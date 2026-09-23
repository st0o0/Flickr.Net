using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;
[FlickrJsonPropertyName("set")]
/// <summary>Represents a photoset context for a photo.</summary>
public record Set : FlickrEntityBase<Id>
{    [JsonPropertyName("title")]
    /// <summary>The title.</summary>
    public string? Title { get; init; }
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
    [JsonPropertyName("view_count")]
    public int ViewCount { get; init; }
    [JsonPropertyName("comment_count")]
    public int CommentCount { get; init; }
    [JsonPropertyName("count_photo")]
    public int PhotoCount { get; init; }
    [JsonPropertyName("count_video")]
    public int VideoCount { get; init; }
}
