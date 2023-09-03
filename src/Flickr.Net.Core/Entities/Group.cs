using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Group : GroupBase, IBuddyIcon
{
    [JsonPropertyName("admin")]
    public bool Admin { get; set; }

    [JsonPropertyName("photos")]
    public int Photos { get; set; }

    [JsonPropertyName("privacy")]
    public PoolPrivacy Privacy { get; set; }

    [JsonPropertyName("iconserver")]
    public string IconServer { get; set; }

    [JsonPropertyName("iconfarm")]
    public int IconFarm { get; set; }

    [JsonPropertyName("members")]
    public int Members { get; set; }

    [JsonPropertyName("pool_count")]
    public int PoolCount { get; set; }

    [JsonPropertyName("topic_count")]
    public int TopicCount { get; set; }

    [JsonPropertyName("invitation_only")]
    public bool InvitationOnly { get; set; }
}