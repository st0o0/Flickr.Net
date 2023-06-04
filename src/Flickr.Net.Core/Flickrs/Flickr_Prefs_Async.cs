namespace Flickr.Net.Core;

public partial class Flickr : IFlickrPrefs
{
    async Task<ContentType> IFlickrPrefs.GetContentTypeAsync(CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.prefs.getContentType" }
        };

        UnknownResponse result = await GetResponseAsync<UnknownResponse>(parameters, cancellationToken);
        return (ContentType)int.Parse(result.GetAttributeValue("*", "content_type"), System.Globalization.NumberFormatInfo.InvariantInfo);
    }

    async Task<UserGeoPermissions> IFlickrPrefs.GetGeoPermsAsync(CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.prefs.getGeoPerms" }
        };

        return await GetResponseAsync<UserGeoPermissions>(parameters, cancellationToken);
    }

    async Task<HiddenFromSearch> IFlickrPrefs.GetHiddenAsync(CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.prefs.getHidden" }
        };

        UnknownResponse result = await GetResponseAsync<UnknownResponse>(parameters, cancellationToken);
        return (HiddenFromSearch)int.Parse(result.GetAttributeValue("*", "hidden"), System.Globalization.NumberFormatInfo.InvariantInfo);
    }

    async Task<PrivacyFilter> IFlickrPrefs.GetPrivacyAsync(CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.prefs.getPrivacy" }
        };

        UnknownResponse result = await GetResponseAsync<UnknownResponse>(parameters, cancellationToken);
        return (PrivacyFilter)int.Parse(result.GetAttributeValue("*", "privacy"), System.Globalization.NumberFormatInfo.InvariantInfo);
    }

    async Task<SafetyLevel> IFlickrPrefs.GetSafetyLevelAsync(CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.prefs.getSafetyLevel" }
        };

        UnknownResponse result = await GetResponseAsync<UnknownResponse>(parameters, cancellationToken);
        return (SafetyLevel)int.Parse(result.GetAttributeValue("*", "safety_level"), System.Globalization.NumberFormatInfo.InvariantInfo);
    }
}

public interface IFlickrPrefs
{
    /// <summary>
    /// Gets the currently authenticated users default content type.
    /// </summary>
    Task<ContentType> GetContentTypeAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the default privacy level for geographic information attached to the user's photos
    /// and whether or not the user has chosen to use geo-related EXIF information to automatically
    /// geotag their photos.
    /// </summary>
    Task<UserGeoPermissions> GetGeoPermsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the currently authenticated users default hidden from search setting.
    /// </summary>
    Task<HiddenFromSearch> GetHiddenAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the default privacy level preference for the user.
    /// </summary>
    Task<PrivacyFilter> GetPrivacyAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the currently authenticated users default safety level.
    /// </summary>
    Task<SafetyLevel> GetSafetyLevelAsync(CancellationToken cancellationToken = default);
}