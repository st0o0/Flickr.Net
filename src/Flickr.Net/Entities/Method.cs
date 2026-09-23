using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

[FlickrJsonPropertyName("method")]
/// <summary>Represents a Flickr API method in the reflection response.</summary>
public record Method : FlickrEntityBase
{
    [JsonPropertyName("_content")]
    /// <summary>The text content.</summary>
    public string? Content { get; init; }
    /// <summary>Converts to the underlying string value.</summary>
    public static implicit operator string(Method method) => method.Content;
}
