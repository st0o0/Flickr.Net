using Flickr.Net.Core.Entities;

namespace Flickr.Net.Core;

// TODO:
public partial class Flickr
{
    /// <summary>
    /// Returns the url to a group's page.
    /// </summary>
    /// <param name="groupId">The NSID of the group to fetch the url for.</param>
    public async Task<string> UrlsGetGroupAsync(string groupId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.urls.getGroup" },
            { "group_id", groupId }
        };

        UnknownResponse result = await GetResponseAsync<UnknownResponse>(parameters, cancellationToken);
        return result.GetAttributeValue("*", "url");
    }

    /// <summary>
    /// Returns the url to a user's photos.
    /// </summary>
    /// <returns>An instance of the <see cref="Uri"/> class containing the URL for the users photos.</returns>
    public async Task<string> UrlsGetUserPhotosAsync(CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        return await UrlsGetUserPhotosAsync(null, cancellationToken);
    }

    /// <summary>
    /// Returns the url to a user's photos.
    /// </summary>
    /// <param name="userId">The NSID of the user to fetch the url for. If omitted, the calling user is assumed.</param>
    public async Task<string> UrlsGetUserPhotosAsync(string userId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.urls.getUserPhotos" }
        };
        if (userId != null && userId.Length > 0)
        {
            parameters.Add("user_id", userId);
        }

        UnknownResponse result = await GetResponseAsync<UnknownResponse>(parameters, cancellationToken);
        return result.GetAttributeValue("*", "url");
    }

    /// <summary>
    /// Returns the url to a user's profile.
    /// </summary>
    public async Task<string> UrlsGetUserProfileAsync(CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        return await UrlsGetUserProfileAsync(null, cancellationToken);
    }

    /// <summary>
    /// Returns the url to a user's profile.
    /// </summary>
    /// <param name="userId">The NSID of the user to fetch the url for. If omitted, the calling user is assumed.</param>
    /// <param name="callback">Callback method to call upon return of the response from Flickr.</param>
    public async Task<string> UrlsGetUserProfileAsync(string userId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.urls.getUserProfile" }
        };
        if (userId != null && userId.Length > 0)
        {
            parameters.Add("user_id", userId);
        }

        UnknownResponse result = await GetResponseAsync<UnknownResponse>(parameters, cancellationToken);
        return result.GetAttributeValue("*", "url");
    }

    /// <summary>
    /// Returns gallery info, by url.
    /// </summary>
    /// <param name="url">The gallery's URL.</param>
    public async Task<Gallery> UrlsLookupGalleryAsync(string url, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.urls.lookupGallery" },
            { "api_key", ApiKey },
            { "url", url }
        };

        return await GetResponseAsync<Gallery>(parameters, cancellationToken);
    }

    /// <summary>
    /// Returns a group NSID, given the url to a group's page or photo pool.
    /// </summary>
    /// <param name="urlToFind">The url to the group's page or photo pool.</param>
    public async Task<string> UrlsLookupGroupAsync(string urlToFind, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.urls.lookupGroup" },
            { "api_key", ApiKey },
            { "url", urlToFind }
        };

        UnknownResponse result = await GetResponseAsync<UnknownResponse>(parameters, cancellationToken);
        return result.GetAttributeValue("*", "id");
    }

    /// <summary>
    /// Returns a user NSID, given the url to a user's photos or profile.
    /// </summary>
    /// <param name="urlToFind">Thr url to the user's profile or photos page.</param>
    public async Task<FoundUser> UrlsLookupUserAsync(string urlToFind, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.urls.lookupUser" },
            { "api_key", ApiKey },
            { "url", urlToFind }
        };

        return await GetResponseAsync<FoundUser>(parameters, cancellationToken);
    }
}