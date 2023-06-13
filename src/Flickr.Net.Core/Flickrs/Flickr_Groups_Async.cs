namespace Flickr.Net.Core;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrGroups
{
    IFlickrGroupsDiscuss IFlickrGroups.Discuss => this;

    IFlickrGroupsMembers IFlickrGroups.Members => this;

    IFlickrGroupsPools IFlickrGroups.Pools => this;

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
}

/// <summary>
/// The flickr groups.
/// </summary>
public interface IFlickrGroups
{
    /// <summary>
    /// </summary>
    IFlickrGroupsDiscuss Discuss { get; }

    /// <summary>
    /// </summary>
    IFlickrGroupsMembers Members { get; }

    /// <summary>
    /// </summary>
    IFlickrGroupsPools Pools { get; }

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
}