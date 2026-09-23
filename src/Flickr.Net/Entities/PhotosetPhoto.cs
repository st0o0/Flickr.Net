using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;
[FlickrJsonPropertyName("photo")]
/// <summary>Represents a photo within a photoset.</summary>
public record PhotosetPhoto : PhotoBase
{    [JsonPropertyName("farm")]
    /// <summary>The farm identifier used in URL construction.</summary>
    public int Farm { get; init; }
    [JsonPropertyName("title")]
    /// <summary>The title.</summary>
    public string? Title { get; init; }
    [JsonPropertyName("isprimary")]
    /// <summary>Whether this is the primary photo.</summary>
    public bool IsPrimary { get; init; }
    [JsonPropertyName("ispublic")]
    /// <summary>Whether the content is publicly visible.</summary>
    public bool IsPublic { get; init; }
    [JsonPropertyName("isfriend")]
    /// <summary>Whether the content is visible to friends.</summary>
    public bool IsFriend { get; init; }
    [JsonPropertyName("isfamily")]
    /// <summary>Whether the content is visible to family.</summary>
    public bool IsFamily { get; init; }
}
