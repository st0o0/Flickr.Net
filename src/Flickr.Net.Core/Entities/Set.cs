using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("set")]
public record Set : FlickrEntityBase<Id>
{
    [JsonPropertyName("title")]
    public string Title { get; set; }

    [JsonPropertyName("primary")]
    public string Primary { get; set; }

    [JsonPropertyName("secret")]
    public string Secret { get; set; }

    [JsonPropertyName("server")]
    public string Server { get; set; }

    [JsonPropertyName("farm")]
    public int Farm { get; set; }

    [JsonPropertyName("view_count")]
    public int ViewCount { get; set; }

    [JsonPropertyName("comment_count")]
    public int CommentCount { get; set; }

    [JsonPropertyName("count_photo")]
    public int PhotoCount { get; set; }

    [JsonPropertyName("count_video")]
    public int VideoCount { get; set; }
}