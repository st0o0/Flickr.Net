using FlickrNet.Core.Configuration;

namespace FlickrNet.Core.Settings;

/// <summary>
/// The flickr settings.
/// </summary>
public class FlickrSettings
{
    private readonly FlickrConfiguration _config;

    internal FlickrSettings(FlickrConfiguration config)
    {
        _config = config;
    }

    /// <summary>
    /// Get or set the API Key to be used by all calls. API key is mandatory for all calls to Flickr.
    /// </summary>
    public string ApiKey => _config.ApiKey;

    /// <summary>
    /// API shared secret is required for all calls that require signing, which includes all methods
    /// that require authentication, as well as the actual flickr.auth.* calls.
    /// </summary>
    public string ApiSecret => _config.SharedSecret;

    /// <summary>
    /// OAuth Access Token. Needed for authenticated access using OAuth to Flickr.
    /// </summary>
    public string OAuthAccessToken { get; set; }

    /// <summary>
    /// OAuth Access Token Secret. Needed for authenticated access using OAuth to Flickr.
    /// </summary>
    public string OAuthAccessTokenSecret { get; set; }

    /// <summary>
    /// Internal timeout for all web requests in milliseconds. Defaults to 30 seconds.
    /// </summary>
    public int HttpTimeout { get; set; } = 3600000;
}