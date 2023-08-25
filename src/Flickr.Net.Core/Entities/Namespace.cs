using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Namespace : FlickrEntityBase
{
    [JsonPropertyName("usage")]
    public string Usage { get; set; }

    [JsonPropertyName("predicates")]
    public string Predicates { get; set; }

    [JsonPropertyName("_content")]
    public string Content { get; set; }
}