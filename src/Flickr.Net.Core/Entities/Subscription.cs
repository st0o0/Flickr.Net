using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Subscription : FlickrEntityBase
{
    [JsonPropertyName("topic")]
    public string Topic { get; set; }

    [JsonPropertyName("callback")]
    public string Callback { get; set; }

    [JsonPropertyName("pending")]
    public string Pending { get; set; }

    [JsonPropertyName("date_create")]
    public DateTime CreateDate { get; set; }

    [JsonPropertyName("lease_seconds")]
    public string LeaseSeconds { get; set; }

    [JsonPropertyName("expiry")]
    public DateTime Expiry { get; set; }

    [JsonPropertyName("verify_attempts")]
    public int VerifyAttempts { get; set; }
}
