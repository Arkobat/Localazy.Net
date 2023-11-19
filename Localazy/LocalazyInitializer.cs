using Localazy.Model;
using Localazy.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Localazy;

public static class LocalazyInitializer 
{
    public static IServiceCollection AddLocalazySdk(this IServiceCollection services, string apiKey)
    {
        services
            .AddSingleton(_ => new LocalazyConfig
            {
                ApiKey = apiKey
            })
            .AddHttpClient<HttpWrapper>(c => c.BaseAddress = new Uri("https://api.localazy.com"))
            .Services
            .AddScoped<ILocalazyService, LocalazyService>();

        return services;
    }
}