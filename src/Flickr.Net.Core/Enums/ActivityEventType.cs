namespace FlickrNet.Core.Enums;

/// <summary>
/// The type of the <see cref="ActivityEvent"/>.
/// </summary>
public enum ActivityEventType
{
    /// <summary>
    /// The event type was not specified, or was a new unsupported type.
    /// </summary>
    Unknown,

    /// <summary>
    /// The event was a comment.
    /// </summary>
    Comment,

    /// <summary>
    /// The event was a note.
    /// </summary>
    Note,

    /// <summary>
    /// The event is a favourite.
    /// </summary>
    Favorite,

    /// <summary>
    /// The event is for a gallery.
    /// </summary>
    Gallery,

    /// <summary>
    /// The event is a tag being added to a item.
    /// </summary>
    Tag,

    /// <summary>
    /// The event is a group invite.
    /// </summary>
    GroupInvite
}
