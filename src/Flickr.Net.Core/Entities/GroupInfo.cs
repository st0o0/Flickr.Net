using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("group")]
public record GroupInfo : FlickrEntityBase<Id>, IBuddyIcon
{
    [JsonProperty("iconserver")]
    public string IconServer { get; set; }

    [JsonProperty("iconfarm")]
    public int IconFarm { get; set; }

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