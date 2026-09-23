using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Enums;

namespace Flickr.Net;
/// <summary>Represents an activity event such as a comment, note, or fave.</summary>
public record Event : FlickrEntityBase
{
    [JsonPropertyName("type")]
    /// <summary>The type.</summary>
    public EventType Type { get; init; }
    [JsonPropertyName("user")]
    /// <summary>The NSID of the user.</summary>
    public string? User { get; init; }
    [JsonPropertyName("username")]
    /// <summary>The username.</summary>
    public string? UserName { get; init; }
    [JsonPropertyName("dateadded")]
    /// <summary>The date the item was added.</summary>
    public DateTime AddedDate { get; init; }
    [JsonPropertyName("_content")]
    /// <summary>The text content.</summary>
    public string? Content { get; init; }
    [JsonPropertyName("commentid")]
    /// <summary>The comment identifier.</summary>
    public string? CommentId { get; init; }
    [JsonPropertyName("noteid")]
    /// <summary>The note identifier.</summary>
    public string? NoteId { get; init; }
    [JsonPropertyName("galleryid")]
    /// <summary>The gallery identifier.</summary>
    public string? GalleryId { get; init; }
    [JsonPropertyName("iconserver")]
    /// <summary>The icon server for buddy icon URL construction.</summary>
    public string? IconServer { get; init; }
    [JsonPropertyName("iconfarm")]
    /// <summary>The icon farm for buddy icon URL construction.</summary>
    public string? IconFarm { get; init; }
    [JsonPropertyName("realname")]
    /// <summary>The real name.</summary>
    public string? RealName { get; init; }
    [JsonPropertyName("group_id")]
    /// <summary>The group NSID.</summary>
    public string? GroupId { get; init; }
    [JsonPropertyName("group_name")]
    /// <summary>The group name.</summary>
    public string? GroupName { get; init; }
    [JsonPropertyName("is_muted")]
    /// <summary>Whether the event is muted.</summary>
    public bool IsMuted { get; init; }
}
