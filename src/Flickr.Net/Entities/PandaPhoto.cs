using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("photo")]
public record PandaPhoto : DeluxePhotoBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("ownername")]
    public string OwnerName { get; set; }
}