using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;
/// <summary>Represents camera product images in small and large sizes.</summary>
public record Image : FlickrEntityBase
{
    [JsonPropertyName("small")]
    /// <summary>The small image URL.</summary>
    public string? Small { get; init; }
    [JsonPropertyName("large")]
    /// <summary>The large image URL.</summary>
    public string? Large { get; init; }
}
