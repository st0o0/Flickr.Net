﻿namespace FlickrNet.Core;

public partial class Flickr
{
    /// <summary>
    /// Browse the group category tree, finding groups and sub-categories.
    /// </summary>
    /// <remarks>
    /// Flickr no longer supports this method and it returns no useful information.
    /// </remarks>
    public async Task<GroupCategory> GroupsBrowseAsync(CancellationToken cancellationToken = default)
    {
        return await GroupsBrowseAsync(null, cancellationToken);
    }

    /// <summary>
    /// Browse the group category tree, finding groups and sub-categories.
    /// </summary>
    /// <param name="catId">The category id to fetch a list of groups and sub-categories for. If not specified, it defaults to zero, the root of the category tree.</param>
    public async Task<GroupCategory> GroupsBrowseAsync(string catId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.browse" }
        };
        if (!string.IsNullOrEmpty(catId))
        {
            parameters.Add("cat_id", catId);
        }

        return await GetResponseAsync<GroupCategory>(parameters, cancellationToken);
    }

    /// <summary>
    /// Search the list of groups on Flickr for the text.
    /// </summary>
    /// <param name="text">The text to search for.</param>
    public async Task<GroupSearchResultCollection> GroupsSearchAsync(string text, CancellationToken cancellationToken = default)
    {
        return await GroupsSearchAsync(text, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Search the list of groups on Flickr for the text.
    /// </summary>
    /// <param name="text">The text to search for.</param>
    /// <param name="page">The page of the results to return.</param>
    public async Task<GroupSearchResultCollection> GroupsSearchAsync(string text, int page, CancellationToken cancellationToken = default)
    {
        return await GroupsSearchAsync(text, page, 0, cancellationToken);
    }

    /// <summary>
    /// Search the list of groups on Flickr for the text.
    /// </summary>
    /// <param name="text">The text to search for.</param>
    /// <param name="page">The page of the results to return.</param>
    /// <param name="perPage">The number of groups to list per page.</param>
    public async Task<GroupSearchResultCollection> GroupsSearchAsync(string text, int page, int perPage, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.search" },
            { "api_key", ApiKey },
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

    /// <summary>
    /// Returns a <see cref="GroupFullInfo"/> object containing details about a group.
    /// </summary>
    /// <param name="groupId">The id of the group to return.</param>
    public async Task<GroupFullInfo> GroupsGetInfoAsync(string groupId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.getInfo" },
            { "api_key", ApiKey },
            { "group_id", groupId }
        };
        return await GetResponseAsync<GroupFullInfo>(parameters, cancellationToken);
    }

    /// <summary>
    /// Get a list of group members.
    /// </summary>
    /// <param name="groupId">The group id to get the list of members for.</param>
    public async Task<MemberCollection> GroupsMembersGetListAsync(string groupId, CancellationToken cancellationToken = default)
    {
        return await GroupsMembersGetListAsync(groupId, 0, 0, MemberTypes.None, cancellationToken);
    }

    /// <summary>
    /// Get a list of the members of a group.
    /// </summary>
    /// <remarks>
    /// The call must be signed on behalf of a Flickr member, and the ability to see the group membership will be determined by the Flickr member's group privileges.
    /// </remarks>
    /// <param name="groupId">Return a list of members for this group. The group must be viewable by the Flickr member on whose behalf the API call is made.</param>
    /// <param name="page">The page of the results to return (default is 1).</param>
    /// <param name="perPage">The number of members to return per page (default is 100, max is 500).</param>
    /// <param name="memberTypes">The types of members to be returned. Can be more than one.</param>
    public async Task<MemberCollection> GroupsMembersGetListAsync(string groupId, int page, int perPage, MemberTypes memberTypes, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.members.getList" },
            { "api_key", ApiKey }
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

    /// <summary>
    /// Adds a photo to a pool you have permission to add photos to.
    /// </summary>
    /// <param name="photoId">The id of one of your photos to be added.</param>
    /// <param name="groupId">The id of a group you are a member of.</param>
    public async Task GroupsPoolsAddAsync(string photoId, string groupId, CancellationToken cancellationToken = default)
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

    /// <summary>
    /// Gets the context for a photo from within a group. This provides the
    /// id and thumbnail url for the next and previous photos in the group.
    /// </summary>
    /// <param name="photoId">The Photo ID for the photo you want the context for.</param>
    /// <param name="groupId">The group ID for the group you want the context to be relevant to.</param>
    public async Task<Context> GroupsPoolsGetContextAsync(string photoId, string groupId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.pools.getContext" },
            { "photo_id", photoId },
            { "group_id", groupId }
        };
        return await GetResponseAsync<Context>(parameters, cancellationToken);
    }

    /// <summary>
    /// Remove a picture from a group.
    /// </summary>
    /// <param name="photoId">The id of one of your pictures you wish to remove.</param>
    /// <param name="groupId">The id of the group to remove the picture from.</param>
    public async Task GroupsPoolsRemoveAsync(string photoId, string groupId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.pools.remove" },
            { "photo_id", photoId },
            { "group_id", groupId }
        };
        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Returns a list of groups to which you can add photos.
    /// </summary>
    public async Task<MemberGroupInfoCollection> GroupsPoolsGetGroupsAsync(CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.groups.pools.getGroups" }
        };

        return await GetResponseAsync<MemberGroupInfoCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Gets a list of photos for a given group.
    /// </summary>
    /// <param name="groupId">The group ID for the group.</param>
    public async Task<PhotoCollection> GroupsPoolsGetPhotosAsync(string groupId, CancellationToken cancellationToken = default)
    {
        return await GroupsPoolsGetPhotosAsync(groupId, null, null, PhotoSearchExtras.None, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Gets a list of photos for a given group.
    /// </summary>
    /// <param name="groupId">The group ID for the group.</param>
    /// <param name="tags">Space seperated list of tags that photos returned must have.</param>
    public async Task<PhotoCollection> GroupsPoolsGetPhotosAsync(string groupId, string tags, CancellationToken cancellationToken = default)
    {
        return await GroupsPoolsGetPhotosAsync(groupId, tags, null, PhotoSearchExtras.None, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Gets a list of photos for a given group.
    /// </summary>
    /// <param name="groupId">The group ID for the group.</param>
    /// <param name="perPage">The number of photos per page.</param>
    /// <param name="page">The page to return.</param>
    public async Task<PhotoCollection> GroupsPoolsGetPhotosAsync(string groupId, int page, int perPage, CancellationToken cancellationToken = default)
    {
        return await GroupsPoolsGetPhotosAsync(groupId, null, null, PhotoSearchExtras.None, page, perPage, cancellationToken);
    }

    /// <summary>
    /// Gets a list of photos for a given group.
    /// </summary>
    /// <param name="groupId">The group ID for the group.</param>
    /// <param name="tags">Space seperated list of tags that photos returned must have.</param>
    /// <param name="perPage">The number of photos per page.</param>
    /// <param name="page">The page to return.</param>
    public async Task<PhotoCollection> GroupsPoolsGetPhotosAsync(string groupId, string tags, int page, int perPage, CancellationToken cancellationToken = default)
    {
        return await GroupsPoolsGetPhotosAsync(groupId, tags, null, PhotoSearchExtras.None, page, perPage, cancellationToken);
    }

    /// <summary>
    /// Gets a list of photos for a given group.
    /// </summary>
    /// <param name="groupId">The group ID for the group.</param>
    /// <param name="tags">Space seperated list of tags that photos returned must have.
    /// Currently only supports 1 tag at a time.</param>
    /// <param name="userId">The group member to return photos for.</param>
    /// <param name="extras">The <see cref="PhotoSearchExtras"/> specifying which extras to return. All other overloads default to returning all extras.</param>
    /// <param name="perPage">The number of photos per page.</param>
    /// <param name="page">The page to return.</param>
    public async Task<PhotoCollection> GroupsPoolsGetPhotosAsync(string groupId, string tags, string userId, PhotoSearchExtras extras, int page, int perPage, CancellationToken cancellationToken = default)
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

    /// <summary>
    /// Specify a group for the authenticated user to join.
    /// </summary>
    /// <param name="groupId">The group id of the group to join.</param>
    public async Task GroupsJoinAsync(string groupId, CancellationToken cancellationToken = default)
    {
        await GroupsJoinAsync(groupId, false, cancellationToken);
    }

    /// <summary>
    /// Specify a group for the authenticated user to join.
    /// </summary>
    /// <param name="groupId">The group id of the group to join.</param>
    /// <param name="acceptsRules">Specify true to signify that the user accepts the groups rules.</param>
    public async Task GroupsJoinAsync(string groupId, bool acceptsRules, CancellationToken cancellationToken = default)
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

    /// <summary>
    /// Sends a request to the group admins to join an invite only group.
    /// </summary>
    /// <param name="groupId">The ID of the group the user wishes to join.</param>
    /// <param name="message">The message to send to the administrator.</param>
    /// <param name="acceptRules">A boolean confirming the user has accepted the rules of the group.</param>
    public async Task GroupsJoinRequestAsync(string groupId, string message, bool acceptRules, CancellationToken cancellationToken = default)
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

    /// <summary>
    /// Specify a group for the authenticated user to leave.
    /// </summary>
    /// <param name="groupId">The group id of the group to leave.</param>
    public async Task GroupsLeaveAsync(string groupId, CancellationToken cancellationToken = default)
    {
        await GroupsLeaveAsync(groupId, false, cancellationToken);
    }

    /// <summary>
    /// Specify a group for the authenticated user to leave.
    /// </summary>
    /// <param name="groupId">The group id of the group to leave.</param>
    /// <param name="deletePhotos">Specify true to delete all of the users photos when they leave the group.</param>
    public async Task GroupsLeaveAsync(string groupId, bool deletePhotos, CancellationToken cancellationToken = default)
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
}