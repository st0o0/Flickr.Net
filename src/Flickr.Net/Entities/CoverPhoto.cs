using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;
[FlickrJsonPropertyName("photo")]
/// <summary>Represents a cover photo for a gallery.</summary>
public record CoverPhoto : FlickrEntityBase
{    [JsonPropertyName("url")]
    /// <summary>The URL.</summary>
    public string? Url { get; init; }
    [JsonPropertyName("width")]
    /// <summary>The width in pixels.</summary>
    public int Width { get; init; }
    [JsonPropertyName("height")]
    /// <summary>The height in pixels.</summary>
    public int Height { get; init; }
    [JsonPropertyName("is_primary")]
    /// <summary>Whether this is the primary photo.</summary>
    public bool IsPrimary { get; init; }
    [JsonPropertyName("is_video")]
    /// <summary>Whether this is a video.</summary>
    public bool IsVideo { get; init; }
}
