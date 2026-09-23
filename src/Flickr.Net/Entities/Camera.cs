using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;
/// <summary>Represents a camera model within a brand.</summary>
public record Camera : FlickrEntityBase<Id>
{    [JsonPropertyName("name")]
    /// <summary>The display name.</summary>
    public string? Name { get; init; }
    [JsonPropertyName("details")]
    /// <summary>The technical specifications.</summary>
    public Details? Details { get; init; }
    [JsonPropertyName("images")]
    /// <summary>The product images for this camera.</summary>
    public Image? Image { get; init; }
}
