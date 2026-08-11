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
    /// <summary>
    /// </summary>
    [JsonPropertyName("datetaken")]
    public DateTime DateTaken { get; set; }

    /// <summary>
    /// The description of the photo.
    /// </summary>
    [JsonPropertyName("description")]
    public Description Description { get; set; }

    /// <summary>
    /// A space-delimited list of all tags on the photo. Only populated
    /// when PhotoSearchExtras.Tags is included in the search's Extras.
    /// </summary>
    [JsonPropertyName("tags")]
    public string? Tags { get; set; }
}