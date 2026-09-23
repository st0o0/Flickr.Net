using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

/// <summary>Represents a raw tag with its cleaned version and the original raw values entered by users.</summary>
[FlickrJsonPropertyName("tag")]
public record RawTag : FlickrEntityBase
{
    /// <summary>The cleaned/normalized version of the tag.</summary>
    [JsonPropertyName("clean")]
    public string? Clean { get; init; }

    /// <summary>The list of original raw tag values entered by users for this cleaned tag.</summary>
    [JsonPropertyName("raw")]
    public List<RawTagValue>? Raw { get; init; }
}

/// <summary>Represents a single raw tag value as originally entered by a user.</summary>
[FlickrJsonPropertyName("raw")]
public record RawTagValue : FlickrEntityBase
{
    /// <summary>The original tag text as entered by the user.</summary>
    [JsonPropertyName("_content")]
    public string? Content { get; init; }
}
