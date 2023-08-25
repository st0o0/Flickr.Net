using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("person")]
public record PeoplePerson : FlickrEntityBase<NsId>
{
    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("iconserver")]
    public string Iconserver { get; set; }

    [JsonPropertyName("iconfarm")]
    public string Iconfarm { get; set; }

    [JsonPropertyName("realname")]
    public string Realname { get; set; }

    [JsonPropertyName("added_by")]
    public string AddedBy { get; set; }

    [JsonPropertyName("x")]
    public string X { get; set; }

    [JsonPropertyName("y")]
    public string Y { get; set; }

    [JsonPropertyName("w")]
    public string W { get; set; }

    [JsonPropertyName("h")]
    public string H { get; set; }
}
