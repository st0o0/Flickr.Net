using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("tag")]
public record Hottag : TagBase
{
    [JsonProperty("thm_data")]
    public ThmData ThmData { get; set; }
}

public record ThmData
{
    [JsonProperty("photos")]
    public ClusterPhotos Photos { get; set; }
}