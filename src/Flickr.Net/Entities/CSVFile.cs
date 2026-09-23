using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

[FlickrJsonPropertyName("csvfiles")]
/// <summary>Represents a downloadable CSV stats file from Flickr.</summary>
public record CSVFile : FlickrEntityBase
{
    [JsonPropertyName("href")]
    /// <summary>The download URL.</summary>
    public string? Href { get; init; }
    [JsonPropertyName("type")]
    /// <summary>The type.</summary>
    public string? Type { get; init; }
    [JsonPropertyName("date")]
    /// <summary>The date.</summary>
    public DateOnly Date { get; init; }
}
