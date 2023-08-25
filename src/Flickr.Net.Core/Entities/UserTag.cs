using System.Text.Json.Serialization;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("tag")]
public record UserTag : TagBase
{
    [JsonPropertyName("count")]
    public int Count { get; set; }
}
