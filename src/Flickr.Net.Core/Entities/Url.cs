using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Url : FlickrEntityBase
{
    [JsonPropertyName("type")]
    public UrlType Type { get; set; }

    [JsonPropertyName("_content")]
    public string Content { get; set; }
}