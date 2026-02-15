using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Enums;

namespace Flickr.Net;

/// <summary>
/// </summary>
public record GeoPerms : FlickrEntityBase<NsId>
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("geoperms")]
    public GeoPermissionType GeoPermissions { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("importgeoexif")]
    public bool ImportGeoExif { get; set; }
}
