using System.Text.Json.Serialization;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

[FlickrJsonPropertyName("error")]
/// <summary>Represents a method argument in the Flickr API reflection response.</summary>
public record Argument
{
    [JsonPropertyName("name")]
    /// <summary>The display name.</summary>
    public string? Name { get; init; }
    [JsonPropertyName("optional")]
    /// <summary>Whether this argument is optional.</summary>
    public bool Optional { get; init; }
    [JsonPropertyName("_content")]
    /// <summary>The text content.</summary>
    public string? Content { get; init; }
}
