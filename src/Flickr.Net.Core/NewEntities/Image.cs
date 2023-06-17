using Newtonsoft.Json;

namespace Flickr.Net.Core.NewEntities;

public class Image
{
    [JsonProperty("small")]
    public string Small { get; set; }

    [JsonProperty("large")]
    public string Large { get; set; }
}
