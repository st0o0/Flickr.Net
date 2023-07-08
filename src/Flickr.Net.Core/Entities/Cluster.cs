using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("cluster")]
public record Cluster : FlickrEntityBase
{
    [JsonProperty("total")]
    public int Total { get; set; }

    [JsonProperty("tag")]
    public List<ClusterTag> Tags { get; set; }
}
