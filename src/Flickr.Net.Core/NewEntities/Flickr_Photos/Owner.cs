using Flickr.Net.Core.Bases;
using Newtonsoft.Json;

namespace Flickr.Net.Core;

public record Owner : FlickrEntityBase<NsId>
{
    [JsonProperty("username")]
    public string Username { get; set; }

    [JsonProperty("realname")]
    public string Realname { get; set; }

    [JsonProperty("location")]
    public string Location { get; set; }

    [JsonProperty("iconserver")]
    public string IconServer { get; set; }

    [JsonProperty("iconfarm")]
    public int IconFarm { get; set; }

    [JsonProperty("path_alias")]
    public string PathAlias { get; set; }

    [JsonProperty("gift")]
    public Gift Gift { get; set; }
}
