using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;
[FlickrJsonPropertyName("photo")]
/// <summary>Contains the collection of tags for a photo.</summary>
public record PhotoTags : FlickrEntityBase<Id>
{    [JsonPropertyName("tags")]
    public PhotoInfoTags? Tags { get; init; }
}
