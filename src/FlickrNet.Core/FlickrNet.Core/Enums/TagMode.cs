namespace FlickrNet.Core.Enums;

/// <summary>
/// Used to specify where all tags must be matched or any tag to be matched.
/// </summary>
[Serializable]
public enum TagMode
{
    /// <summary>
    /// No tag mode specified.
    /// </summary>
    None,

    /// <summary>
    /// Any tag must match, but not all.
    /// </summary>
    AnyTag,

    /// <summary>
    /// All tags must be found.
    /// </summary>
    AllTags,

    /// <summary>
    /// Uncodumented and unsupported tag mode where boolean operators are supported.
    /// </summary>
    Boolean
}