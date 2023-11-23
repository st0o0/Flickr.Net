using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("photo")]
public record CoverPhoto : FlickrEntityBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("width")]
    public int Width { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("height")]
    public int Height { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("is_primary")]
    public bool IsPrimary { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("is_video")]
    public bool IsVideo { get; set; }
}