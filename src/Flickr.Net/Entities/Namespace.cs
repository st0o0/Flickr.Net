using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;
/// <summary>Represents a machine tag namespace.</summary>
public record Namespace : FlickrEntityBase
{    [JsonPropertyName("usage")]
    public string? Usage { get; init; }
    [JsonPropertyName("predicates")]
    /// <summary>The available predicates.</summary>
    public string? Predicates { get; init; }
    [JsonPropertyName("_content")]
    /// <summary>The text content.</summary>
    public string? Content { get; init; }
}
