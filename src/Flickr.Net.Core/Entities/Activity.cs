using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Activity : FlickrEntityBase
{
    [JsonPropertyName("event")]
    public List<Event> Events { get; set; } = new List<Event>();
}