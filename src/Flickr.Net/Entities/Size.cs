using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Enums;

namespace Flickr.Net;
/// <summary>Represents an available size variant of a photo.</summary>
public record Size : FlickrEntityBase
{
    [JsonPropertyName("label")]
    /// <summary>The human-readable label for the EXIF tag.</summary>
    public string? Label { get; init; }
    [JsonPropertyName("width")]
    /// <summary>The width in pixels.</summary>
    public int Width { get; init; }
    [JsonPropertyName("height")]
    /// <summary>The height in pixels.</summary>
    public int Height { get; init; }
    [JsonPropertyName("source")]
    /// <summary>The source URL.</summary>
    public string? Source { get; init; }
    [JsonPropertyName("url")]
    /// <summary>The URL.</summary>
    public string? Url { get; init; }
    [JsonPropertyName("media")]
    /// <summary>The media type (photo or video).</summary>
    public MediaType Media { get; init; }
}
