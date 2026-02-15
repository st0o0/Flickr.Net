using System.Globalization;
using Flickr.Net.Enums;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals.Extensions;

namespace Flickr.Net;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrGroupsPools
{
    async Task IFlickrGroupsPools.AddAsync(string photoId, string groupId, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.pools.add" },
            { "photo_id", photoId },
            { "group_id", groupId }
        };

        await GetResponseAsync(parameters, cancellationToken);
    }

    async Task<FlickrContextResult<NextPhoto, PrevPhoto>> IFlickrGroupsPools.GetContextAsync(string photoId, string groupId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.pools.getContext" },
            { "photo_id", photoId },
            { "group_id", groupId }
        };

        return await GetContextResponseAsync<NextPhoto, PrevPhoto>(parameters, cancellationToken);
    }

    async Task<Groups> IFlickrGroupsPools.GetGroupsAsync(int page, int perPage, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.pools.getGroups" }
        };

        parameters.AppendIf("per_page", perPage, x => x > 0, x => x.ToString(NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("page", page, x => x > 0, x => x.ToString(NumberFormatInfo.InvariantInfo));

        return await GetResponseAsync<Groups>(parameters, cancellationToken);
    }

    async Task<PagedPhotos> IFlickrGroupsPools.GetPhotosAsync(string groupId, string tags, string userId, PhotoSearchExtras extras, int page, int perPage, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.pools.getPhotos" },
            { "group_id", groupId }
        };

        parameters.AppendIf("tags", tags, x => x != null && x.Length > 0, x => x);

        parameters.AppendIf("per_page", perPage, x => x > 0, x => x.ToString(NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("page", page, x => x > 0, x => x.ToString(NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("user_id", userId, x => x != null && x.Length > 0, x => x.ToString(NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("extras", extras, x => x != PhotoSearchExtras.None, x => x.ToFlickrString());

        return await GetResponseAsync<PagedPhotos>(parameters, cancellationToken);
    }

    async Task IFlickrGroupsPools.RemoveAsync(string photoId, string groupId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.pools.remove" },
            { "photo_id", photoId },
            { "group_id", groupId }
        };

        await GetResponseAsync(parameters, cancellationToken);
    }
}

/// <summary>
/// The flickr groups pools.
/// </summary>
public interface IFlickrGroupsPools
{
    /// <summary>
    /// Adds a photo to a pool you have permission to add photos to.
    /// </summary>
    /// <param name="photoId">The id of one of your photos to be added.</param>
    /// <param name="groupId">The id of a group you are a member of.</param>
    /// <param name="cancellationToken"></param>
    Task AddAsync(string photoId, string groupId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the context for a photo from within a group. This provides the id and thumbnail url for
    /// the next and previous photos in the group.
    /// </summary>
    /// <param name="photoId">The Photo ID for the photo you want the context for.</param>
    /// <param name="groupId">The group ID for the group you want the context to be relevant to.</param>
    /// <param name="cancellationToken"></param>
    Task<FlickrContextResult<NextPhoto, PrevPhoto>> GetContextAsync(string photoId, string groupId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a list of groups to which you can add photos.
    /// </summary>
    /// <param name="page">The page of the results to return.</param>
    /// <param name="perPage">The number of groups to list per page.</param>
    /// <param name="cancellationToken"></param>
    Task<Groups> GetGroupsAsync(int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a list of photos for a given group.
    /// </summary>
    /// <param name="groupId">The group ID for the group.</param>
    /// <param name="tags">
    /// Space seperated list of tags that photos returned must have. Currently only supports 1 tag
    /// at a time.
    /// </param>
    /// <param name="userId">The group member to return photos for.</param>
    /// <param name="extras">
    /// The <see cref="PhotoSearchExtras"/> specifying which extras to return. All other overloads
    /// default to returning all extras.
    /// </param>
    /// <param name="page">The page to return.</param>
    /// <param name="perPage">The number of photos per page.</param>
    /// <param name="cancellationToken"></param>
    Task<PagedPhotos> GetPhotosAsync(string groupId, string tags = null, string userId = null, PhotoSearchExtras extras = PhotoSearchExtras.None, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove a picture from a group.
    /// </summary>
    /// <param name="photoId">The id of one of your pictures you wish to remove.</param>
    /// <param name="groupId">The id of the group to remove the picture from.</param>
    /// <param name="cancellationToken"></param>
    Task RemoveAsync(string photoId, string groupId, CancellationToken cancellationToken = default);
}