using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;
/// <summary>Represents content restrictions for a Flickr group.</summary>
public record Restrictions : FlickrEntityBase
{
    [JsonPropertyName("photos_ok")]
    /// <summary>Whether photos are allowed.</summary>
    public bool PhotosOk { get; init; }
    [JsonPropertyName("videos_ok")]
    /// <summary>Whether videos are allowed.</summary>
    public bool VideosOk { get; init; }
    [JsonPropertyName("images_ok")]
    /// <summary>Whether images are allowed.</summary>
    public bool ImagesOk { get; init; }
    [JsonPropertyName("screens_ok")]
    /// <summary>Whether screenshots are allowed.</summary>
    public bool ScreensOk { get; init; }
    [JsonPropertyName("art_ok")]
    /// <summary>Whether art/illustrations are allowed.</summary>
    public bool ArtOk { get; init; }
    [JsonPropertyName("safe_ok")]
    public bool SafeOk { get; init; }
    [JsonPropertyName("moderate_ok")]
    public bool ModerateOk { get; init; }
    [JsonPropertyName("restricted_ok")]
    public bool RestrictedOk { get; init; }
    [JsonPropertyName("has_geo")]
    /// <summary>Whether the content has geo data.</summary>
    public bool HasGeo { get; init; }
}
