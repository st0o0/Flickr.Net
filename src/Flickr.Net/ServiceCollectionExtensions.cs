using Flickr.Net.Configuration;
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.DependencyInjection;

namespace Flickr.Net;

/// <summary>
/// Extension methods for registering Flickr.Net services with dependency injection.
/// </summary>
public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers <see cref="IFlickrClient"/> with a typed <see cref="HttpClient"/> and the given configuration.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configure">A delegate to configure <see cref="FlickrConfiguration"/>.</param>
    public static IServiceCollection AddFlickr(this IServiceCollection services, Action<FlickrConfiguration> configure)
    {
        services.Configure(configure);
        services.AddHttpClient<IFlickrClient, FlickrClient>();
        return services;
    }

    /// <summary>
    /// Registers <see cref="HybridCache"/> to enable response caching for <see cref="IFlickrClient"/>.
    /// </summary>
    /// <param name="services">The service collection.</param>
    /// <param name="configure">An optional delegate to configure <see cref="HybridCacheOptions"/>.</param>
    public static IServiceCollection AddFlickrCaching(this IServiceCollection services, Action<HybridCacheOptions>? configure = null)
    {
        services.AddHybridCache(options => configure?.Invoke(options));
        return services;
    }
}
