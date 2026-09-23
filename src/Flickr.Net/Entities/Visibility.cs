using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;
/// <summary>Represents the visibility settings of a photo.</summary>
public record Visibility : FlickrEntityBase
{
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
