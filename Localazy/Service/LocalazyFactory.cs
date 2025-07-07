using Localazy.Model;

namespace Localazy.Service;

public class LocalazyFactory : ILocalazyFactory
{
    public ILocalazyService CreateService(string apiKey)
    {
        var config = new LocalazyConfig
        {
            ApiKey = apiKey
        };
        var httpWrapper = new HttpWrapper(new HttpClient(), config);
        return new LocalazyService(httpWrapper);
    }
}