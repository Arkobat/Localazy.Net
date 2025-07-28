using Localazy.Model;
using Localazy.Service;
using Microsoft.Extensions.DependencyInjection;

namespace Localazy;

/// <summary>
/// Provides extension methods for configuring Localazy SDK services in the dependency injection container.
/// </summary>
public static class LocalazyInitializer 
{
    /// <summary>
    /// Adds Localazy SDK services to the specified service collection.
    /// </summary>
    /// <param name="services">The <see cref="IServiceCollection"/> to add services to.</param>
    /// <param name="apiKey">The Localazy API key for authentication.</param>
    /// <returns>The <see cref="IServiceCollection"/> so that additional calls can be chained.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="services"/> or <paramref name="apiKey"/> is null.</exception>
    /// <example>
    /// <code>
    /// services.AddLocalazySdk("your-api-key-here");
    /// </code>
    /// </example>
    public static IServiceCollection AddLocalazySdk(this IServiceCollection services, string apiKey)
    {
        services
            .AddSingleton(_ => new LocalazyConfig
            {
                ApiKey = apiKey
            })
            .AddHttpClient<HttpWrapper>(c => c.BaseAddress = new Uri("https://api.localazy.com"))
            .Services
            .AddScoped<ILocalazyService, LocalazyService>()
            .AddScoped<ILocalazyFactory, LocalazyFactory>();

        return services;
    }
}