using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;
/// <summary>Represents a blog service supported by Flickr.</summary>
public record Service : FlickrEntityBase<Id>
{
    [JsonPropertyName("_content")]
    /// <summary>The text content.</summary>
    public string? Content { get; init; }
}
