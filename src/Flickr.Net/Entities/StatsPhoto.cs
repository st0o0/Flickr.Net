using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

[FlickrJsonPropertyName("photo")]
/// <summary>Represents a photo with its view statistics.</summary>
public record StatsPhoto : UltraDeluxePhotoBase
{
    [JsonPropertyName("stats")]
    public Stats? Stats { get; init; }
}
