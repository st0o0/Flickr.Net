using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

/// <summary>
/// </summary>
public record Image : FlickrEntityBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("small")]
    public string Small { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("large")]
    public string Large { get; set; }
}