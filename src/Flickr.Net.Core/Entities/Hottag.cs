using System.Text.Json.Serialization;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

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