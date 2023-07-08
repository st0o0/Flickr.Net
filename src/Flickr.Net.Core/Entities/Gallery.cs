using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("gallery")]
public record Gallery : FlickrEntityBase<Id>
{
    [JsonProperty("gallery_id")]
    public string GalleryId { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("owner")]
    public string Owner { get; set; }

    [JsonProperty("username")]
    public string Username { get; set; }

    [JsonProperty("iconserver")]
    public string Iconserver { get; set; }

    [JsonProperty("iconfarm")]
    public int Iconfarm { get; set; }

    [JsonProperty("primary_photo_id")]
    public string PrimaryPhotoId { get; set; }

    [JsonProperty("date_create")]
    public DateTime CreateDate { get; set; }

    [JsonProperty("date_update")]
    public DateTime UpdateDate { get; set; }

    [JsonProperty("count_photos")]
    public int PhotosCount { get; set; }

    [JsonProperty("count_videos")]
    public int VideosCount { get; set; }

    [JsonProperty("count_total")]
    public int TotalCount { get; set; }

    [JsonProperty("count_views")]
    public int ViewsCount { get; set; }

    [JsonProperty("count_comments")]
    public int CommentsCount { get; set; }

    [JsonProperty("title")]
    public Title Title { get; set; }

    [JsonProperty("description")]
    public Description Description { get; set; }

    [JsonProperty("sort_group")]
    public string SortGroup { get; set; }

    [JsonProperty("primary_photo_server")]
    public string PrimaryPhotoServer { get; set; }

    [JsonProperty("primary_photo_farm")]
    public int PrimaryPhotoFarm { get; set; }

    [JsonProperty("primary_photo_secret")]
    public string PrimaryPhotoSecret { get; set; }

    /// <summary>
    /// The URL of the thumbnail for the primary image for this gallery.
    /// </summary>
    public string PrimaryPhotoThumbnailUrl => UtilityMethods.UrlFormat(PrimaryPhotoFarm, PrimaryPhotoServer, PrimaryPhotoId, PrimaryPhotoSecret, "thumbnail", "jpg");

    /// <summary>
    /// The URL of the small image for the primary image for this gallery.
    /// </summary>
    public string PrimaryPhotoSmallUrl => UtilityMethods.UrlFormat(PrimaryPhotoFarm, PrimaryPhotoServer, PrimaryPhotoId, PrimaryPhotoSecret, "small", "jpg");

    /// <summary>
    /// The URL of the squrea thumbnail for the primary image for this gallery.
    /// </summary>
    public string PrimaryPhotoSquareThumbnailUrl => UtilityMethods.UrlFormat(PrimaryPhotoFarm, PrimaryPhotoServer, PrimaryPhotoId, PrimaryPhotoSecret, "square", "jpg");

    /// <summary>
    /// The URL of the medium image for the primary image for this gallery. For large sizes call
    /// <see cref="IFlickrPhotos.GetSizesAsync(string, CancellationToken)"/>
    /// </summary>
    public string PrimaryPhotoMediumUrl => UtilityMethods.UrlFormat(PrimaryPhotoFarm, PrimaryPhotoServer, PrimaryPhotoId, PrimaryPhotoSecret, "medium", "jpg");
}
