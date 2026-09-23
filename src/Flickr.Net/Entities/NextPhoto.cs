using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Enums;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;
[FlickrJsonPropertyName("nextphoto")]
/// <summary>Represents the next photo in a context navigation sequence.</summary>
public record NextPhoto : FlickrEntityBase<Id>
{    [JsonPropertyName("owner")]
    /// <summary>The NSID of the owner.</summary>
    public string? Owner { get; init; }
    [JsonPropertyName("secret")]
    /// <summary>The photo secret used in URL construction.</summary>
    public string? Secret { get; init; }
    [JsonPropertyName("server")]
    /// <summary>The server identifier used in URL construction.</summary>
    public string? Server { get; init; }
    [JsonPropertyName("farm")]
    /// <summary>The farm identifier used in URL construction.</summary>
    public int Farm { get; init; }
    [JsonPropertyName("title")]
    /// <summary>The title.</summary>
    public string? Title { get; init; }
    [JsonPropertyName("url")]
    /// <summary>The URL.</summary>
    public string? Url { get; init; }
    [JsonPropertyName("thumb")]
    /// <summary>The thumbnail URL.</summary>
    public string? Thumb { get; init; }
    [JsonPropertyName("license")]
    public LicenseType License { get; init; }
    [JsonPropertyName("media")]
    /// <summary>The media type (photo or video).</summary>
    public MediaType Media { get; init; }
    [JsonPropertyName("is_faved")]
    /// <summary>Whether the current user has favorited this photo.</summary>
    public bool IsFaved { get; init; }
}
