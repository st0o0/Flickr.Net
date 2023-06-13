namespace Flickr.Net.Core.Configuration;

/// <summary>
/// The flickr configuration.
/// </summary>
public class FlickrConfiguration
{
    /// <summary>
    /// Gets or sets the api key.
    /// </summary>
    public string ApiKey { get; set; }

    /// <summary>
    /// Gets or sets the shared secret.
    /// </summary>
    public string SharedSecret { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether cache disabled.
    /// </summary>
    public bool CacheDisabled { get; set; }

    /// <summary>
    /// Gets or sets the cache location.
    /// </summary>
    public string CacheLocation { get; set; }

    /// <summary>
    /// Gets or sets the cache size.
    /// </summary>
    public int CacheSize { get; set; } = 0;

    /// <summary>
    /// Gets or sets the cache timeout.
    /// </summary>
    public TimeSpan CacheTimeout { get; set; } = TimeSpan.MinValue;
}