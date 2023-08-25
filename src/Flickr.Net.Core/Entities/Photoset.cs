using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Photoset : FlickrEntityBase<Id>, IThumbnailUrl, ISquareUrl, ISmallUrl
{
    [JsonPropertyName("owner")]
    public string Owner { get; set; }

    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("primary")]
    public string Primary { get; set; }

    [JsonPropertyName("secret")]
    public string Secret { get; set; }

    [JsonPropertyName("server")]
    public string Server { get; set; }

    [JsonPropertyName("farm")]
    public int Farm { get; set; }

    [JsonPropertyName("count_views")]
    public int ViewsCount { get; set; }

    [JsonPropertyName("count_comments")]
    public int CommentsCount { get; set; }

    [JsonPropertyName("count_photos")]
    public int PhotosCount { get; set; }

    [JsonPropertyName("count_videos")]
    public int VideosCount { get; set; }

    [JsonPropertyName("title")]
    public Title Title { get; set; }

    [JsonPropertyName("description")]
    public Description Description { get; set; }

    [JsonPropertyName("can_comment")]
    public bool CanComment { get; set; }

    [JsonPropertyName("date_create")]
    public DateTime CreateDate { get; set; }

    [JsonPropertyName("date_update")]
    public DateTime UpdateDate { get; set; }

    [JsonPropertyName("photos")]
    public int Photos { get; set; }

    [JsonPropertyName("visibility_can_see_set")]
    public bool VisibilityCanSeeSet { get; set; }

    [JsonPropertyName("needs_interstitial")]
    public bool NeedsInterstitial { get; set; }
}
