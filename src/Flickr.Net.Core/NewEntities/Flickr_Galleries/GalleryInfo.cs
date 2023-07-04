using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("gallery")]
public record GalleryInfo : Gallery
{
    [JsonProperty("cover_photos")]
    public CoverPhotos CoverPhotos { get; set; } = null;

    [JsonProperty("current_state")]
    public string CurrentState { get; set; } = null;
}
