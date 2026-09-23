using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;
[FlickrJsonPropertyName("photo")]
/// <summary>Represents a photo returned by a Flickr Panda.</summary>
public record PandaPhoto : DeluxePhotoBase
{    [JsonPropertyName("ownername")]
    /// <summary>The display name of the owner.</summary>
    public string? OwnerName { get; init; }
}
