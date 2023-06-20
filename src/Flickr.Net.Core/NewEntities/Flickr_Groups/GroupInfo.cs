using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;
using Newtonsoft.Json;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("group")]
public record GroupInfo : FlickrEntityBase<Id>
{
    [JsonProperty("iconserver")]
    public string IconServer { get; set; }

    [JsonProperty("iconfarm")]
    public string IconFarm { get; set; }

    [JsonProperty("lang")]
    public string Lang { get; set; }

    [JsonProperty("ispoolmoderated")]
    public bool IsPoolModerated { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("members")]
    public int Members { get; set; }

    [JsonProperty("privacy")]
    public PoolPrivacy Privacy { get; set; }

    [JsonProperty("throttle")]
    public Throttle Throttle { get; set; }

    [JsonProperty("restrictions")]
    public Restrictions Restrictions { get; set; }
}