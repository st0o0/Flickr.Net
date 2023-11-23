using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;

/// <summary>
/// </summary>
public record Subscription : FlickrEntityBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("topic")]
    public string Topic { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("callback")]
    public string Callback { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("pending")]
    public string Pending { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("date_create")]
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("lease_seconds")]
    public string LeaseSeconds { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("expiry")]
    public DateTime Expiry { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("verify_attempts")]
    public int VerifyAttempts { get; set; }
}
