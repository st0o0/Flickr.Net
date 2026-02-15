using System.Runtime.Serialization;

namespace Flickr.Net.Enums;

/// <summary>
/// Used to specify where all tags must be matched or any tag to be matched.
/// </summary>
public enum TagMode
{
    /// <summary>
    /// No tag mode specified.
    /// </summary>
    [EnumMember(Value = "")]
    None,

    /// <summary>
    /// Any tag must match, but not all.
    /// </summary>
    [EnumMember(Value = "any")]
    AnyTag,

    /// <summary>
    /// All tags must be found.
    /// </summary>
    [EnumMember(Value = "all")]
    AllTags,

    /// <summary>
    /// Uncodumented and unsupported tag mode where boolean operators are supported.
    /// </summary>
    [EnumMember(Value = "bool")]
    Boolean
}