using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("photo")]
public record PandaPhoto : DeluxePhotoBase
{
    [JsonPropertyName("ownername")]
    public string OwnerName { get; set; }
}