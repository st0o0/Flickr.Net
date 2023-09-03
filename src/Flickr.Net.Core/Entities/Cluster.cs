using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("cluster")]
public record Cluster : FlickrEntityBase
{
    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("tag")]
    public List<ClusterTag> Tags { get; set; }
}
