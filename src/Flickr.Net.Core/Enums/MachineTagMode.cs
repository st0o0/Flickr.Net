namespace Flickr.Net.Core.Enums;

/// <summary>
/// Used to specify where all tags must be matched or any tag to be matched.
/// </summary>
[Serializable]
public enum MachineTagMode
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
    AllTags
}