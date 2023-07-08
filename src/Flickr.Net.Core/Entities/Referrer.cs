using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("referrer")]
public record Referrer : FlickrEntityBase
{
    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("views")]
    public int Views { get; set; }

    [JsonProperty("searchterm")]
    public string Searchterm { get; set; }
}
