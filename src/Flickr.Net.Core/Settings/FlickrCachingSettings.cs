using FlickrNet.Core.Configuration;

namespace FlickrNet.Core.Settings;
/// <summary>
/// The flickr caching settings.
/// </summary>

public class FlickrCachingSettings
{
    private readonly FlickrConfiguration _config;

    internal FlickrCachingSettings(FlickrConfiguration config)
    {
        _config = config;
    }

    /// <summary>
    /// Gets or sets whether the cache should be disabled. Use only in extreme cases where you are
    /// sure you don't want any caching.
    /// </summary>
    public bool CacheDisabled => _config.CacheDisabled;

    /// <summary>
    /// Override if the cache is disabled for this particular instance of <see cref="Flickr"/>.
    /// </summary>
    public bool InstanceCacheDisabled => _config.CacheDisabled;

    /// <summary>
    /// All GET calls to Flickr are cached by the Flickr.Net API. Set the <see cref="CacheTimeout"/>
    /// to determine how long these calls should be cached (make this as long as possible!)
    /// </summary>
    public TimeSpan CacheTimeout => _config.CacheTimeout;

    /// <summary>
    /// Sets or gets the location to store the Cache files.
    /// </summary>
    public string CacheLocation => _config.CacheLocation;

    /// <summary>
    /// <see cref="CacheSizeLimit"/> is the cache file size in bytes for downloaded pictures. The
    /// default is 50MB (or 50 * 1024 * 1025 in bytes).
    /// </summary>
    public long CacheSizeLimit { get; set; } = 52428800;
}