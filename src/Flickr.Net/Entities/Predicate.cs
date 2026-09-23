using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;
/// <summary>Represents a machine tag predicate.</summary>
public record Predicate : FlickrEntityBase
{    [JsonPropertyName("usage")]
    public string? Usage { get; init; }
    [JsonPropertyName("namespaces")]
    public string? Namespaces { get; init; }
    [JsonPropertyName("_content")]
    /// <summary>The text content.</summary>
    public string? Content { get; init; }
}
