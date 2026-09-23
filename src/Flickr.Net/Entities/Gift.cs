using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;
/// <summary>Represents gift/pro subscription eligibility information.</summary>
public record Gift : FlickrEntityBase
{    [JsonPropertyName("gift_eligible")]
    /// <summary>Whether the user is eligible to receive gifts.</summary>
    public bool GiftEligible { get; init; }
    [JsonPropertyName("eligible_durations")]
    /// <summary>The eligible subscription durations for gifting.</summary>
    public List<string> EligibleDurations { get; init; } = [];
    [JsonPropertyName("new_flow")]
    /// <summary>Whether the new gift flow is active.</summary>
    public bool NewFlow { get; init; }
}
