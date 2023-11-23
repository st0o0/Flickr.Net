using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

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
