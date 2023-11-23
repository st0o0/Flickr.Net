using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;

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