using Newtonsoft.Json;

namespace Flickr.Net.Core;

public class Brand
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("_content")]
    public string Content { get; set; }
}