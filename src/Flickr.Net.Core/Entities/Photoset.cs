using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Photoset : FlickrEntityBase<Id>, IThumbnailUrl, ISquareUrl, ISmallUrl
{
    [JsonProperty("owner")]
    public string Owner { get; set; }

    [JsonProperty("username")]
    public string Username { get; set; }

    [JsonProperty("primary")]
    public string Primary { get; set; }

    [JsonProperty("secret")]
    public string Secret { get; set; }

    [JsonProperty("server")]
    public string Server { get; set; }

    [JsonProperty("farm")]
    public int Farm { get; set; }

    [JsonProperty("count_views")]
    public int ViewsCount { get; set; }

    [JsonProperty("count_comments")]
    public int CommentsCount { get; set; }

    [JsonProperty("count_photos")]
    public int PhotosCount { get; set; }

    [JsonProperty("count_videos")]
    public int VideosCount { get; set; }

    [JsonProperty("title")]
    public Title Title { get; set; }

    [JsonProperty("description")]
    public Description Description { get; set; }

    [JsonProperty("can_comment")]
    public bool CanComment { get; set; }

    [JsonProperty("date_create")]
    public DateTime CreateDate { get; set; }

    [JsonProperty("date_update")]
    public DateTime UpdateDate { get; set; }

    [JsonProperty("photos")]
    public int Photos { get; set; }

    [JsonProperty("visibility_can_see_set")]
    public bool VisibilityCanSeeSet { get; set; }

    [JsonProperty("needs_interstitial")]
    public bool NeedsInterstitial { get; set; }
}
