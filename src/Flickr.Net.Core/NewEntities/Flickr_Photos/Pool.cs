using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("pool")]
public record Pool : FlickrEntityBase<Id>
{
    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("iconserver")]
    public string IconServer { get; set; }

    [JsonProperty("iconfarm")]
    public int IconFarm { get; set; }

    [JsonProperty("members")]
    public int Members { get; set; }

    [JsonProperty("pool_count")]
    public int PoolCount { get; set; }
}
