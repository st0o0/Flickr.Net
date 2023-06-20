using Flickr.Net.Core.Bases;
using Newtonsoft.Json;

namespace Flickr.Net.Core;

public record Pair : FlickrEntityBase
{
    [JsonProperty("namespace")]
    public string Namespace { get; set; }

    [JsonProperty("predicate")]
    public string Predicate { get; set; }

    [JsonProperty("usage")]
    public string Usage { get; set; }

    [JsonProperty("_content")]
    public string Content { get; set; }
}