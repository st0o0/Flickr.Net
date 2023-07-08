using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("photo")]
public record PhotosetPhoto : PhotoBase
{
    [JsonProperty("farm")]
    public int Farm { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("isprimary")]
    public bool IsPrimary { get; set; }

    [JsonProperty("ispublic")]
    public bool IsPublic { get; set; }

    [JsonProperty("isfriend")]
    public bool IsFriend { get; set; }

    [JsonProperty("isfamily")]
    public bool IsFamily { get; set; }
}
