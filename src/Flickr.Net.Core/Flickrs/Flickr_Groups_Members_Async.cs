namespace Flickr.Net.Core;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrGroupsMembers
{
    async Task<MemberCollection> IFlickrGroupsMembers.GetListAsync(string groupId, MemberTypes memberTypes, int page, int perPage, CancellationToken cancellationToken)
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
}

/// <summary>
/// The flickr groups members.
/// </summary>
public interface IFlickrGroupsMembers
{
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
    /// <param name="memberTypes">The types of members to be returned. Can be more than one.</param>
    /// <param name="page">The page of the results to return (default is 1).</param>
    /// <param name="perPage">
    /// The number of members to return per page (default is 100, max is 500).
    /// </param>
    /// <param name="cancellationToken"></param>
    Task<MemberCollection> GetListAsync(string groupId, MemberTypes memberTypes = MemberTypes.None, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);
}
