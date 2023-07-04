using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals.Extensions;

namespace Flickr.Net.Core;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrTags
{
    async Task<ClusterPhotos> IFlickrTags.GetClusterPhotosAsync(string clusterId, string sourceTag, PhotoSearchExtras extras, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.tags.getClusterPhotos" },
            { "tag", sourceTag },
            { "cluster_id", clusterId }
        };

        if (extras != PhotoSearchExtras.None)
        {
            parameters.Add("extras", extras.ToFlickrString());
        }

        return await GetResponseAsync<ClusterPhotos>(parameters, cancellationToken);
    }

    async Task<Clusters> IFlickrTags.GetClustersAsync(string tag, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.tags.getClusters" },
            { "tag", tag }
        };

        return await GetResponseAsync<Clusters>(parameters, cancellationToken);
    }

    async Task<FlickrStatsResult<Hottags>> IFlickrTags.GetHotListAsync(string period, int? count, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrEmpty(period) && period != "day" && period != "week")
        {
            throw new ArgumentException("Period must be either 'day' or 'week'.", nameof(period));
        }

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.tags.getHotList" }
        };

        if (!string.IsNullOrEmpty(period))
        {
            parameters.Add("period", period);
        }

        if (count.HasValue && count > 0)
        {
            parameters.Add("count", count.Value.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetGenericResponseAsync<FlickrStatsResult<Hottags>>(parameters, cancellationToken);
    }

    async Task<PhotoTags> IFlickrTags.GetListPhotoAsync(string photoId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.tags.getListPhoto" },
            { "photo_id", photoId }
        };

        return await GetResponseAsync<PhotoTags>(parameters, cancellationToken);
    }

    async Task<Tags> IFlickrTags.GetListUserAsync(string userId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.tags.getListUser" }
        };

        if (userId != null && userId.Length > 0)
        {
            parameters.Add("user_id", userId);
        }

        return await GetResponseAsync<Tags>(parameters, cancellationToken);
    }

    async Task<UserTags> IFlickrTags.GetListUserPopularAsync(string userId, int? count, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.tags.getListUserPopular" }
        };

        if (userId != null)
        {
            parameters.Add("user_id", userId);
        }

        if (count.HasValue && count > 0)
        {
            parameters.Add("count", count.Value.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<UserTags>(parameters, cancellationToken);
    }

    async Task<UserTags> IFlickrTags.GetMostFrequentlyUsedAsync(CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.tags.getMostFrequentlyUsed" }
        };

        return await GetResponseAsync<UserTags>(parameters, cancellationToken);
    }

    async Task<Tags> IFlickrTags.GetRelatedAsync(string tag, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.tags.getRelated" },
            { "tag", tag }
        };

        return await GetResponseAsync<Tags>(parameters, cancellationToken);
    }
}

/// <summary>
/// The flickr tags.
/// </summary>
public interface IFlickrTags
{
    /// <summary>
    /// Returns the first 24 photos for a given tag cluster.
    /// </summary>
    /// <param name="clusterId">The instance to return the photos for.</param>
    /// <param name="sourceTag"></param>
    /// <param name="extras">Extra information to return with each photo.</param>
    /// <param name="cancellationToken"></param>
    Task<ClusterPhotos> GetClusterPhotosAsync(string clusterId, string sourceTag, PhotoSearchExtras extras, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gives you a list of tag clusters for the given tag.
    /// </summary>
    /// <param name="tag">The tag to fetch clusters for.</param>
    /// <param name="cancellationToken"></param>
    Task<Clusters> GetClustersAsync(string tag, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a list of hot tags for the given period.
    /// </summary>
    /// <param name="period">
    /// The period for which to fetch hot tags. Valid values are day and week (defaults to day).
    /// </param>
    /// <param name="count">
    /// The number of tags to return. Defaults to 20. Maximum allowed value is 200.
    /// </param>
    /// <param name="cancellationToken"></param>
    Task<FlickrStatsResult<Hottags>> GetHotListAsync(string period = null, int? count = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get the tag list for a given photo.
    /// </summary>
    /// <param name="photoId">The id of the photo to return tags for.</param>
    /// <param name="cancellationToken"></param>
    Task<PhotoTags> GetListPhotoAsync(string photoId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get the tag list for a given user (or the currently logged in user).
    /// </summary>
    /// <param name="userId">
    /// The NSID of the user to fetch the tag list for. If this argument is not specified, the
    /// currently logged in user (if any) is assumed.
    /// </param>
    /// <param name="cancellationToken"></param>
    Task<Tags> GetListUserAsync(string userId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get the popular tags for a given user (or the currently logged in user).
    /// </summary>
    /// <param name="userId">
    /// The NSID of the user to fetch the tag list for. If this argument is not specified, the
    /// currently logged in user (if any) is assumed.
    /// </param>
    /// <param name="count">
    /// Number of popular tags to return. defaults to 10 when this argument is not present.
    /// </param>
    /// <param name="cancellationToken"></param>
    Task<UserTags> GetListUserPopularAsync(string userId = null, int? count = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a collection of the most frequently used tags for the authenticated user.
    /// </summary>
    /// <returns></returns>
    Task<UserTags> GetMostFrequentlyUsedAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a list of tags 'related' to the given tag, based on clustered usage analysis.
    /// </summary>
    /// <param name="tag">The tag to fetch related tags for.</param>
    /// <param name="cancellationToken"></param>
    Task<Tags> GetRelatedAsync(string tag, CancellationToken cancellationToken = default);
}