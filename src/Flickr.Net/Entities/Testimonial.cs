using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;

/// <summary>
/// Represents a user testimonial on Flickr, containing feedback one user has written about another.
/// </summary>
public record Testimonial : FlickrEntityBase<Id>
{
    /// <summary>The unique identifier of the testimonial.</summary>
    [JsonPropertyName("testimonial_id")]
    public string? TestimonialId { get; init; }

    /// <summary>The NSID of the user who wrote the testimonial.</summary>
    [JsonPropertyName("user_id")]
    public string? UserId { get; init; }

    /// <summary>The username of the testimonial author.</summary>
    [JsonPropertyName("username")]
    public string? Username { get; init; }

    /// <summary>The NSID of the user the testimonial is about.</summary>
    [JsonPropertyName("target_user_id")]
    public string? TargetUserId { get; init; }

    /// <summary>The text content of the testimonial.</summary>
    [JsonPropertyName("_content")]
    public string? Content { get; init; }

    /// <summary>The date the testimonial was created as a Unix timestamp string.</summary>
    [JsonPropertyName("date_create")]
    public string? DateCreate { get; init; }

    /// <summary>Whether the testimonial has been approved by the target user.</summary>
    [JsonPropertyName("approved")]
    public bool? Approved { get; init; }
}
