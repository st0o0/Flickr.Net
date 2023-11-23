using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

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