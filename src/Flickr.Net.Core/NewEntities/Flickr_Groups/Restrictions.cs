using Flickr.Net.Core.Bases;
using Newtonsoft.Json;

namespace Flickr.Net.Core;

public record Restrictions : FlickrEntityBase
{
    [JsonProperty("photos_ok")]
    public bool PhotosOk { get; set; }

    [JsonProperty("videos_ok")]
    public bool VideosOk { get; set; }

    [JsonProperty("images_ok")]
    public bool ImagesOk { get; set; }

    [JsonProperty("screens_ok")]
    public bool ScreensOk { get; set; }

    [JsonProperty("art_ok")]
    public bool ArtOk { get; set; }

    [JsonProperty("safe_ok")]
    public bool SafeOk { get; set; }

    [JsonProperty("moderate_ok")]
    public bool ModerateOk { get; set; }

    [JsonProperty("restricted_ok")]
    public bool RestrictedOk { get; set; }

    [JsonProperty("has_geo")]
    public bool HasGeo { get; set; }
}