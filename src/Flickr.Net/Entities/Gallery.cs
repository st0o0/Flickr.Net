using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("gallery")]
public record Gallery : FlickrEntityBase<Id>, IBuddyIcon, IThumbnailUrl, ISquareUrl, ISmallUrl, IMediumUrl
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("gallery_id")]
    public string GalleryId { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }

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
    [JsonPropertyName("iconserver")]
    public string IconServer { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("iconfarm")]
    public int IconFarm { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("primary_photo_id")]
    public string PrimaryPhotoId { get; set; }

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
    [JsonPropertyName("count_photos")]
    public int PhotosCount { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("count_videos")]
    public int VideosCount { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("count_total")]
    public int TotalCount { get; set; }

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
    [JsonPropertyName("title")]
    public Title Title { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("description")]
    public Description Description { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("sort_group")]
    public string SortGroup { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("primary_photo_server")]
    public string PrimaryPhotoServer { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("primary_photo_farm")]
    public int PrimaryPhotoFarm { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("primary_photo_secret")]
    public string PrimaryPhotoSecret { get; set; }
}
