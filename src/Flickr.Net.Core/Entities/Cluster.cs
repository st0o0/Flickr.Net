using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("cluster")]
public record Cluster : FlickrEntityBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("total")]
    public int Total { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("tag")]
    public List<ClusterTag> Tags { get; set; }
}
