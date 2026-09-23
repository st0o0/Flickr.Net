using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;
/// <summary>Represents a photoset (album) on Flickr.</summary>
public record Photoset : FlickrEntityBase<Id>, IThumbnailUrl, ISquareUrl, ISmallUrl
{    [JsonPropertyName("owner")]
    /// <summary>The NSID of the owner.</summary>
    public string? Owner { get; init; }
    [JsonPropertyName("username")]
    /// <summary>The username.</summary>
    public string? Username { get; init; }
    [JsonPropertyName("primary")]
    /// <summary>The primary photo identifier.</summary>
    public string? Primary { get; init; }
    [JsonPropertyName("secret")]
    /// <summary>The photo secret used in URL construction.</summary>
    public string? Secret { get; init; }
    [JsonPropertyName("server")]
    /// <summary>The server identifier used in URL construction.</summary>
    public string? Server { get; init; }
    [JsonPropertyName("farm")]
    /// <summary>The farm identifier used in URL construction.</summary>
    public int Farm { get; init; }
    [JsonPropertyName("count_views")]
    /// <summary>The number of views.</summary>
    public int ViewsCount { get; init; }
    [JsonPropertyName("count_comments")]
    /// <summary>The number of comments.</summary>
    public int CommentsCount { get; init; }
    [JsonPropertyName("count_photos")]
    /// <summary>The number of photos.</summary>
    public int PhotosCount { get; init; }
    [JsonPropertyName("count_videos")]
    /// <summary>The number of videos.</summary>
    public int VideosCount { get; init; }
    [JsonPropertyName("title")]
    /// <summary>The title.</summary>
    public Title Title { get; init; }
    [JsonPropertyName("description")]
    /// <summary>The description.</summary>
    public Description Description { get; init; }
    [JsonPropertyName("can_comment")]
    /// <summary>Whether the current user can comment on this photoset.</summary>
    public bool CanComment { get; init; }
    [JsonPropertyName("date_create")]
    /// <summary>The creation date.</summary>
    public DateTime CreateDate { get; init; }
    [JsonPropertyName("date_update")]
    /// <summary>The last update date.</summary>
    public DateTime UpdateDate { get; init; }
    [JsonPropertyName("photos")]
    /// <summary>The number of photos.</summary>
    public int Photos { get; init; }
    [JsonPropertyName("visibility_can_see_set")]
    /// <summary>Whether the set is visible to the current user.</summary>
    public bool VisibilityCanSeeSet { get; init; }
    [JsonPropertyName("needs_interstitial")]
    /// <summary>Whether an interstitial page is needed before viewing.</summary>
    public bool NeedsInterstitial { get; init; }
}
