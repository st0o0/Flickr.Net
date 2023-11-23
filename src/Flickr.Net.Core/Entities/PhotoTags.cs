using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

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
