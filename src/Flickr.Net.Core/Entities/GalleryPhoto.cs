using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("photo")]
public record GalleryPhoto : UltraDeluxePhotoBase
{
    [JsonPropertyName("is_primary")]
    public bool IsPrimary { get; set; }

    [JsonPropertyName("has_comment")]
    public bool HasComments { get; set; }

    [JsonPropertyName("comment")]
    public List<string> Comments { get; set; } = new List<string>();
}