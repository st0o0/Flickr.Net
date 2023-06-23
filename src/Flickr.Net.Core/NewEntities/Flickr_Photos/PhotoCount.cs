using Flickr.Net.Core.Bases;
using Newtonsoft.Json;

namespace Flickr.Net.Core;

public record PhotoCount : FlickrEntityBase
{
    [JsonProperty("count")]
    public int Count { get; set; }

    [JsonProperty("fromdate")]
    public DateTime FromDate { get; set; }

    [JsonProperty("todate")]
    public DateTime ToDate { get; set; }
}
