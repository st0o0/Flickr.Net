using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Throttle : FlickrEntityBase
{
    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("mode")]
    public ThrottleMode Mode { get; set; }

    [JsonPropertyName("remaining")]
    public int Remaining { get; set; }
}