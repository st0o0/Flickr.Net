using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("stats")]
public record Stats : FlickrEntityBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("views")]
    public int Views { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("comments")]
    public int Comments { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("favorites")]
    public int Favorites { get; set; }
}
