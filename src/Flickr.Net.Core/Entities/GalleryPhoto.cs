using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("photo")]
public record GalleryPhoto : UltraDeluxePhotoBase
{
    [JsonProperty("is_primary")]
    public bool IsPrimary { get; set; }

    [JsonProperty("has_comment")]
    public bool HasComments { get; set; }

    [JsonProperty("comment")]
    public List<string> Comments { get; set; } = new List<string>();
}