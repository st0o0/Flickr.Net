namespace Flickr.Net.Core.Enums;

/// <summary>
/// The type of a member. Passed as a parameter to <see
/// cref="IFlickrGroupsMembers.GetListAsync(string, MemberTypes, int, int, CancellationToken)"/> and
/// returned for each <see cref="Member"/> as well.
/// </summary>
[Flags]
public enum MemberTypes
{
    /// <summary>
    /// No member type has been specified (all should be returned).
    /// </summary>
    None = 0,

    /// <summary>
    /// A basic member.
    /// </summary>
    Member = 1,

    /// <summary>
    /// A group moderator.
    /// </summary>
    Moderator = 2,

    /// <summary>
    /// A group adminstrator.
    /// </summary>
    Admin = 4,

    /// <summary>
    /// Some strange kind of super-admin. Unsupported by the API.
    /// </summary>
    Narwhal = 8
}