using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("photo")]
public record Photo : ExtendedPhotoBase
{
    [JsonProperty("ispublic")]
    public bool IsPublic { get; set; }

    [JsonProperty("isfriend")]
    public bool IsFriend { get; set; }

    [JsonProperty("isfamily")]
    public bool IsFamily { get; set; }

    [JsonProperty("dateadded")]
    public DateTime AddedDate { get; set; }
}