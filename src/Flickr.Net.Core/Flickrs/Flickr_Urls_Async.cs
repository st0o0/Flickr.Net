using Flickr.Net.Core.Entities;

namespace Flickr.Net.Core;

public partial class Flickr : IFlickrUrls
{
    async Task<string> IFlickrUrls.GetGroupAsync(string groupId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.urls.getGroup" },
            { "group_id", groupId }
        };

        UnknownResponse result = await GetResponseAsync<UnknownResponse>(parameters, cancellationToken);
        return result.GetAttributeValue("*", "url");
    }

    async Task<string> IFlickrUrls.GetUserPhotosAsync(string userId, CancellationToken cancellationToken)
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

    async Task<string> IFlickrUrls.GetUserProfileAsync(string userId, CancellationToken cancellationToken)
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

    async Task<Gallery> IFlickrUrls.LookupGalleryAsync(string url, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.urls.lookupGallery" },
            { "url", url }
        };

        return await GetResponseAsync<Gallery>(parameters, cancellationToken);
    }

    async Task<string> IFlickrUrls.LookupGroupAsync(string urlToFind, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.urls.lookupGroup" },
            { "url", urlToFind }
        };

        UnknownResponse result = await GetResponseAsync<UnknownResponse>(parameters, cancellationToken);
        return result.GetAttributeValue("*", "id");
    }

    async Task<FoundUser> IFlickrUrls.LookupUserAsync(string urlToFind, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.urls.lookupUser" },
            { "url", urlToFind }
        };

        return await GetResponseAsync<FoundUser>(parameters, cancellationToken);
    }
}

public interface IFlickrUrls
{
    /// <summary>
    /// Returns the url to a group's page.
    /// </summary>
    /// <param name="groupId">The NSID of the group to fetch the url for.</param>
    Task<string> GetGroupAsync(string groupId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the url to a user's photos.
    /// </summary>
    /// <param name="userId">The NSID of the user to fetch the url for. If omitted, the calling user is assumed.</param>
    Task<string> GetUserPhotosAsync(string userId = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the url to a user's profile.
    /// </summary>
    /// <param name="userId">The NSID of the user to fetch the url for. If omitted, the calling user is assumed.</param>
    /// <param name="callback">Callback method to call upon return of the response from Flickr.</param>
    Task<string> GetUserProfileAsync(string userId = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns gallery info, by url.
    /// </summary>
    /// <param name="url">The gallery's URL.</param>
    Task<Gallery> LookupGalleryAsync(string url, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a group NSID, given the url to a group's page or photo pool.
    /// </summary>
    /// <param name="urlToFind">The url to the group's page or photo pool.</param>
    Task<string> LookupGroupAsync(string urlToFind, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a user NSID, given the url to a user's photos or profile.
    /// </summary>
    /// <param name="urlToFind">Thr url to the user's profile or photos page.</param>
    Task<FoundUser> LookupUserAsync(string urlToFind, CancellationToken cancellationToken = default);
}