using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

[FlickrJsonPropertyName("stats")]
/// <summary>Represents view statistics for a date.</summary>
public record Stats : FlickrEntityBase
{
    [JsonPropertyName("views")]
    /// <summary>The number of views.</summary>
    public int Views { get; init; }
    [JsonPropertyName("comments")]
    /// <summary>The comments.</summary>
    public int Comments { get; init; }
    [JsonPropertyName("favorites")]
    /// <summary>The number of favorites.</summary>
    public int Favorites { get; init; }
}
