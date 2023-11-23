using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;

/// <summary>
/// </summary>
public record Activity : FlickrEntityBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("event")]
    public List<Event> Events { get; set; } = [];
}