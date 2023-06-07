namespace Flickr.Net.Core;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrGroups
{
    IFlickrGroupsDiscuss IFlickrGroups.Discuss => this;

    async Task<GroupFullInfo> IFlickrGroups.GetInfoAsync(string groupId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.getInfo" },
            { "group_id", groupId }
        };

        return await GetResponseAsync<GroupFullInfo>(parameters, cancellationToken);
    }

    async Task IFlickrGroups.JoinAsync(string groupId, bool acceptsRules, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.join" },
            { "group_id", groupId }
        };

        if (acceptsRules)
        {
            parameters.Add("accepts_rules", "1");
        }

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    async Task IFlickrGroups.JoinRequestAsync(string groupId, string message, bool acceptRules, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.joinRequest" },
            { "group_id", groupId },
            { "message", message }
        };

        if (acceptRules)
        {
            parameters.Add("accept_rules", "1");
        }

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    async Task IFlickrGroups.LeaveAsync(string groupId, bool deletePhotos, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.leave" },
            { "group_id", groupId }
        };

        if (deletePhotos)
        {
            parameters.Add("delete_photos", "1");
        }

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    async Task<GroupSearchResultCollection> IFlickrGroups.SearchAsync(string text, int page, int perPage, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.search" },
            { "text", text }
        };

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<GroupSearchResultCollection>(parameters, cancellationToken);
    }

    async Task<MemberCollection> IFlickrGroups.MembersGetListAsync(string groupId, MemberTypes memberTypes, int page, int perPage, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.members.getList" },
        };

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (memberTypes != MemberTypes.None)
        {
            parameters.Add("membertypes", UtilityMethods.MemberTypeToString(memberTypes));
        }

        parameters.Add("group_id", groupId);

        return await GetResponseAsync<MemberCollection>(parameters, cancellationToken);
    }

    async Task IFlickrGroups.PoolsAddAsync(string photoId, string groupId, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.pools.add" },
            { "photo_id", photoId },
            { "group_id", groupId }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    async Task<Context> IFlickrGroups.PoolsGetContextAsync(string photoId, string groupId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.pools.getContext" },
            { "photo_id", photoId },
            { "group_id", groupId }
        };

        return await GetResponseAsync<Context>(parameters, cancellationToken);
    }

    async Task<MemberGroupInfoCollection> IFlickrGroups.PoolsGetGroupsAsync(int page, int perPage, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.pools.getGroups" }
        };

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<MemberGroupInfoCollection>(parameters, cancellationToken);
    }

    async Task<PhotoCollection> IFlickrGroups.PoolsGetPhotosAsync(string groupId, string tags, string userId, PhotoSearchExtras extras, int page, int perPage, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.pools.getPhotos" },
            { "group_id", groupId }
        };

        if (tags != null && tags.Length > 0)
        {
            parameters.Add("tags", tags);
        }

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (userId != null && userId.Length > 0)
        {
            parameters.Add("user_id", userId);
        }

        if (extras != PhotoSearchExtras.None)
        {
            parameters.Add("extras", UtilityMethods.ExtrasToString(extras));
        }

        return await GetResponseAsync<PhotoCollection>(parameters, cancellationToken);
    }

    async Task IFlickrGroups.PoolsRemoveAsync(string photoId, string groupId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.pools.remove" },
            { "photo_id", photoId },
            { "group_id", groupId }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }
}

/// <summary>
/// The flickr groups.
/// </summary>
public interface IFlickrGroups
{
    IFlickrGroupsDiscuss Discuss { get; }

    /// <summary>
    /// Returns a <see cref="GroupFullInfo"/> object containing details about a group.
    /// </summary>
    /// <param name="groupId">The id of the group to return.</param>
    /// <param name="cancellationToken"></param>
    Task<GroupFullInfo> GetInfoAsync(string groupId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Specify a group for the authenticated user to join.
    /// </summary>
    /// <param name="groupId">The group id of the group to join.</param>
    /// <param name="acceptsRules">Specify true to signify that the user accepts the groups rules.</param>
    /// <param name="cancellationToken"></param>
    Task JoinAsync(string groupId, bool acceptsRules = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sends a request to the group admins to join an invite only group.
    /// </summary>
    /// <param name="groupId">The ID of the group the user wishes to join.</param>
    /// <param name="message">The message to send to the administrator.</param>
    /// <param name="acceptRules">A boolean confirming the user has accepted the rules of the group.</param>
    /// <param name="cancellationToken"></param>
    Task JoinRequestAsync(string groupId, string message, bool acceptRules = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Specify a group for the authenticated user to leave.
    /// </summary>
    /// <param name="groupId">The group id of the group to leave.</param>
    /// <param name="deletePhotos">
    /// Specify true to delete all of the users photos when they leave the group.
    /// </param>
    /// <param name="cancellationToken"></param>
    Task LeaveAsync(string groupId, bool deletePhotos = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Search the list of groups on Flickr for the text.
    /// </summary>
    /// <param name="text">The text to search for.</param>
    /// <param name="page">The page of the results to return.</param>
    /// <param name="perPage">The number of groups to list per page.</param>
    /// <param name="cancellationToken"></param>
    Task<GroupSearchResultCollection> SearchAsync(string text, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a list of the members of a group.
    /// </summary>
    /// <remarks>
    /// The call must be signed on behalf of a Flickr member, and the ability to see the group
    /// membership will be determined by the Flickr member's group privileges.
    /// </remarks>
    /// <param name="groupId">
    /// Return a list of members for this group. The group must be viewable by the Flickr member on
    /// whose behalf the API call is made.
    /// </param>
    /// <param name="page">The page of the results to return (default is 1).</param>
    /// <param name="perPage">
    /// The number of members to return per page (default is 100, max is 500).
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <param name="memberTypes">The types of members to be returned. Can be more than one.</param>
    Task<MemberCollection> MembersGetListAsync(string groupId, MemberTypes memberTypes = MemberTypes.None, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a photo to a pool you have permission to add photos to.
    /// </summary>
    /// <param name="photoId">The id of one of your photos to be added.</param>
    /// <param name="groupId">The id of a group you are a member of.</param>
    /// <param name="cancellationToken"></param>
    Task PoolsAddAsync(string photoId, string groupId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the context for a photo from within a group. This provides the id and thumbnail url for
    /// the next and previous photos in the group.
    /// </summary>
    /// <param name="photoId">The Photo ID for the photo you want the context for.</param>
    /// <param name="groupId">The group ID for the group you want the context to be relevant to.</param>
    /// <param name="cancellationToken"></param>
    Task<Context> PoolsGetContextAsync(string photoId, string groupId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a list of groups to which you can add photos.
    /// </summary>
    /// <param name="page">The page of the results to return.</param>
    /// <param name="perPage">The number of groups to list per page.</param>
    /// <param name="cancellationToken"></param>
    Task<MemberGroupInfoCollection> PoolsGetGroupsAsync(int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

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
    /// <param name="perPage">The number of photos per page.</param>
    /// <param name="cancellationToken"></param>
    /// <param name="page">The page to return.</param>
    Task<PhotoCollection> PoolsGetPhotosAsync(string groupId, string tags = null, string userId = null, PhotoSearchExtras extras = PhotoSearchExtras.None, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

    /// <summary> Remove a picture from a group. </summary> <param name="photoId">The id of one of
    /// your pictures you wish to remove.</param> <param name="groupId">The id of the group to
    /// remove the picture from.</param
    Task PoolsRemoveAsync(string photoId, string groupId, CancellationToken cancellationToken = default);
}