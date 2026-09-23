using System.Text.Json.Serialization;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;
[FlickrJsonPropertyName("tag")]
/// <summary>Represents a hot (trending) tag with associated photos.</summary>
public record Hottag : TagBase
{    [JsonPropertyName("thm_data")]
    /// <summary>The thumbnail photo data.</summary>
    public ThmData? ThmData { get; init; }
}
/// <summary>Contains thumbnail photo data for a hot tag.</summary>
public record ThmData
{    [JsonPropertyName("photos")]
    /// <summary>The number of photos.</summary>
    public ClusterPhotos? Photos { get; init; }
}
