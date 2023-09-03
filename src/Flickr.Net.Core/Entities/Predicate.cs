using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Predicate : FlickrEntityBase
{
    [JsonPropertyName("usage")]
    public string Usage { get; set; }

    [JsonPropertyName("namespaces")]
    public string Namespaces { get; set; }

    [JsonPropertyName("_content")]
    public string Content { get; set; }
}