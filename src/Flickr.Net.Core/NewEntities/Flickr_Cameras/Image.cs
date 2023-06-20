using Newtonsoft.Json;

namespace Flickr.Net.Core.NewEntities.Flickr_Cameras;

public class Image
{
    [JsonProperty("small")]
    public string Small { get; set; }

    [JsonProperty("large")]
    public string Large { get; set; }
}