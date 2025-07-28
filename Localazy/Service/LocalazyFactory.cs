using Localazy.Model;

namespace Localazy.Service;

/// <summary>
/// Factory implementation for creating instances of <see cref="ILocalazyService"/>.
/// </summary>
public class LocalazyFactory(IHttpClientFactory httpClientFactory) : ILocalazyFactory
{
    /// <inheritdoc />
    public ILocalazyService CreateService(string apiKey)
    {
        var config = new LocalazyConfig
        {
            ApiKey = apiKey
        };
        var client = httpClientFactory.CreateClient(nameof(LocalazyFactory));
        client.BaseAddress = new Uri("https://api.localazy.com/");
        var httpWrapper = new HttpWrapper(client, config);
        return new LocalazyService(httpWrapper);
    }
}
