namespace Flickr.Net.Core.Enums;

/// <summary>
/// The type of the <see cref="Event"/>.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum EventType
{
    /// <summary>
    /// The event type was not specified, or was a new unsupported type.
    /// </summary>
    [EnumMember(Value = "")]
    Unknown,

    /// <summary>
    /// The event was a comment.
    /// </summary>
    [EnumMember(Value = "comment")]
    Comment,

    /// <summary>
    /// The event was a note.
    /// </summary>
    [EnumMember(Value = "note")]
    Note,

    /// <summary>
    /// The event is a favourite.
    /// </summary>
    [EnumMember(Value = "fave")]
    Favorite,

    /// <summary>
    /// The event is for a gallery.
    /// </summary>
    [EnumMember(Value = "added_to_gallery")]
    Gallery,

    /// <summary>
    /// The event is a tag being added to a item.
    /// </summary>
    [EnumMember(Value = "tag")]
    Tag,

    /// <summary>
    /// The event is a group invite.
    /// </summary>
    [EnumMember(Value = "group_invite")]
    GroupInvite
}