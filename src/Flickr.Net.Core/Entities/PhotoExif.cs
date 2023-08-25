using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("photo")]
public record PhotoExif : PhotoBase
{
    [JsonPropertyName("farm")]
    public int Farm { get; set; }

    [JsonPropertyName("camera")]
    public string Camera { get; set; }

    [JsonPropertyName("exif")]
    public List<Exif> Exifs { get; set; }
}
