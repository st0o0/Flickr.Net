using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

/// <summary>
/// </summary>
public record Activity : FlickrEntityBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("event")]
    public List<Event> Events { get; set; } = [];
}