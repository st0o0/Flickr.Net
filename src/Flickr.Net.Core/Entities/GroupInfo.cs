using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("group")]
public record GroupInfo : FlickrEntityBase<Id>, IBuddyIcon
{
    [JsonPropertyName("iconserver")]
    public string IconServer { get; set; }

    [JsonPropertyName("iconfarm")]
    public int IconFarm { get; set; }

    [JsonPropertyName("lang")]
    public string Lang { get; set; }

    [JsonPropertyName("ispoolmoderated")]
    public bool IsPoolModerated { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("members")]
    public int Members { get; set; }

    [JsonPropertyName("privacy")]
    public PoolPrivacy Privacy { get; set; }

    [JsonPropertyName("throttle")]
    public Throttle Throttle { get; set; }

    [JsonPropertyName("restrictions")]
    public Restrictions Restrictions { get; set; }
}