using Flickr.Net.Core.Bases;
using Newtonsoft.Json;

namespace Flickr.Net.Core;

public record Value : FlickrEntityBase
{
    [JsonProperty("usage")]
    public string Usage { get; set; }

    [JsonProperty("namespace")]
    public string Namespace { get; set; }

    [JsonProperty("predicate")]
    public string Predicate { get; set; }

    [JsonProperty("first_added")]
    public DateTime FirstAdded { get; set; }

    [JsonProperty("last_added")]
    public DateTime LastAdded { get; set; }

    [JsonProperty("_content")]
    public string Content { get; set; }
}