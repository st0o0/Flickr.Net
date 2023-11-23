using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("photo")]
public record PhotoTags : FlickrEntityBase<Id>
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("tags")]
    public PhotoInfoTags Tags { get; set; }
}
