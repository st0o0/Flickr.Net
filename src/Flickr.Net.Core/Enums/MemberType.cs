using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Flickr.Net.Core.Enums;

/// <summary>
/// The type of a member. Passed as a parameter to <see
/// cref="IFlickrGroupsMembers.GetListAsync(string, MemberType, int, int, CancellationToken)"/> and
/// returned for each <see cref="Member"/> as well.
/// </summary>

[JsonConverter(typeof(StringEnumConverter))]
[Flags]
public enum MemberType
{
    /// <summary>
    /// No member type has been specified (all should be returned).
    /// </summary>
    [EnumMember(Value = "")]
    None = 0,

    /// <summary>
    /// A basic member.
    /// </summary>
    [EnumMember(Value = "member")]
    Member = 1,

    /// <summary>
    /// A group moderator.
    /// </summary>
    [EnumMember(Value = "moderator")]
    Moderator = 2,

    /// <summary>
    /// A group adminstrator.
    /// </summary>
    [EnumMember(Value = "admin")]
    Admin = 4,

    /// <summary>
    /// Some strange kind of super-admin. Unsupported by the API.
    /// </summary>
    [EnumMember(Value = "narwhal")]
    Narwhal = 8,
}