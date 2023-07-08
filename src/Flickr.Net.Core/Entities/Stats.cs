using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("stats")]
public record Stats : FlickrEntityBase
{
    [JsonProperty("views")]
    public int Views { get; set; }

    [JsonProperty("comments")]
    public int Comments { get; set; }

    [JsonProperty("favorites")]
    public int Favorites { get; set; }
}
