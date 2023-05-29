namespace FlickrNet.Core.Enums;

/// <summary>
/// The type of the <see cref="ActivityItem"/>.
/// </summary>
public enum ActivityItemType
{
    /// <summary>
    /// The type is unknown, either not set of a new unsupported type.
    /// </summary>
    Unknown,

    /// <summary>
    /// The activity item is on a photoset.
    /// </summary>
    Photoset,

    /// <summary>
    /// The activitiy item is on a photo.
    /// </summary>
    Photo,

    /// <summary>
    /// The activity item is on a gallery.
    /// </summary>
    Gallery
}
