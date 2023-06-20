using Newtonsoft.Json;

namespace Flickr.Net.Core.NewEntities;

public class Throttle
{
    [JsonProperty("count")]
    public int Count { get; set; }

    [JsonProperty("mode")]
    public ThrottleMode Mode { get; set; }

    [JsonProperty("remaining")]
    public int Remaining { get; set; }
}