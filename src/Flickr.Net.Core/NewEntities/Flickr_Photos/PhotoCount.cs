using Newtonsoft.Json;

namespace Flickr.Net.Core;

public class PhotoCount
{
    [JsonProperty("count")]
    public int Count { get; set; }

    [JsonProperty("fromdate")]
    public DateTime FromDate { get; set; }

    [JsonProperty("todate")]
    public DateTime ToDate { get; set; }
}
