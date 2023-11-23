using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;

/// <summary>
/// </summary>
public record License : FlickrEntityBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("id")]
    public int Id { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }
}
