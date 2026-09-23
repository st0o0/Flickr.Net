using System.Text.Json.Serialization;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

[FlickrJsonPropertyName("tag")]
/// <summary>Represents a tag with its usage count for a user.</summary>
public record UserTag : TagBase
{
    [JsonPropertyName("count")]
    /// <summary>The count.</summary>
    public int Count { get; init; }
}
