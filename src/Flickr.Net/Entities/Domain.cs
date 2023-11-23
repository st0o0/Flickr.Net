using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

    /// <summary>
    /// </summary>
[FlickrJsonPropertyName("domain")]
public record Domain : FlickrEntityBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("views")]
    public int Views { get; set; }
}
