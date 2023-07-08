using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record GeoPermissions : FlickrEntityBase
{
    [JsonProperty("ispublic")]
    public bool IsPublic { get; set; }

    [JsonProperty("iscontact")]
    public bool IsContact { get; set; }

    [JsonProperty("isfriend")]
    public bool IsFriend { get; set; }

    [JsonProperty("isfamily")]
    public bool IsFamily { get; set; }
}
