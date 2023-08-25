using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record PhotoCount : FlickrEntityBase
{
    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("fromdate")]
    public DateTime FromDate { get; set; }

    [JsonPropertyName("todate")]
    public DateTime ToDate { get; set; }
}
