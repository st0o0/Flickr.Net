using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("tag")]
public record PhotoTag : TagBase, IFlickrEntity<Id>
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("id")]
    public Id Id { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("author")]
    public string Author { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("authorname")]
    public string Authorname { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("raw")]
    public string Raw { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("machine_tag")]
    public bool MachineTag { get; set; }
}
