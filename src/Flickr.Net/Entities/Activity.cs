using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;
/// <summary>Represents activity (comments, notes, etc.) on a photo or photoset.</summary>
public record Activity : FlickrEntityBase
{    [JsonPropertyName("event")]
    /// <summary>The list of activity events.</summary>
    public List<Event> Events { get; init; } = [];
}
