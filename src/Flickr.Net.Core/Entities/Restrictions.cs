using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Restrictions : FlickrEntityBase
{
    [JsonPropertyName("photos_ok")]
    public bool PhotosOk { get; set; }

    [JsonPropertyName("videos_ok")]
    public bool VideosOk { get; set; }

    [JsonPropertyName("images_ok")]
    public bool ImagesOk { get; set; }

    [JsonPropertyName("screens_ok")]
    public bool ScreensOk { get; set; }

    [JsonPropertyName("art_ok")]
    public bool ArtOk { get; set; }

    [JsonPropertyName("safe_ok")]
    public bool SafeOk { get; set; }

    [JsonPropertyName("moderate_ok")]
    public bool ModerateOk { get; set; }

    [JsonPropertyName("restricted_ok")]
    public bool RestrictedOk { get; set; }

    [JsonPropertyName("has_geo")]
    public bool HasGeo { get; set; }
}