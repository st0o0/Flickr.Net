using Newtonsoft.Json;

namespace Flickr.Net.Core.NewEntities;

public class Predicate
{
    [JsonProperty("usage")]
    public string Usage { get; set; }

    [JsonProperty("namespaces")]
    public string Namespaces { get; set; }

    [JsonProperty("_content")]
    public string Content { get; set; }
}