using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

[FlickrJsonPropertyName("domain")]
/// <summary>Represents a referring domain in Flickr stats.</summary>
public record Domain : FlickrEntityBase
{
    [JsonPropertyName("name")]
    /// <summary>The display name.</summary>
    public string? Name { get; init; }
    [JsonPropertyName("views")]
    /// <summary>The number of views.</summary>
    public int Views { get; init; }
}
