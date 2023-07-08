using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record TagBase : FlickrEntityBase
{
    [JsonProperty("_content")]
    public string Content { get; set; }
}
