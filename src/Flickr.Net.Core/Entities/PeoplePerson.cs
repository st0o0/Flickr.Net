using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("person")]
public record PeoplePerson : FlickrEntityBase<NsId>
{
    [JsonProperty("username")]
    public string Username { get; set; }

    [JsonProperty("iconserver")]
    public string Iconserver { get; set; }

    [JsonProperty("iconfarm")]
    public string Iconfarm { get; set; }

    [JsonProperty("realname")]
    public string Realname { get; set; }

    [JsonProperty("added_by")]
    public string AddedBy { get; set; }

    [JsonProperty("x")]
    public string X { get; set; }

    [JsonProperty("y")]
    public string Y { get; set; }

    [JsonProperty("w")]
    public string W { get; set; }

    [JsonProperty("h")]
    public string H { get; set; }
}
