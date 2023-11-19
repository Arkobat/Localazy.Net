using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Localazy.Model;
using Localazy.Util;

namespace Localazy.Service;

internal class HttpWrapper
{
    private const string LocalazyApi = "https://api.localazy.com";

    private readonly HttpClient _client;
    private readonly LocalazyConfig _config;
    private readonly JsonSerializerOptions _jsonOptions;

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

    public HttpRequest GetRequest(string path)
    {
        var request = new HttpRequest(_client, $"{LocalazyApi}/{path}", _jsonOptions, _config);
        return request;
    }
}

internal class HttpRequest
{
    private readonly HttpClient _client;
    private readonly Dictionary<string, string> _headers = new();
    private readonly JsonSerializerOptions _jsonOptions;
    private readonly List<string> _queryParameters = new();
    private readonly string _url;

    public HttpRequest(HttpClient client, string url, JsonSerializerOptions jsonSerializerOptions,
        LocalazyConfig localazyConfig)
    {
        _client = client;
        _url = url;
        _jsonOptions = jsonSerializerOptions;

        _headers["Authorization"] = $"Bearer {localazyConfig.ApiKey}";
    }

    public HttpRequest AddQueryParameter(string key, string value)
    {
        _queryParameters.Add($"{key}={value}");
        return this;
    }

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

    public async Task<T> Get<T>()
    {
        var response = await GetResponse(HttpMethod.Get);
        var result = await response.Content.ReadAsStringAsync();
        return Deserialize<T>(result);
    }

    public async Task<Stream> GetStream()
    {
        var response = await GetResponse(HttpMethod.Get);
        return await response.Content.ReadAsStreamAsync();
    }

    public async Task<T> Post<T>(object body)
    {
        var response = await GetResponse(HttpMethod.Post, body);
        var result = await response.Content.ReadAsStringAsync();
        return Deserialize<T>(result);
    }

    public async Task<T> PostRaw<T>(string body)
    {
        var response = await GetResponse(HttpMethod.Post, body, true);
        var result = await response.Content.ReadAsStringAsync();
        return Deserialize<T>(result);
    }

    public async Task<T> Put<T>(object body)
    {
        var response = await GetResponse(HttpMethod.Put, body);
        var result = await response.Content.ReadAsStringAsync();
        return Deserialize<T>(result);
    }

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