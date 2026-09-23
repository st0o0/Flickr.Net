using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;
/// <summary>Represents the geo/location visibility permissions for a photo.</summary>
public record GeoPermissions : FlickrEntityBase
{    [JsonPropertyName("ispublic")]
    /// <summary>Whether the content is publicly visible.</summary>
    public bool IsPublic { get; init; }
    [JsonPropertyName("iscontact")]
    /// <summary>Whether the content is visible to contacts.</summary>
    public bool IsContact { get; init; }
    [JsonPropertyName("isfriend")]
    /// <summary>Whether the content is visible to friends.</summary>
    public bool IsFriend { get; init; }
    [JsonPropertyName("isfamily")]
    /// <summary>Whether the content is visible to family.</summary>
    public bool IsFamily { get; init; }
}
