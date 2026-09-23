using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;
[FlickrJsonPropertyName("referrer")]
/// <summary>Represents a referring URL in Flickr stats.</summary>
public record Referrer : FlickrEntityBase
{    [JsonPropertyName("url")]
    /// <summary>The URL.</summary>
    public string? Url { get; init; }
    [JsonPropertyName("views")]
    /// <summary>The number of views.</summary>
    public int Views { get; init; }
    [JsonPropertyName("searchterm")]
    public string? Searchterm { get; init; }
}
