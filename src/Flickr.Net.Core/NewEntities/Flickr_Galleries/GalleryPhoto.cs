using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;
using Newtonsoft.Json;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("photo")]
public record GalleryPhoto : ExtendedPhotoBase
{
    [JsonProperty("ispublic")]
    public bool IsPublic { get; set; }

    [JsonProperty("isfriend")]
    public bool IsFriend { get; set; }

    [JsonProperty("isfamily")]
    public bool IsFamily { get; set; }

    [JsonProperty("is_primary")]
    public bool IsPrimary { get; set; }

    [JsonProperty("has_comment")]
    public bool HasComments { get; set; }

    [JsonProperty("comment")]
    public List<string> Comments { get; set; } = new List<string>();
}