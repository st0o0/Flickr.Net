using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record License : FlickrEntityBase
{
    [JsonProperty("id")]
    public int Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("url")]
    public string Url { get; set; }
}
