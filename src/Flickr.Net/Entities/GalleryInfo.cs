using System.Text.Json.Serialization;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("gallery")]
public record GalleryInfo : Gallery
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("cover_photos")]
    public CoverPhotos CoverPhotos { get; set; } = null;

    /// <summary>
    /// </summary>
    [JsonPropertyName("current_state")]
    public string CurrentState { get; set; } = null;
}
