using Newtonsoft.Json;

namespace Flickr.Net.Core.NewEntities.Flickr_Cameras;

public class Details
{
    [JsonProperty("megapixels")]
    public string MegaPixels { get; set; }

    [JsonProperty("zoom")]
    public string Zoom { get; set; }

    [JsonProperty("lcd_size")]
    public string LcdSize { get; set; }

    [JsonProperty("storage_type")]
    public string StorageType { get; set; }
}