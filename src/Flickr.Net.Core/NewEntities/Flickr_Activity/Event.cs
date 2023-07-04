using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

/// <summary>
/// </summary>
public record Event : FlickrEntityBase
{
    /// <summary>
    /// </summary>
    [JsonProperty("type")]
    public EventType Type { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("user")]
    public string User { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("username")]
    public string UserName { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("dateadded")]
    public DateTime AddedDate { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("_content")]
    public string Content { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("commentid")]
    public string CommentId { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("noteid")]
    public string NoteId { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("galleryid")]
    public string GalleryId { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("iconserver")]
    public string IconServer { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("iconfarm")]
    public string IconFarm { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("realname")]
    public string RealName { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("group_id")]
    public string GroupId { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("group_name")]
    public string GroupName { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("is_muted")]
    public bool IsMuted { get; set; }
}