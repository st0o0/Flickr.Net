namespace Flickr.Net.Core.Enums;

/// <summary>
/// What type of content is the upload representing.
/// </summary>
[Serializable]
public enum ContentType
{
    /// <summary>
    /// No content type specified.
    /// </summary>
    None = 0,

    /// <summary>
    /// For normal photographs.
    /// </summary>
    Photo = 1,

    /// <summary>
    /// For screenshots.
    /// </summary>
    Screenshot = 2,

    /// <summary>
    /// For other uploads, such as artwork.
    /// </summary>
    Other = 3
}