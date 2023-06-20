using Newtonsoft.Json;

namespace Flickr.Net.Core;

public class Activity
{
    [JsonProperty("event")]
    public List<Event> Events { get; set; } = new List<Event>();
}