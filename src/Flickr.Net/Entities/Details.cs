using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;
/// <summary>Represents technical details of a camera model.</summary>
public record Details : FlickrEntityBase
{
    [JsonPropertyName("megapixels")]
    /// <summary>The megapixel count.</summary>
    public string? MegaPixels { get; init; }
    [JsonPropertyName("zoom")]
    /// <summary>The optical zoom range.</summary>
    public string? Zoom { get; init; }
    [JsonPropertyName("lcd_size")]
    /// <summary>The LCD screen size.</summary>
    public string? LcdSize { get; init; }
    [JsonPropertyName("storage_type")]
    /// <summary>The storage media type.</summary>
    public string? StorageType { get; init; }
}
