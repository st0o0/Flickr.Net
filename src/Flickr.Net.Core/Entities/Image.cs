using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Image : FlickrEntityBase
{
    [JsonPropertyName("small")]
    public string Small { get; set; }

    [JsonPropertyName("large")]
    public string Large { get; set; }
}