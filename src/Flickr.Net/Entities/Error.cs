using System.Text.Json.Serialization;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

[FlickrJsonPropertyName("error")]
/// <summary>Represents an error response from the Flickr API.</summary>
public record Error
{
    [JsonPropertyName("code")]
    /// <summary>The error code.</summary>
    public int Code { get; init; }
    [JsonPropertyName("message")]
    /// <summary>The error message.</summary>
    public string? Message { get; init; }
    [JsonPropertyName("_content")]
    /// <summary>The text content.</summary>
    public string? Content { get; init; }
}
