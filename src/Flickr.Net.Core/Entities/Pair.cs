using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Pair : FlickrEntityBase
{
    [JsonPropertyName("namespace")]
    public string Namespace { get; set; }

    [JsonPropertyName("predicate")]
    public string Predicate { get; set; }

    [JsonPropertyName("usage")]
    public string Usage { get; set; }

    [JsonPropertyName("_content")]
    public string Content { get; set; }
}