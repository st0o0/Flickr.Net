using Flickr.Net.Core.Bases;
using Newtonsoft.Json;

namespace Flickr.Net.Core;

public record Institution : FlickrEntityBase<NsId>
{
    [JsonProperty("date_launch")]
    public DateTime LaunchDate { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("urls")]
    public Urls Urls { get; set; }
}