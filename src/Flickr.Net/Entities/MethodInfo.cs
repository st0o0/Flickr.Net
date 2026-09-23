using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;
[FlickrJsonPropertyName("method")]
/// <summary>Detailed information about a Flickr API method.</summary>
public record MethodInfo : FlickrEntityBase
{    [JsonPropertyName("name")]
    /// <summary>The display name.</summary>
    public string? Name { get; init; }
    [JsonPropertyName("needslogin")]
    /// <summary>Whether this method requires authentication.</summary>
    public bool NeedsLogin { get; init; }
    [JsonPropertyName("description")]
    /// <summary>The description.</summary>
    public string? Description { get; init; }
    [JsonPropertyName("response")]
    /// <summary>The expected response format.</summary>
    public string? Response { get; init; }
    [JsonPropertyName("explanation")]
    /// <summary>The explanation text.</summary>
    public string? Explanation { get; init; }
    [JsonPropertyName("arguments")]
    public List<Argument>? Arguments { get; init; }
    [JsonPropertyName("errors")]
    public List<Error>? Errors { get; init; }
}
