using System.Text.Json.Serialization;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

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
