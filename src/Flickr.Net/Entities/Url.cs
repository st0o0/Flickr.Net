using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;

/// <summary>
/// </summary>
public record Url : FlickrEntityBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("type")]
    public UrlType Type { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("_content")]
    public string Content { get; set; }
}