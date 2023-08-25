using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("tag")]
public record PhotoTag : TagBase, IFlickrEntity<Id>
{
    [JsonPropertyName("id")]
    public Id Id { get; set; }

    [JsonPropertyName("author")]
    public string Author { get; set; }

    [JsonPropertyName("authorname")]
    public string Authorname { get; set; }

    [JsonPropertyName("raw")]
    public string Raw { get; set; }

    [JsonPropertyName("machine_tag")]
    public bool MachineTag { get; set; }
}
