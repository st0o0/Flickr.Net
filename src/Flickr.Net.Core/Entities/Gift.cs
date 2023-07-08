using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Gift : FlickrEntityBase
{
    [JsonProperty("gift_eligible")]
    public bool GiftEligible { get; set; }

    [JsonProperty("eligible_durations")]
    public List<string> EligibleDurations { get; set; }

    [JsonProperty("new_flow")]
    public bool NewFlow { get; set; }
}
