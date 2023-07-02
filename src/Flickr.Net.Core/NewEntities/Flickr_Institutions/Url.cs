using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Url : FlickrEntityBase
{
    [JsonProperty("type")]
    public UrlType Type { get; set; }

    [JsonProperty("_content")]
    public string Content { get; set; }
}