using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("photo")]
public record PhotoExif : PhotoBase
{
    [JsonProperty("farm")]
    public int Farm { get; set; }

    [JsonProperty("camera")]
    public string Camera { get; set; }

    [JsonProperty("exif")]
    public List<Exif> Exifs { get; set; }
}
