using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("csvfiles")]
public record CSVFile : FlickrEntityBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("href")]
    public string Href { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("date")]
    public DateOnly Date { get; set; }
}
