using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Localazy.Model;
using Localazy.Util;

namespace Localazy.Service;

/// <summary>
/// Internal HTTP client wrapper for making requests to the Localazy API.
/// </summary>
internal class HttpWrapper
{
    private const string LocalazyApi = "https://api.localazy.com";

    private readonly HttpClient _client;
    private readonly LocalazyConfig _config;
    private readonly JsonSerializerOptions _jsonOptions;

    /// <summary>
    /// Initializes a new instance of the <see cref="HttpWrapper"/> class.
    /// </summary>
    /// <param name="client">The HTTP client instance to use for requests.</param>
    /// <param name="config">The Localazy configuration containing API credentials.</param>
    public HttpWrapper(HttpClient client, LocalazyConfig config)
    {
        _client = client;
        _config = config;
        _jsonOptions = new JsonSerializerOptions
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            Converters = {new KeyValueConverter()}
        };

        _client.Timeout = TimeSpan.FromSeconds(10);
    }

    /// <summary>
    /// Creates a new HTTP request for the specified API path.
    /// </summary>
    /// <param name="path">The API endpoint path (without the base URL).</param>
    /// <returns>A configured <see cref="HttpRequest"/> instance.</returns>
    public HttpRequest GetRequest(string path)
    {
        var request = new HttpRequest(_client, $"{LocalazyApi}/{path}", _jsonOptions, _config);
        return request;
    }
}

/// <summary>
/// Represents an HTTP request to the Localazy API with fluent configuration methods.
/// </summary>
internal class HttpRequest
{
    private readonly HttpClient _client;
    private readonly Dictionary<string, string> _headers = new();
    private readonly JsonSerializerOptions _jsonOptions;
    private readonly List<string> _queryParameters = new();
    private readonly string _url;

    /// <summary>
    /// Initializes a new instance of the <see cref="HttpRequest"/> class.
    /// </summary>
    /// <param name="client">The HTTP client to use for the request.</param>
    /// <param name="url">The complete URL for the request.</param>
    /// <param name="jsonSerializerOptions">JSON serialization options.</param>
    /// <param name="localazyConfig">Configuration containing API credentials.</param>
    public HttpRequest(HttpClient client, string url, JsonSerializerOptions jsonSerializerOptions,
        LocalazyConfig localazyConfig)
    {
        _client = client;
        _url = url;
        _jsonOptions = jsonSerializerOptions;

        _headers["Authorization"] = $"Bearer {localazyConfig.ApiKey}";
    }

    /// <summary>
    /// Adds a query parameter to the request.
    /// </summary>
    /// <param name="key">The parameter name.</param>
    /// <param name="value">The parameter value.</param>
    /// <returns>The current <see cref="HttpRequest"/> instance for method chaining.</returns>
    public HttpRequest AddQueryParameter(string key, string value)
    {
        _queryParameters.Add($"{key}={value}");
        return this;
    }

    /// <summary>
    /// Adds a query parameter to the request only if the value is not null.
    /// </summary>
    /// <param name="key">The parameter name.</param>
    /// <param name="value">The parameter value (can be null).</param>
    /// <returns>The current <see cref="HttpRequest"/> instance for method chaining.</returns>
    public HttpRequest AddOptionalQueryParameter(string key, string? value)
    {
        if (value is not null) AddQueryParameter(key, value);
        return this;
    }

    private async Task<HttpResponseMessage> GetResponse(HttpMethod method)
    {
        return await GetResponse<string>(method);
    }

    private async Task<HttpResponseMessage> GetResponse<TBody>(HttpMethod method, TBody? body = null, bool raw = false)
        where TBody : class
    {
        var url = _url;
        if (_queryParameters.Any())
        {
            var query = string.Join("&", _queryParameters);
            url += $"?{query}";
        }

        using var request = new HttpRequestMessage(method, url);
        request.Version = HttpVersion.Version20;
        foreach (var (header, value) in _headers) request.Headers.Add(header, value);

        if (body != null)
        {
            if (raw)
            {
                if (body is not string stringBody)
                {
                    throw new InvalidDataException("Body must be a string, if a raw request is used");
                }

                request.Content = new StringContent(stringBody, Encoding.UTF8, "application/json");
            }
            else
            {
                var json = JsonSerializer.Serialize(body, _jsonOptions);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }
        }

        var response = await _client.SendAsync(request);
        if (response.IsSuccessStatusCode) return response;

        throw new LocalazyException(Deserialize<LocalazyError>(await response.Content.ReadAsStringAsync()));
    }

    /// <summary>
    /// Sends an HTTP GET request and deserializes the response to the specified type.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the response to.</typeparam>
    /// <returns>The deserialized response object.</returns>
    /// <exception cref="LocalazyException">Thrown when the API returns an error response.</exception>
    public async Task<T> Get<T>()
    {
        var response = await GetResponse(HttpMethod.Get);
        var result = await response.Content.ReadAsStringAsync();
        return Deserialize<T>(result);
    }

    /// <summary>
    /// Sends an HTTP GET request and returns the response as a stream.
    /// </summary>
    /// <returns>A stream containing the response data.</returns>
    /// <exception cref="LocalazyException">Thrown when the API returns an error response.</exception>
    public async Task<Stream> GetStream()
    {
        var response = await GetResponse(HttpMethod.Get);
        return await response.Content.ReadAsStreamAsync();
    }

    /// <summary>
    /// Sends an HTTP POST request with the specified body and deserializes the response.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the response to.</typeparam>
    /// <param name="body">The request body object to serialize as JSON.</param>
    /// <returns>The deserialized response object.</returns>
    /// <exception cref="LocalazyException">Thrown when the API returns an error response.</exception>
    public async Task<T> Post<T>(object body)
    {
        var response = await GetResponse(HttpMethod.Post, body);
        var result = await response.Content.ReadAsStringAsync();
        return Deserialize<T>(result);
    }

    /// <summary>
    /// Sends an HTTP POST request with a raw JSON string body and deserializes the response.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the response to.</typeparam>
    /// <param name="body">The raw JSON string to send as the request body.</param>
    /// <returns>The deserialized response object.</returns>
    /// <exception cref="LocalazyException">Thrown when the API returns an error response.</exception>
    public async Task<T> PostRaw<T>(string body)
    {
        var response = await GetResponse(HttpMethod.Post, body, true);
        var result = await response.Content.ReadAsStringAsync();
        return Deserialize<T>(result);
    }

    /// <summary>
    /// Sends an HTTP PUT request with the specified body and deserializes the response.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the response to.</typeparam>
    /// <param name="body">The request body object to serialize as JSON.</param>
    /// <returns>The deserialized response object.</returns>
    /// <exception cref="LocalazyException">Thrown when the API returns an error response.</exception>
    public async Task<T> Put<T>(object body)
    {
        var response = await GetResponse(HttpMethod.Put, body);
        var result = await response.Content.ReadAsStringAsync();
        return Deserialize<T>(result);
    }

    /// <summary>
    /// Sends an HTTP DELETE request and deserializes the response.
    /// </summary>
    /// <typeparam name="T">The type to deserialize the response to.</typeparam>
    /// <returns>The deserialized response object.</returns>
    /// <exception cref="LocalazyException">Thrown when the API returns an error response.</exception>
    public async Task<T> Delete<T>()
    {
        var response = await GetResponse(HttpMethod.Delete);
        var result = await response.Content.ReadAsStringAsync();
        return Deserialize<T>(result);
    }

    private T Deserialize<T>(string json)
    {
        return JsonSerializer.Deserialize<T>(json, _jsonOptions) ?? throw new NullReferenceException();
    }
}