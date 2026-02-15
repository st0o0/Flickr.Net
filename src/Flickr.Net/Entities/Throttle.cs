using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Enums;

namespace Flickr.Net;

/// <summary>
/// </summary>
public record Throttle : FlickrEntityBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("count")]
    public int Count { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("mode")]
    public ThrottleMode Mode { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("remaining")]
    public int Remaining { get; set; }
}