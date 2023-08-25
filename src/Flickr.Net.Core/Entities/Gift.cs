using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Gift : FlickrEntityBase
{
    [JsonPropertyName("gift_eligible")]
    public bool GiftEligible { get; set; }

    [JsonPropertyName("eligible_durations")]
    public List<string> EligibleDurations { get; set; }

    [JsonPropertyName("new_flow")]
    public bool NewFlow { get; set; }
}
