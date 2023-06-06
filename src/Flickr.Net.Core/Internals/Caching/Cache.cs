using FlickrNet.Core.Settings;
using System.Diagnostics.CodeAnalysis;

namespace Flickr.Net.Core.Internals.Caching;

/// <summary>
/// Internal Cache class
/// </summary>
public class Cache
{
    private static PersistentCache responses;
    private static readonly object lockObject = new();

    private readonly FlickrCachingSettings _settings;

    public Cache(FlickrCachingSettings settings)
    {
        _settings = settings;
    }

    /// <summary>
    /// A static object containing the list of cached responses from Flickr.
    /// </summary>
    public PersistentCache Responses
    {
        get
        {
            lock (lockObject)
            {
                responses ??= new PersistentCache(Path.Combine(CacheLocation, "responseCache.dat"), new ResponseCacheItemPersister());

                return responses;
            }
        }
    }

    /// <summary>
    /// Returns weither of not the cache is currently disabled.
    /// </summary>
    public bool CacheDisabled => _settings.CacheDisabled;

    /// <summary>
    /// Returns the currently set location for the cache.
    /// </summary>
    [DisallowNull]
    public string CacheLocation => _settings.CacheLocation;

    internal long CacheSizeLimit => _settings.CacheSizeLimit; 

    /// <summary>
    /// The default timeout for cachable objects within the cache.
    /// </summary>
    public TimeSpan CacheTimeout => _settings.CacheTimeout;

    /// <summary>
    /// Remove a specific URL from the cache.
    /// </summary>
    /// <param name="url"></param>
    public void FlushCache(Uri url)
    {
        Responses[url.AbsoluteUri] = null;
    }

    /// <summary>
    /// Clears all responses from the cache.
    /// </summary>
    public void FlushCache()
    {
        Responses.Flush();
    }
}