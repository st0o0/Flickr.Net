using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Brand : FlickrEntityBase<Id>
{
    [JsonPropertyName("_content")]
    public string Content { get; set; }
}