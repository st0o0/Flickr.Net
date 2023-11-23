using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

/// <summary>
/// </summary>
public record GeoPermissions : FlickrEntityBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("ispublic")]
    public bool IsPublic { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("iscontact")]
    public bool IsContact { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("isfriend")]
    public bool IsFriend { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("isfamily")]
    public bool IsFamily { get; set; }
}
