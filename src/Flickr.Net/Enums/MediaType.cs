namespace Flickr.Net.Enums;

/// <summary>
/// An enumeration of different media types tto search for.
/// </summary>
public enum MediaType
{
    /// <summary>
    /// Default MediaType. Does not correspond to a value that is sent to Flickr.
    /// </summary>
    [EnumMember(Value = "")]
    None,

    /// <summary>
    /// All media types will be return.
    /// </summary>
    [EnumMember(Value = "all")]
    All,

    /// <summary>
    /// Only photos will be returned.
    /// </summary>
    [EnumMember(Value = "photos")]
    Photos,

    /// <summary>
    /// Only videos will be returned.
    /// </summary>
    [EnumMember(Value = "videos")]
    Videos,

    /// <summary>
    /// Only photo will be returned.
    /// </summary>
    [EnumMember(Value = "photo")]
    Photo,

    /// <summary>
    /// Only video will be returned.
    /// </summary>
    [EnumMember(Value = "video")]
    Video,
}