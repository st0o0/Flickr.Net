using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;
[FlickrJsonPropertyName("photo")]
/// <summary>Contains EXIF data for a specific photo.</summary>
public record PhotoExif : PhotoBase
{    [JsonPropertyName("farm")]
    /// <summary>The farm identifier used in URL construction.</summary>
    public int Farm { get; init; }
    [JsonPropertyName("camera")]
    /// <summary>The camera model used.</summary>
    public string? Camera { get; init; }
    [JsonPropertyName("exif")]
    public List<Exif>? Exifs { get; init; }
}
