using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;
/// <summary>Represents a machine tag namespace-predicate pair.</summary>
public record Pair : FlickrEntityBase
{    [JsonPropertyName("namespace")]
    public string? Namespace { get; init; }
    [JsonPropertyName("predicate")]
    /// <summary>The predicate name.</summary>
    public string? Predicate { get; init; }
    [JsonPropertyName("usage")]
    public string? Usage { get; init; }
    [JsonPropertyName("_content")]
    /// <summary>The text content.</summary>
    public string? Content { get; init; }
}
