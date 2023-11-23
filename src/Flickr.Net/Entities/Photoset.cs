using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;

/// <summary>
/// </summary>
public record Photoset : FlickrEntityBase<Id>, IThumbnailUrl, ISquareUrl, ISmallUrl
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("owner")]
    public string Owner { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("username")]
    public string Username { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("primary")]
    public string Primary { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("secret")]
    public string Secret { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("server")]
    public string Server { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("farm")]
    public int Farm { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("count_views")]
    public int ViewsCount { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("count_comments")]
    public int CommentsCount { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("count_photos")]
    public int PhotosCount { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("count_videos")]
    public int VideosCount { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("title")]
    public Title Title { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("description")]
    public Description Description { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("can_comment")]
    public bool CanComment { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("date_create")]
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("date_update")]
    public DateTime UpdateDate { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("photos")]
    public int Photos { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("visibility_can_see_set")]
    public bool VisibilityCanSeeSet { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("needs_interstitial")]
    public bool NeedsInterstitial { get; set; }
}
