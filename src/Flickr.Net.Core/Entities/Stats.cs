using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("stats")]
public record Stats : FlickrEntityBase
{
    [JsonPropertyName("views")]
    public int Views { get; set; }

    [JsonPropertyName("comments")]
    public int Comments { get; set; }

    [JsonPropertyName("favorites")]
    public int Favorites { get; set; }
}
