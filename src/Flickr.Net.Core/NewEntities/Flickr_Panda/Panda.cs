using Flickr.Net.Core.Bases;
using Newtonsoft.Json;

namespace Flickr.Net.Core;

public record Panda : FlickrEntityBase
{
    [JsonProperty("_content")]
    public string Content { get; set; }
}