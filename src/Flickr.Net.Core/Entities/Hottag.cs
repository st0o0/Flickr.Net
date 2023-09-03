using System.Text.Json.Serialization;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("tag")]
public record Hottag : TagBase
{
    [JsonPropertyName("thm_data")]
    public ThmData ThmData { get; set; }
}

public record ThmData
{
    [JsonPropertyName("photos")]
    public ClusterPhotos Photos { get; set; }
}