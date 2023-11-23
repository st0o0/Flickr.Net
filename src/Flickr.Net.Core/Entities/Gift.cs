using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

/// <summary>
/// </summary>
public record Gift : FlickrEntityBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("gift_eligible")]
    public bool GiftEligible { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("eligible_durations")]
    public List<string> EligibleDurations { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("new_flow")]
    public bool NewFlow { get; set; }
}
