using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Exif : FlickrEntityBase
{
    [JsonProperty("tagspace")]
    public string TagSpace { get; set; }

    [JsonProperty("tagspaceid")]
    public int TagSpaceId { get; set; }

    [JsonProperty("tag")]
    public string Tag { get; set; }

    [JsonProperty("label")]
    public string Label { get; set; }

    [JsonProperty("raw")]
    public Raw Raw { get; set; }

    [JsonProperty("clean")]
    public Clean Clean { get; set; }
}

public struct Raw
{
    [JsonProperty("_content")]
    public string Content { get; set; }

    public static implicit operator string(Raw username) => username.Content;

    public static implicit operator Raw(string username) => new() { Content = username };
}

public struct Clean
{
    [JsonProperty("_content")]
    public string Content { get; set; }

    public static implicit operator string(Clean username) => username.Content;

    public static implicit operator Clean(string username) => new() { Content = username };
}
