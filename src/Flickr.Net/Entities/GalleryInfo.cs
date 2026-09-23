using System.Text.Json.Serialization;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

[FlickrJsonPropertyName("gallery")]
/// <summary>Extended gallery information including cover photos and state.</summary>
public record GalleryInfo : Gallery
{
    [JsonPropertyName("cover_photos")]
    /// <summary>The cover photos for the gallery.</summary>
    public CoverPhotos? CoverPhotos { get; init; }
    [JsonPropertyName("current_state")]
    /// <summary>The current state of the gallery.</summary>
    public string? CurrentState { get; init; } = null;
}
