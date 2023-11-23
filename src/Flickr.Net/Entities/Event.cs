using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;

/// <summary>
/// </summary>
public record Event : FlickrEntityBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("type")]
    public EventType Type { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("user")]
    public string User { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("username")]
    public string UserName { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("dateadded")]
    public DateTime AddedDate { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("commentid")]
    public string CommentId { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("noteid")]
    public string NoteId { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("galleryid")]
    public string GalleryId { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("iconserver")]
    public string IconServer { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("iconfarm")]
    public string IconFarm { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("realname")]
    public string RealName { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("group_id")]
    public string GroupId { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("group_name")]
    public string GroupName { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("is_muted")]
    public bool IsMuted { get; set; }
}