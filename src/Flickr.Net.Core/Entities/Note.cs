using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Note : FlickrEntityBase<Id>
{
    [JsonPropertyName("author")]
    public string Author { get; set; }

    [JsonPropertyName("authorname")]
    public string Authorname { get; set; }

    [JsonPropertyName("x")]
    public int X { get; set; }

    [JsonPropertyName("y")]
    public int Y { get; set; }

    [JsonPropertyName("w")]
    public int W { get; set; }

    [JsonPropertyName("h")]
    public int H { get; set; }

    [JsonPropertyName("_content")]
    public string Content { get; set; }
}