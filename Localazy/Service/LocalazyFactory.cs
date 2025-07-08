using Localazy.Model;

namespace Localazy.Service;

public class LocalazyFactory : ILocalazyFactory
{
    private readonly IHttpClientFactory _httpClientFactory;
    
    public LocalazyFactory(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    public ILocalazyService CreateService(string apiKey)
    {
        var config = new LocalazyConfig
        {
            ApiKey = apiKey
        };
        var client = _httpClientFactory.CreateClient(nameof(LocalazyFactory));
        client.BaseAddress = new Uri("https://api.localazy.com/");
        var httpWrapper = new HttpWrapper(client, config);
        return new LocalazyService(httpWrapper);
    }
}