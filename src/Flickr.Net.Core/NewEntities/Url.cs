using Newtonsoft.Json;

namespace Flickr.Net.Core.NewEntities;

public class Url
{
    [JsonProperty("type")]
    public UrlType Type { get; set; }

    [JsonProperty("_content")]
    public string Content { get; set; }
}