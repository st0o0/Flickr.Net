using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

/// <summary>
/// </summary>
public record Exif : FlickrEntityBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("tagspace")]
    public string TagSpace { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("tagspaceid")]
    public int TagSpaceId { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("tag")]
    public string Tag { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("label")]
    public string Label { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("raw")]
    public Raw Raw { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("clean")]
    public Clean Clean { get; set; }
}

/// <summary>
/// </summary>
public struct Raw
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    /// <summary>
    /// </summary>
    public static implicit operator string(Raw username) => username.Content;

    /// <summary>
    /// </summary>
    public static implicit operator Raw(string username) => new() { Content = username };
}

/// <summary>
/// </summary>
public struct Clean
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    /// <summary>
    /// </summary>
    public static implicit operator string(Clean username) => username.Content;

    /// <summary>
    /// </summary>
    public static implicit operator Clean(string username) => new() { Content = username };
}
