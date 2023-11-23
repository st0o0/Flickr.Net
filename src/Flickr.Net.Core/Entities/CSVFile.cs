using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

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
