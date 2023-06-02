using Flickr.Net.Core.Entities;
using Flickr.Net.Core.Enums;

namespace Flickr.Net.Core;

// TODO:
public partial class Flickr
{
    /// <summary>
    /// Gets the currently authenticated users default content type.
    /// </summary>
    public async Task<ContentType> PrefsGetContentTypeAsync(CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.prefs.getContentType" }
        };

        UnknownResponse result = await GetResponseAsync<UnknownResponse>(parameters, cancellationToken);
        return (ContentType)int.Parse(result.GetAttributeValue("*", "content_type"), System.Globalization.NumberFormatInfo.InvariantInfo);
    }

    /// <summary>
    /// Returns the default privacy level for geographic information attached to the user's photos and whether
    /// or not the user has chosen to use geo-related EXIF information to automatically geotag their photos.
    /// </summary>
    public async Task<UserGeoPermissions> PrefsGetGeoPermsAsync(CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.prefs.getGeoPerms" }
        };

        return await GetResponseAsync<UserGeoPermissions>(parameters, cancellationToken);
    }

    /// <summary>
    /// Gets the currently authenticated users default hidden from search setting.
    /// </summary>
    public async Task<HiddenFromSearch> PrefsGetHiddenAsync(CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.prefs.getHidden" }
        };

        UnknownResponse result = await GetResponseAsync<UnknownResponse>(parameters, cancellationToken);
        return (HiddenFromSearch)int.Parse(result.GetAttributeValue("*", "hidden"), System.Globalization.NumberFormatInfo.InvariantInfo);
    }

    /// <summary>
    /// Returns the default privacy level preference for the user.
    /// </summary>
    public async Task<PrivacyFilter> PrefsGetPrivacyAsync(CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.prefs.getPrivacy" }
        };

        UnknownResponse result = await GetResponseAsync<UnknownResponse>(parameters, cancellationToken);
        return (PrivacyFilter)int.Parse(result.GetAttributeValue("*", "privacy"), System.Globalization.NumberFormatInfo.InvariantInfo);
    }

    /// <summary>
    /// Gets the currently authenticated users default safety level.
    /// </summary>
    public async Task<SafetyLevel> PrefsGetSafetyLevelAsync(CancellationToken cancellationToken = default)
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