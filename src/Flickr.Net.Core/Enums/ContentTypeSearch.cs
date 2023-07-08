namespace Flickr.Net.Core.Enums;

/// <summary>
/// The values for a content type search.
/// </summary>
public enum ContentTypeSearch
{
    /// <summary>
    /// No content type specified.
    /// </summary>
    None = 0,

    /// <summary>
    /// For normal photographs.
    /// </summary>
    PhotosOnly = 1,

    /// <summary>
    /// For screenshots.
    /// </summary>
    ScreenshotsOnly = 2,

    /// <summary>
    /// For other uploads, such as artwork.
    /// </summary>
    OtherOnly = 3,

    /// <summary>
    /// Search for photos and screenshots
    /// </summary>
    PhotosAndScreenshots = 4,

    /// <summary>
    /// Search for screenshots and others
    /// </summary>
    ScreenshotsAndOthers = 5,

    /// <summary>
    /// Search for photos and other things
    /// </summary>
    PhotosAndOthers = 6,

    /// <summary>
    /// Search for anything (default)
    /// </summary>
    All = 7
}