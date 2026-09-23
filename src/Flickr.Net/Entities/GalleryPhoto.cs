using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

[FlickrJsonPropertyName("photo")]
/// <summary>Represents a photo within a gallery.</summary>
public record GalleryPhoto : UltraDeluxePhotoBase
{
    [JsonPropertyName("is_primary")]
    /// <summary>Whether this is the primary photo.</summary>
    public bool IsPrimary { get; init; }
    [JsonPropertyName("has_comment")]
    /// <summary>Whether the photo has comments in this gallery.</summary>
    public bool HasComments { get; init; }
    [JsonPropertyName("comment")]
    /// <summary>The comments.</summary>
    public List<string> Comments { get; init; } = [];
}
