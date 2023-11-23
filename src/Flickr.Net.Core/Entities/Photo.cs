using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

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