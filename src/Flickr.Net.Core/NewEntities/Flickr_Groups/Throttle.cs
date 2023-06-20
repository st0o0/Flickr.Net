using Flickr.Net.Core.Bases;
using Newtonsoft.Json;

namespace Flickr.Net.Core;

public record Throttle : FlickrEntityBase
{
    [JsonProperty("count")]
    public int Count { get; set; }

    [JsonProperty("mode")]
    public ThrottleMode Mode { get; set; }

    [JsonProperty("remaining")]
    public int Remaining { get; set; }
}