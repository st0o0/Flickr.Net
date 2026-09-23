using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;
/// <summary>Represents a photo license type available on Flickr.</summary>
public record License : FlickrEntityBase
{
    [JsonPropertyName("id")]
    /// <summary>The unique identifier.</summary>
    public int Id { get; init; }
    [JsonPropertyName("name")]
    /// <summary>The display name.</summary>
    public string? Name { get; init; }
    [JsonPropertyName("url")]
    /// <summary>The URL.</summary>
    public string? Url { get; init; }
}
