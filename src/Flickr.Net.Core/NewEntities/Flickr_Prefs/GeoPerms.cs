using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record GeoPerms : FlickrEntityBase<NsId>
{
    [JsonProperty("geoperms")]
    public GeoPermissionType GeoPermissions { get; set; }

    [JsonProperty("importgeoexif")]
    public bool ImportGeoExif { get; set; }
}
