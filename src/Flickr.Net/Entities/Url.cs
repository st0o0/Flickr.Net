using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Enums;

namespace Flickr.Net;
/// <summary>Represents a URL associated with a Flickr entity.</summary>
public record Url : FlickrEntityBase
{
    [JsonPropertyName("type")]
    /// <summary>The type.</summary>
    public UrlType Type { get; init; }
    [JsonPropertyName("_content")]
    /// <summary>The text content.</summary>
    public string? Content { get; init; }
}
