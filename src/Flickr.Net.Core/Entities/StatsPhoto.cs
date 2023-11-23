using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

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
