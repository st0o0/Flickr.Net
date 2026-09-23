using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;
/// <summary>Represents a machine tag value.</summary>
public record Value : FlickrEntityBase
{
    [JsonPropertyName("usage")]
    public string? Usage { get; init; }
    [JsonPropertyName("namespace")]
    public string? Namespace { get; init; }
    [JsonPropertyName("predicate")]
    /// <summary>The predicate name.</summary>
    public string? Predicate { get; init; }
    [JsonPropertyName("first_added")]
    public DateTime FirstAdded { get; init; }
    [JsonPropertyName("last_added")]
    public DateTime LastAdded { get; init; }
    [JsonPropertyName("_content")]
    /// <summary>The text content.</summary>
    public string? Content { get; init; }
}
