using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("who")]
public record Who : FlickrEntityBase<Id>
{
    [JsonPropertyName("tags")]
    public UserTags Tags { get; set; }
}
