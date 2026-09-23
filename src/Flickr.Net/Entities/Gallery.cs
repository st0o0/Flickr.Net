using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

[FlickrJsonPropertyName("gallery")]
/// <summary>Represents a Flickr gallery — a curated collection of other users' photos.</summary>
public record Gallery : FlickrEntityBase<Id>, IBuddyIcon, IThumbnailUrl, ISquareUrl, ISmallUrl, IMediumUrl
{
    [JsonPropertyName("gallery_id")]
    /// <summary>The gallery identifier.</summary>
    public string? GalleryId { get; init; }
    [JsonPropertyName("url")]
    /// <summary>The URL.</summary>
    public string? Url { get; init; }
    [JsonPropertyName("owner")]
    /// <summary>The NSID of the owner.</summary>
    public string? Owner { get; init; }
    [JsonPropertyName("username")]
    /// <summary>The username.</summary>
    public string? Username { get; init; }
    [JsonPropertyName("iconserver")]
    /// <summary>The icon server for buddy icon URL construction.</summary>
    public string? IconServer { get; init; }
    [JsonPropertyName("iconfarm")]
    /// <summary>The icon farm for buddy icon URL construction.</summary>
    public int IconFarm { get; init; }
    [JsonPropertyName("primary_photo_id")]
    /// <summary>The identifier of the primary/cover photo.</summary>
    public string? PrimaryPhotoId { get; init; }
    [JsonPropertyName("date_create")]
    /// <summary>The creation date.</summary>
    public DateTime CreateDate { get; init; }
    [JsonPropertyName("date_update")]
    /// <summary>The last update date.</summary>
    public DateTime UpdateDate { get; init; }
    [JsonPropertyName("count_photos")]
    /// <summary>The number of photos.</summary>
    public int PhotosCount { get; init; }
    [JsonPropertyName("count_videos")]
    /// <summary>The number of videos.</summary>
    public int VideosCount { get; init; }
    [JsonPropertyName("count_total")]
    /// <summary>The total number of items.</summary>
    public int TotalCount { get; init; }
    [JsonPropertyName("count_views")]
    /// <summary>The number of views.</summary>
    public int ViewsCount { get; init; }
    [JsonPropertyName("count_comments")]
    /// <summary>The number of comments.</summary>
    public int CommentsCount { get; init; }
    [JsonPropertyName("title")]
    /// <summary>The title.</summary>
    public Title Title { get; init; }
    [JsonPropertyName("description")]
    /// <summary>The description.</summary>
    public Description Description { get; init; }
    [JsonPropertyName("sort_group")]
    /// <summary>The sort group identifier.</summary>
    public string? SortGroup { get; init; }
    [JsonPropertyName("primary_photo_server")]
    /// <summary>The server of the primary photo.</summary>
    public string? PrimaryPhotoServer { get; init; }
    [JsonPropertyName("primary_photo_farm")]
    /// <summary>The farm of the primary photo.</summary>
    public int PrimaryPhotoFarm { get; init; }
    [JsonPropertyName("primary_photo_secret")]
    /// <summary>The secret of the primary photo.</summary>
    public string? PrimaryPhotoSecret { get; init; }
}
