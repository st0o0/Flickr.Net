using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("who")]
public record Who : FlickrEntityBase<Id>
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("tags")]
    public UserTags Tags { get; set; }
}
