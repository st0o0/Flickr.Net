using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;
[FlickrJsonPropertyName("cluster")]
/// <summary>Represents a tag cluster — a group of related tags.</summary>
public record Cluster : FlickrEntityBase
{    [JsonPropertyName("total")]
    /// <summary>The total count.</summary>
    public int Total { get; init; }
    [JsonPropertyName("tag")]
    /// <summary>The tags.</summary>
    public List<ClusterTag> Tags { get; init; } = [];
}
