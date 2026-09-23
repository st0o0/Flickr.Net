using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;
/// <summary>Represents a camera brand returned by the Flickr cameras API.</summary>
public record Brand : FlickrEntityBase<Id>
{    [JsonPropertyName("_content")]
    /// <summary>The text content.</summary>
    public string? Content { get; init; }
}
