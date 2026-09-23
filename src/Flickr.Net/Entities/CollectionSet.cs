using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;
/// <summary>Represents a photoset reference within a collection.</summary>
public record CollectionSet : FlickrEntityBase<Id>
{    [JsonPropertyName("title")]
    /// <summary>The title.</summary>
    public string? Title { get; init; }
    [JsonPropertyName("description")]
    /// <summary>The description.</summary>
    public string? Description { get; init; }
}
