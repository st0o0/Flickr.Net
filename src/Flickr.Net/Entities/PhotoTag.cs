using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

[FlickrJsonPropertyName("tag")]
/// <summary>Represents a tag applied to a specific photo.</summary>
public record PhotoTag : TagBase, IFlickrEntity<Id>
{
    [JsonPropertyName("id")]
    public Id Id { get; init; } = default!;
    [JsonPropertyName("author")]
    /// <summary>The NSID of the author.</summary>
    public string? Author { get; init; }
    [JsonPropertyName("authorname")]
    /// <summary>The display name of the author.</summary>
    public string? Authorname { get; init; }
    [JsonPropertyName("raw")]
    /// <summary>The raw EXIF value.</summary>
    public string? Raw { get; init; }
    [JsonPropertyName("machine_tag")]
    /// <summary>Whether this is a machine tag.</summary>
    public bool MachineTag { get; init; }
}
