using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Details : FlickrEntityBase
{
    [JsonPropertyName("megapixels")]
    public string MegaPixels { get; set; }

    [JsonPropertyName("zoom")]
    public string Zoom { get; set; }

    [JsonPropertyName("lcd_size")]
    public string LcdSize { get; set; }

    [JsonPropertyName("storage_type")]
    public string StorageType { get; set; }
}