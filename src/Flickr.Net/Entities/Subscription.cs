using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;
/// <summary>Represents a push notification subscription.</summary>
public record Subscription : FlickrEntityBase
{    [JsonPropertyName("topic")]
    /// <summary>The topic.</summary>
    public string? Topic { get; init; }
    [JsonPropertyName("callback")]
    /// <summary>The callback URL.</summary>
    public string? Callback { get; init; }
    [JsonPropertyName("pending")]
    /// <summary>Whether the subscription is pending.</summary>
    public string? Pending { get; init; }
    [JsonPropertyName("date_create")]
    /// <summary>The creation date.</summary>
    public DateTime CreateDate { get; init; }
    [JsonPropertyName("lease_seconds")]
    public string? LeaseSeconds { get; init; }
    [JsonPropertyName("expiry")]
    public DateTime Expiry { get; init; }
    [JsonPropertyName("verify_attempts")]
    public int VerifyAttempts { get; init; }
}
