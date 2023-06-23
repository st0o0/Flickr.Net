using Flickr.Net.Core.Bases;
using Newtonsoft.Json;

namespace Flickr.Net.Core;

public record Note : FlickrEntityBase<Id>
{
    [JsonProperty("author")]
    public string Author { get; set; }

    [JsonProperty("authorname")]
    public string Authorname { get; set; }

    [JsonProperty("x")]
    public int X { get; set; }

    [JsonProperty("y")]
    public int Y { get; set; }

    [JsonProperty("w")]
    public int W { get; set; }

    [JsonProperty("h")]
    public int H { get; set; }

    [JsonProperty("_content")]
    public string Content { get; set; }
}