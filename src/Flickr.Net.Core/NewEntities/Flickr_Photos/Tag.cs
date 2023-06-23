using Flickr.Net.Core.Bases;
using Newtonsoft.Json;

namespace Flickr.Net.Core;

public record Tag : FlickrEntityBase<Id>
{
    [JsonProperty("author")]
    public string Author { get; set; }

    [JsonProperty("authorname")]
    public string Authorname { get; set; }

    [JsonProperty("raw")]
    public string Raw { get; set; }

    [JsonProperty("_content")]
    public string Content { get; set; }

    [JsonProperty("machine_tag")]
    public bool MachineTag { get; set; }
}
