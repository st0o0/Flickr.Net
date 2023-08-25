using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record GeoPermissions : FlickrEntityBase
{
    [JsonPropertyName("ispublic")]
    public bool IsPublic { get; set; }

    [JsonPropertyName("iscontact")]
    public bool IsContact { get; set; }

    [JsonPropertyName("isfriend")]
    public bool IsFriend { get; set; }

    [JsonPropertyName("isfamily")]
    public bool IsFamily { get; set; }
}
