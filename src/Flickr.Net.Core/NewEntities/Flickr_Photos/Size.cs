using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Size : FlickrEntityBase
{
    [JsonProperty("label")]
    public string Label { get; set; }

    [JsonProperty("width")]
    public int Width { get; set; }

    [JsonProperty("height")]
    public int Height { get; set; }

    [JsonProperty("source")]
    public string Source { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }

    [JsonProperty("media")]
    public MediaType Media { get; set; }
}
