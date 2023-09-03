using System.Text.Json.Serialization;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("gallery")]
public record GalleryInfo : Gallery
{
    [JsonPropertyName("cover_photos")]
    public CoverPhotos CoverPhotos { get; set; } = null;

    [JsonPropertyName("current_state")]
    public string CurrentState { get; set; } = null;
}
