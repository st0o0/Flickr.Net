using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

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