using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;
[FlickrJsonPropertyName("collection")]
/// <summary>Represents a collection of photosets organized by the user.</summary>
public record Collection : FlickrEntityBase<Id>
{    [JsonPropertyName("title")]
    /// <summary>The title.</summary>
    public string? Title { get; init; }
    [JsonPropertyName("description")]
    /// <summary>The description.</summary>
    public string? Description { get; init; }
    [JsonPropertyName("child_count")]
    /// <summary>The number of child collections or sets.</summary>
    public int ChildCount { get; init; }
    [JsonPropertyName("datecreate")]
    /// <summary>The creation date.</summary>
    public DateTime CreateDate { get; init; }
    [JsonPropertyName("iconlarge")]
    /// <summary>The URL of the large collection icon.</summary>
    public string? LargeIcon { get; init; }
    [JsonPropertyName("iconsmall")]
    /// <summary>The URL of the small collection icon.</summary>
    public string? SmallIcon { get; init; }
    [JsonPropertyName("server")]
    /// <summary>The server identifier used in URL construction.</summary>
    public string? Server { get; init; }
    [JsonPropertyName("secret")]
    /// <summary>The photo secret used in URL construction.</summary>
    public string? Secret { get; init; }
    [JsonPropertyName("iconphotos")]
    /// <summary>The photos used for the collection icon mosaic.</summary>
    public Photos? IconPhotos { get; init; }
    [JsonPropertyName("set")]
    /// <summary>The photosets within this collection.</summary>
    public List<CollectionSet> Sets { get; init; } = [];
}
