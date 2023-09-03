using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Value : FlickrEntityBase
{
    [JsonPropertyName("usage")]
    public string Usage { get; set; }

    [JsonPropertyName("namespace")]
    public string Namespace { get; set; }

    [JsonPropertyName("predicate")]
    public string Predicate { get; set; }

    [JsonPropertyName("first_added")]
    public DateTime FirstAdded { get; set; }

    [JsonPropertyName("last_added")]
    public DateTime LastAdded { get; set; }

    [JsonPropertyName("_content")]
    public string Content { get; set; }
}