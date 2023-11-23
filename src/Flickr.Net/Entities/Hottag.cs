using System.Text.Json.Serialization;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("tag")]
public record Hottag : TagBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("thm_data")]
    public ThmData ThmData { get; set; }
}

/// <summary>
/// </summary>
public record ThmData
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("photos")]
    public ClusterPhotos Photos { get; set; }
}