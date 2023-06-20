using Flickr.Net.Core.Bases;
using Newtonsoft.Json;

namespace Flickr.Net.Core;

public record Brand : FlickrEntityBase<Id>
{
    [JsonProperty("_content")]
    public string Content { get; set; }
}