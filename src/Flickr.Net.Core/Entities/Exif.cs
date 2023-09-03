using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Exif : FlickrEntityBase
{
    [JsonPropertyName("tagspace")]
    public string TagSpace { get; set; }

    [JsonPropertyName("tagspaceid")]
    public int TagSpaceId { get; set; }

    [JsonPropertyName("tag")]
    public string Tag { get; set; }

    [JsonPropertyName("label")]
    public string Label { get; set; }

    [JsonPropertyName("raw")]
    public Raw Raw { get; set; }

    [JsonPropertyName("clean")]
    public Clean Clean { get; set; }
}

public struct Raw
{
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    public static implicit operator string(Raw username) => username.Content;

    public static implicit operator Raw(string username) => new() { Content = username };
}

public struct Clean
{
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    public static implicit operator string(Clean username) => username.Content;

    public static implicit operator Clean(string username) => new() { Content = username };
}
