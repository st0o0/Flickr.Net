namespace FlickrNet.Core.Enums;

/// <summary>
/// Determines weither the photo is visible in public searches. The default is 1, Visible.
/// </summary>
[Serializable]
public enum HiddenFromSearch
{
    /// <summary>
    /// No preference specified, defaults to your preferences on Flickr.
    /// </summary>
    None = 0,

    /// <summary>
    /// Photo is visible to public searches.
    /// </summary>
    Visible = 1,

    /// <summary>
    /// photo is hidden from public searches.
    /// </summary>
    Hidden = 2
}