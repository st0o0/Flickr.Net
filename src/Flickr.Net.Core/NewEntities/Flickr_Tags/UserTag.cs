using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("tag")]
public record UserTag : TagBase
{
    [JsonProperty("count")]
    public int Count { get; set; }
}
