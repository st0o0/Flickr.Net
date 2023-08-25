using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("csvfiles")]
public record CSVFile : FlickrEntityBase
{
    [JsonPropertyName("href")]
    public string Href { get; set; }

    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("date")]
    public DateOnly Date { get; set; }
}
