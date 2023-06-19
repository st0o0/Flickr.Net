using Flickr.Net.Core.Internals.Attributes;
using Flickr.Net.Core.Internals.JsonConverters;
using Newtonsoft.Json;

namespace Flickr.Net.Core.NewEntities;

[FlickrJsonPropertyName("photo")]
public class GalleryPhoto : Photo
{
    [JsonProperty("is_primary")]
    [JsonConverter(typeof(BoolConverter))]
    public bool IsPrimary { get; set; }

    [JsonProperty("has_comment")]
    [JsonConverter(typeof(BoolConverter))]
    public bool HasComments { get; set; }

    [JsonProperty("comment")]
    public List<string> Comments { get; set; } = new List<string>();
}