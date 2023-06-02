using Flickr.Net.Core.Entities;
using Flickr.Net.Core.Entities.Collections;
using Flickr.Net.Core.Enums;
using Flickr.Net.Core.Internals;
using System.Collections.ObjectModel;

namespace Flickr.Net.Core;

// TODO:
public partial class Flickr
{
    /// <summary>
    /// Get the tag list for a given photo.
    /// </summary>
    /// <param name="photoId">The id of the photo to return tags for.</param>
    public async Task<Collection<PhotoInfoTag>> TagsGetListPhotoAsync(string photoId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.tags.getListPhoto" },
            { "api_key", ApiKey },
            { "photo_id", photoId }
        };

        PhotoInfo result = await GetResponseAsync<PhotoInfo>(parameters, cancellationToken);
        return result.Tags;
    }

    /// <summary>
    /// Get the tag list for a given user (or the currently logged in user).
    /// </summary>
    public async Task<TagCollection> TagsGetListUserAsync(CancellationToken cancellationToken = default)
    {
        return await TagsGetListUserAsync(null, cancellationToken);
    }

    /// <summary>
    /// Get the tag list for a given user (or the currently logged in user).
    /// </summary>
    /// <param name="userId">The NSID of the user to fetch the tag list for. If this argument is not specified, the currently logged in user (if any) is assumed.</param>
    public async Task<TagCollection> TagsGetListUserAsync(string userId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.tags.getListUser" }
        };
        if (userId != null && userId.Length > 0)
        {
            parameters.Add("user_id", userId);
        }

        return await GetResponseAsync<TagCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Get the popular tags for a given user (or the currently logged in user).
    /// </summary>
    public async Task<TagCollection> TagsGetListUserPopularAsync(CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        return await TagsGetListUserPopularAsync(null, 0, cancellationToken);
    }

    /// <summary>
    /// Get the popular tags for a given user (or the currently logged in user).
    /// </summary>
    /// <param name="count">Number of popular tags to return. defaults to 10 when this argument is not present.</param>
    public async Task<TagCollection> TagsGetListUserPopularAsync(int count, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        return await TagsGetListUserPopularAsync(null, count, cancellationToken);
    }

    /// <summary>
    /// Get the popular tags for a given user (or the currently logged in user).
    /// </summary>
    /// <param name="userId">The NSID of the user to fetch the tag list for. If this argument is not specified, the currently logged in user (if any) is assumed.</param>
    public async Task<TagCollection> TagsGetListUserPopularAsync(string userId, CancellationToken cancellationToken = default)
    {
        return await TagsGetListUserPopularAsync(userId, 0, cancellationToken);
    }

    /// <summary>
    /// Get the popular tags for a given user (or the currently logged in user).
    /// </summary>
    /// <param name="userId">The NSID of the user to fetch the tag list for. If this argument is not specified, the currently logged in user (if any) is assumed.</param>
    /// <param name="count">Number of popular tags to return. defaults to 10 when this argument is not present.</param>
    public async Task<TagCollection> TagsGetListUserPopularAsync(string userId, int count, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.tags.getListUserPopular" }
        };
        if (userId != null)
        {
            parameters.Add("user_id", userId);
        }

        if (count > 0)
        {
            parameters.Add("count", count.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<TagCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Gets a list of 'cleaned' tags and the raw values for those tags.
    /// </summary>
    public async Task<RawTagCollection> TagsGetListUserRawAsync(CancellationToken cancellationToken = default)
    {
        return await TagsGetListUserRawAsync(null, cancellationToken);
    }

    /// <summary>
    /// Gets a list of 'cleaned' tags and the raw values for a specific tag.
    /// </summary>
    /// <param name="tag">The tag to return the raw version of.</param>
    public async Task<RawTagCollection> TagsGetListUserRawAsync(string tag, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.tags.getListUserRaw" }
        };
        if (tag != null && tag.Length > 0)
        {
            parameters.Add("tag", tag);
        }

        return await GetResponseAsync<RawTagCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Returns a collection of the most frequently used tags for the authenticated user.
    /// </summary>
    /// <returns></returns>
    public async Task<TagCollection> TagsGetMostFrequentlyUsedAsync(CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.tags.getMostFrequentlyUsed" }
        };

        return await GetResponseAsync<TagCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Returns a list of tags 'related' to the given tag, based on clustered usage analysis.
    /// </summary>
    /// <param name="tag">The tag to fetch related tags for.</param>
    public async Task<TagCollection> TagsGetRelatedAsync(string tag, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.tags.getRelated" },
            { "api_key", ApiKey },
            { "tag", tag }
        };

        return await GetResponseAsync<TagCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Gives you a list of tag clusters for the given tag.
    /// </summary>
    /// <param name="tag">The tag to fetch clusters for.</param>
    public async Task<ClusterCollection> TagsGetClustersAsync(string tag, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.tags.getClusters" },
            { "tag", tag }
        };

        return await GetResponseAsync<ClusterCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Returns the first 24 photos for a given tag cluster.
    /// </summary>
    /// <param name="cluster">The <see cref="Cluster"/> instance to return the photos for.</param>
    public async Task<PhotoCollection> TagsGetClusterPhotosAsync(Cluster cluster, CancellationToken cancellationToken = default)
    {
        return await TagsGetClusterPhotosAsync(cluster.SourceTag, cluster.ClusterId, PhotoSearchExtras.None, cancellationToken);
    }

    /// <summary>
    /// Returns the first 24 photos for a given tag cluster.
    /// </summary>
    /// <param name="cluster">The <see cref="Cluster"/> instance to return the photos for.</param>
    /// <param name="extras">Extra information to return with each photo.</param>
    public async Task<PhotoCollection> TagsGetClusterPhotosAsync(Cluster cluster, PhotoSearchExtras extras, CancellationToken cancellationToken = default)
    {
        return await TagsGetClusterPhotosAsync(cluster.SourceTag, cluster.ClusterId, extras, cancellationToken);
    }

    /// <summary>
    /// Returns the first 24 photos for a given tag cluster.
    /// </summary>
    /// <param name="tag">The tag whose cluster photos you want to return.</param>
    /// <param name="clusterId">The cluster id for the cluster you want to return the photos. This is the first three subtags of the tag cluster appended with hyphens ('-').</param>
    /// <param name="extras">Extra information to return with each photo.</param>
    public async Task<PhotoCollection> TagsGetClusterPhotosAsync(string tag, string clusterId, PhotoSearchExtras extras, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.tags.getClusterPhotos" },
            { "tag", tag },
            { "cluster_id", clusterId }
        };
        if (extras != PhotoSearchExtras.None)
        {
            parameters.Add("extras", UtilityMethods.ExtrasToString(extras));
        }

        return await GetResponseAsync<PhotoCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Returns a list of hot tags for the given period.
    /// </summary>
    public async Task<HotTagCollection> TagsGetHotListAsync(CancellationToken cancellationToken = default)
    {
        return await TagsGetHotListAsync(null, 0, cancellationToken);
    }

    /// <summary>
    /// Returns a list of hot tags for the given period.
    /// </summary>
    /// <param name="period">The period for which to fetch hot tags. Valid values are day and week (defaults to day).</param>
    /// <param name="count">The number of tags to return. Defaults to 20. Maximum allowed value is 200.</param>
    public async Task<HotTagCollection> TagsGetHotListAsync(string period, int count, CancellationToken cancellationToken = default)
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

        if (count > 0)
        {
            parameters.Add("count", count.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<HotTagCollection>(parameters, cancellationToken);
    }
}