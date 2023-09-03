using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record GeoPerms : FlickrEntityBase<NsId>
{
    [JsonPropertyName("geoperms")]
    public GeoPermissionType GeoPermissions { get; set; }

    [JsonPropertyName("importgeoexif")]
    public bool ImportGeoExif { get; set; }
}
