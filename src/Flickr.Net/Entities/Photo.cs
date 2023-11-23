using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("photo")]
public record Photo : UltraDeluxePhotoBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("dateadded")]
    public DateTime AddedDate { get; set; }
}