using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("photo")]
public record GalleryPhoto : UltraDeluxePhotoBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("is_primary")]
    public bool IsPrimary { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("has_comment")]
    public bool HasComments { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("comment")]
    public List<string> Comments { get; set; } = [];
}