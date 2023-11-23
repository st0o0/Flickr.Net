using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

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
