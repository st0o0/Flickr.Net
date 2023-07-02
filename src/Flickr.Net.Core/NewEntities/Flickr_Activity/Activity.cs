using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Activity : FlickrEntityBase
{
    [JsonProperty("event")]
    public List<Event> Events { get; set; } = new List<Event>();
}