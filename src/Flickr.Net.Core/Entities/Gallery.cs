using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("gallery")]
public record Gallery : FlickrEntityBase<Id>, IBuddyIcon, IThumbnailUrl, ISquareUrl, ISmallUrl, IMediumUrl
{
    [JsonPropertyName("gallery_id")]
    public string GalleryId { get; set; }

    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("owner")]
    public string Owner { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("iconserver")]
    public string IconServer { get; set; }

    [JsonPropertyName("iconfarm")]
    public int IconFarm { get; set; }

    [JsonPropertyName("primary_photo_id")]
    public string PrimaryPhotoId { get; set; }

    [JsonPropertyName("date_create")]
    public DateTime CreateDate { get; set; }

    [JsonPropertyName("date_update")]
    public DateTime UpdateDate { get; set; }

    [JsonPropertyName("count_photos")]
    public int PhotosCount { get; set; }

    [JsonPropertyName("count_videos")]
    public int VideosCount { get; set; }

    [JsonPropertyName("count_total")]
    public int TotalCount { get; set; }

    [JsonPropertyName("count_views")]
    public int ViewsCount { get; set; }

    [JsonPropertyName("count_comments")]
    public int CommentsCount { get; set; }

    [JsonPropertyName("title")]
    public Title Title { get; set; }

    [JsonPropertyName("description")]
    public Description Description { get; set; }

    [JsonPropertyName("sort_group")]
    public string SortGroup { get; set; }

    [JsonPropertyName("primary_photo_server")]
    public string PrimaryPhotoServer { get; set; }

    [JsonPropertyName("primary_photo_farm")]
    public int PrimaryPhotoFarm { get; set; }

    [JsonPropertyName("primary_photo_secret")]
    public string PrimaryPhotoSecret { get; set; }
}
