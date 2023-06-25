namespace Flickr.Net.Core.Enums;

/// <summary>
/// Used to specify where all tags must be matched or any tag to be matched.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum MachineTagMode
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
    AllTags
}