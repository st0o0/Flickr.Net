using Flickr.Net.Enums;

namespace Flickr.Net;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrPrefs
{
    async Task<ContentType> IFlickrPrefs.GetContentTypeAsync(CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.prefs.getContentType" }
        };

        var result = await GetResponseAsync<PersonUnknownResponse>(parameters, cancellationToken);

        return (ContentType)int.Parse(result.GetValueOrDefault("content_type", "0"), System.Globalization.NumberFormatInfo.InvariantInfo);
    }

    async Task<GeoPerms> IFlickrPrefs.GetGeoPermsAsync(CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.prefs.getGeoPerms" }
        };

        return await GetResponseAsync<GeoPerms>(parameters, cancellationToken);
    }

    async Task<HiddenFromSearch> IFlickrPrefs.GetHiddenAsync(CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.prefs.getHidden" }
        };

        var result = await GetResponseAsync<PersonUnknownResponse>(parameters, cancellationToken);

        return (HiddenFromSearch)int.Parse(result.GetValueOrDefault("hidden", "0"), System.Globalization.NumberFormatInfo.InvariantInfo);
    }

    async Task<PrivacyFilter> IFlickrPrefs.GetPrivacyAsync(CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.prefs.getPrivacy" }
        };

        var result = await GetResponseAsync<PersonUnknownResponse>(parameters, cancellationToken);

        return (PrivacyFilter)int.Parse(result.GetValueOrDefault("privacy", "0"), System.Globalization.NumberFormatInfo.InvariantInfo);
    }

    async Task<SafetyLevel> IFlickrPrefs.GetSafetyLevelAsync(CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.prefs.getSafetyLevel" }
        };

        var result = await GetResponseAsync<UnknownResponse>(parameters, cancellationToken);

        return (SafetyLevel)int.Parse(result.GetValueOrDefault("safety_level", "0"), System.Globalization.NumberFormatInfo.InvariantInfo);
    }
}

/// <summary>
/// The flickr prefs.
/// </summary>
public interface IFlickrPrefs
{
    /// <summary>
    /// Gets the currently authenticated users default content type.
    /// </summary>
    /// <param name="cancellationToken"></param>
    Task<ContentType> GetContentTypeAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the default privacy level for geographic information attached to the user's photos
    /// and whether or not the user has chosen to use geo-related EXIF information to automatically
    /// geotag their photos.
    /// </summary>
    /// <param name="cancellationToken"></param>
    Task<GeoPerms> GetGeoPermsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the currently authenticated users default hidden from search setting.
    /// </summary>
    /// <param name="cancellationToken"></param>
    Task<HiddenFromSearch> GetHiddenAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the default privacy level preference for the user.
    /// </summary>
    /// <param name="cancellationToken"></param>
    Task<PrivacyFilter> GetPrivacyAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the currently authenticated users default safety level.
    /// </summary>
    /// <param name="cancellationToken"></param>
    Task<SafetyLevel> GetSafetyLevelAsync(CancellationToken cancellationToken = default);
}