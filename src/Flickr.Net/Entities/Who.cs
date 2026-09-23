using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;
[FlickrJsonPropertyName("who")]
/// <summary>Represents the permissions for who can add metadata to a photo.</summary>
public record Who : FlickrEntityBase<Id>
{    [JsonPropertyName("tags")]
    public UserTags? Tags { get; init; }
}
