using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Group : GroupBase, IBuddyIcon
{
    [JsonProperty("admin")]
    public bool Admin { get; set; }

    [JsonProperty("photos")]
    public int Photos { get; set; }

    [JsonProperty("privacy")]
    public PoolPrivacy Privacy { get; set; }

    [JsonProperty("iconserver")]
    public string IconServer { get; set; }

    [JsonProperty("iconfarm")]
    public int IconFarm { get; set; }

    [JsonProperty("members")]
    public int Members { get; set; }

    [JsonProperty("pool_count")]
    public int PoolCount { get; set; }

    [JsonProperty("topic_count")]
    public int TopicCount { get; set; }

    [JsonProperty("invitation_only")]
    public bool InvitationOnly { get; set; }
}