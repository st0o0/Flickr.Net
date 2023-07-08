using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Brand : FlickrEntityBase<Id>
{
    [JsonProperty("_content")]
    public string Content { get; set; }
}