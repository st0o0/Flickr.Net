using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;
/// <summary>Represents a note (annotation) on a photo.</summary>
public record Note : FlickrEntityBase<Id>
{    [JsonPropertyName("author")]
    /// <summary>The NSID of the author.</summary>
    public string? Author { get; init; }
    [JsonPropertyName("authorname")]
    /// <summary>The display name of the author.</summary>
    public string? Authorname { get; init; }
    [JsonPropertyName("x")]
    /// <summary>The X coordinate.</summary>
    public int X { get; init; }
    [JsonPropertyName("y")]
    /// <summary>The Y coordinate.</summary>
    public int Y { get; init; }
    [JsonPropertyName("w")]
    /// <summary>The width.</summary>
    public int W { get; init; }
    [JsonPropertyName("h")]
    /// <summary>The height.</summary>
    public int H { get; init; }
    [JsonPropertyName("_content")]
    /// <summary>The text content.</summary>
    public string? Content { get; init; }
}
