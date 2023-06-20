using Flickr.Net.Core.Bases;
using Newtonsoft.Json;

namespace Flickr.Net.Core;

public record Predicate : FlickrEntityBase
{
    [JsonProperty("usage")]
    public string Usage { get; set; }

    [JsonProperty("namespaces")]
    public string Namespaces { get; set; }

    [JsonProperty("_content")]
    public string Content { get; set; }
}