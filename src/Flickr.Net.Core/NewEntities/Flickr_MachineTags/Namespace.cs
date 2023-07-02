using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Namespace : FlickrEntityBase
{
    [JsonProperty("usage")]
    public string Usage { get; set; }

    [JsonProperty("predicates")]
    public string Predicates { get; set; }

    [JsonProperty("_content")]
    public string Content { get; set; }
}