using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("photo")]
public record StatsPhoto : UltraDeluxePhotoBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("stats")]
    public Stats Stats { get; set; }
}
