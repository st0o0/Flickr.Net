using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Panda : FlickrEntityBase
{
    [JsonPropertyName("_content")]
    public string Content { get; set; }
}