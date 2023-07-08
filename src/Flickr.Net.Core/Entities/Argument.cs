using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("error")]
public record Argument
{
    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("optional")]
    public bool Optional { get; set; }

    [JsonProperty("_content")]
    public string Content { get; set; }
}
