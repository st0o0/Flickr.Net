using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("photo")]
public record StatsPhoto : UltraDeluxePhotoBase
{
    [JsonProperty("stats")]
    public Stats Stats { get; set; }
}
