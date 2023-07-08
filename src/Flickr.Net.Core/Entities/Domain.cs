using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("domain")]
public record Domain : FlickrEntityBase
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("views")]
    public int Views { get; set; }
}
