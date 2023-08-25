using System.Text.Json.Serialization;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("error")]
public record Argument
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("optional")]
    public bool Optional { get; set; }

    [JsonPropertyName("_content")]
    public string Content { get; set; }
}
