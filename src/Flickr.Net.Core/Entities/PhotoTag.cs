using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("tag")]
public record PhotoTag : TagBase, IFlickrEntity<Id>
{
    [JsonProperty("id")]
    public Id Id { get; set; }

    [JsonProperty("author")]
    public string Author { get; set; }

    [JsonProperty("authorname")]
    public string Authorname { get; set; }

    [JsonProperty("raw")]
    public string Raw { get; set; }

    [JsonProperty("machine_tag")]
    public bool MachineTag { get; set; }
}
