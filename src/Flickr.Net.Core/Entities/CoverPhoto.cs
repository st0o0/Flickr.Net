using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("photo")]
public record CoverPhoto : FlickrEntityBase
{
    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("width")]
    public int Width { get; set; }

    [JsonProperty("height")]
    public int Height { get; set; }

    [JsonProperty("is_primary")]
    public bool IsPrimary { get; set; }

    [JsonProperty("is_video")]
    public bool IsVideo { get; set; }
}