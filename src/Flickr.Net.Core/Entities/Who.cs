using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

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
