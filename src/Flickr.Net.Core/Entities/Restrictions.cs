using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

/// <summary>
/// </summary>
public record Restrictions : FlickrEntityBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("photos_ok")]
    public bool PhotosOk { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("videos_ok")]
    public bool VideosOk { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("images_ok")]
    public bool ImagesOk { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("screens_ok")]
    public bool ScreensOk { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("art_ok")]
    public bool ArtOk { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("safe_ok")]
    public bool SafeOk { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("moderate_ok")]
    public bool ModerateOk { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("restricted_ok")]
    public bool RestrictedOk { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("has_geo")]
    public bool HasGeo { get; set; }
}