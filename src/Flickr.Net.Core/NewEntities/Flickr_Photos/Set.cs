using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;
using Newtonsoft.Json;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("set")]
public record Set : FlickrEntityBase<Id>
{
    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("primary")]
    public string Primary { get; set; }

    [JsonProperty("secret")]
    public string Secret { get; set; }

    [JsonProperty("server")]
    public string Server { get; set; }

    [JsonProperty("farm")]
    public int Farm { get; set; }

    [JsonProperty("view_count")]
    public int ViewCount { get; set; }

    [JsonProperty("comment_count")]
    public int CommentCount { get; set; }

    [JsonProperty("count_photo")]
    public int PhotoCount { get; set; }

    [JsonProperty("count_video")]
    public int VideoCount { get; set; }
}