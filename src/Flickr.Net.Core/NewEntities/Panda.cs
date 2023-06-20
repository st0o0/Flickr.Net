using Newtonsoft.Json;

namespace Flickr.Net.Core.NewEntities;

public class Panda
{
    [JsonProperty("_content")]
    public string Content { get; set; }
}