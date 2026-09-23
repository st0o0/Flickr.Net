using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Enums;

namespace Flickr.Net;
/// <summary>Represents a user's default geo permission preferences.</summary>
public record GeoPerms : FlickrEntityBase<NsId>
{    [JsonPropertyName("geoperms")]
    /// <summary>The default geo permission type.</summary>
    public GeoPermissionType GeoPermissions { get; init; }
    [JsonPropertyName("importgeoexif")]
    /// <summary>Whether to import geo data from EXIF tags.</summary>
    public bool ImportGeoExif { get; init; }
}
