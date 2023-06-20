using Flickr.Net.Core.Bases;
using Newtonsoft.Json;

namespace Flickr.Net.Core;

public record Image : FlickrEntityBase
{
    [JsonProperty("small")]
    public string Small { get; set; }

    [JsonProperty("large")]
    public string Large { get; set; }
}