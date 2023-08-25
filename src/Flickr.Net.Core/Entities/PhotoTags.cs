using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("photo")]
public record PhotoTags : FlickrEntityBase<Id>
{
    [JsonPropertyName("tags")]
    public PhotoInfoTags Tags { get; set; }
}
