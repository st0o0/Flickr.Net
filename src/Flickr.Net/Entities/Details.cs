using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;

/// <summary>
/// </summary>
public record Details : FlickrEntityBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("megapixels")]
    public string MegaPixels { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("zoom")]
    public string Zoom { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("lcd_size")]
    public string LcdSize { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("storage_type")]
    public string StorageType { get; set; }
}