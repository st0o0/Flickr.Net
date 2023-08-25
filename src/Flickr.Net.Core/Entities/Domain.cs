using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("domain")]
public record Domain : FlickrEntityBase
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("views")]
    public int Views { get; set; }
}
