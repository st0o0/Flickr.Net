using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Enums;

namespace Flickr.Net;
/// <summary>Represents the posting throttle settings for a group.</summary>
public record Throttle : FlickrEntityBase
{
    [JsonPropertyName("count")]
    /// <summary>The count.</summary>
    public int Count { get; init; }
    [JsonPropertyName("mode")]
    /// <summary>The throttle mode.</summary>
    public ThrottleMode Mode { get; init; }
    [JsonPropertyName("remaining")]
    /// <summary>The remaining allowance.</summary>
    public int Remaining { get; init; }
}
