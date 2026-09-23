using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;
/// <summary>Represents a single EXIF/IPTC/XMP tag from a photo.</summary>
public record Exif : FlickrEntityBase
{    [JsonPropertyName("tagspace")]
    /// <summary>The EXIF tag space (e.g. ExifIFD, IFD0).</summary>
    public string? TagSpace { get; init; }
    [JsonPropertyName("tagspaceid")]
    /// <summary>The numeric identifier of the tag space.</summary>
    public int TagSpaceId { get; init; }
    [JsonPropertyName("tag")]
    /// <summary>The EXIF tag name.</summary>
    public string? Tag { get; init; }
    [JsonPropertyName("label")]
    /// <summary>The human-readable label for the EXIF tag.</summary>
    public string? Label { get; init; }
    [JsonPropertyName("raw")]
    /// <summary>The raw EXIF value.</summary>
    public Raw Raw { get; init; }
    [JsonPropertyName("clean")]
    /// <summary>The cleaned/formatted EXIF value.</summary>
    public Clean Clean { get; init; }
}
/// <summary>Wraps a raw EXIF tag value.</summary>
public struct Raw
{    [JsonPropertyName("_content")]
    /// <summary>The text content.</summary>
    public string? Content { get; init; }
    /// <summary>Converts to the underlying string value.</summary>
    public static implicit operator string(Raw username) => username.Content;
    /// <summary>Converts from a string value.</summary>
    public static implicit operator Raw(string username) => new() { Content = username };
}
/// <summary>Wraps a cleaned/formatted EXIF tag value.</summary>
public struct Clean
{    [JsonPropertyName("_content")]
    /// <summary>The text content.</summary>
    public string? Content { get; init; }
    /// <summary>Converts to the underlying string value.</summary>
    public static implicit operator string(Clean username) => username.Content;
    /// <summary>Converts from a string value.</summary>
    public static implicit operator Clean(string username) => new() { Content = username };
}
