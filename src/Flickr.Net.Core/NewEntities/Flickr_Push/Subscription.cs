using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Subscription : FlickrEntityBase
{
    [JsonProperty("topic")]
    public string Topic { get; set; }

    [JsonProperty("callback")]
    public string Callback { get; set; }

    [JsonProperty("pending")]
    public string Pending { get; set; }

    [JsonProperty("date_create")]
    public DateTime CreateDate { get; set; }

    [JsonProperty("lease_seconds")]
    public string LeaseSeconds { get; set; }

    [JsonProperty("expiry")]
    public DateTime Expiry { get; set; }

    [JsonProperty("verify_attempts")]
    public int VerifyAttempts { get; set; }
}
