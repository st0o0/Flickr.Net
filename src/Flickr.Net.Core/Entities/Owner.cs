using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Owner : FlickrEntityBase<NsId>
{
    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("realname")]
    public string Realname { get; set; }

    [JsonPropertyName("location")]
    public string Location { get; set; }

    [JsonPropertyName("iconserver")]
    public string IconServer { get; set; }

    [JsonPropertyName("iconfarm")]
    public int IconFarm { get; set; }

    [JsonPropertyName("path_alias")]
    public string PathAlias { get; set; }

    [JsonPropertyName("gift")]
    public Gift Gift { get; set; }
}
