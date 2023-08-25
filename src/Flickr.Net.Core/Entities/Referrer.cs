using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("referrer")]
public record Referrer : FlickrEntityBase
{
    [JsonPropertyName("url")]
    public string Url { get; set; }

    [JsonPropertyName("views")]
    public int Views { get; set; }

    [JsonPropertyName("searchterm")]
    public string Searchterm { get; set; }
}
