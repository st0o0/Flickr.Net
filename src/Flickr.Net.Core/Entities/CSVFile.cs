using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("csvfiles")]
public record CSVFile : FlickrEntityBase
{
    [JsonProperty("href")]
    public string Href { get; set; }

    [JsonProperty("type")]
    public string Type { get; set; }

    [JsonProperty("date")]
    public DateOnly Date { get; set; }
}
