using System.Text.Json.Serialization;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("tag")]
public record UserTag : TagBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("count")]
    public int Count { get; set; }
}
