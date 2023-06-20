using Flickr.Net.Core.Bases;
using Newtonsoft.Json;

namespace Flickr.Net.Core;

public record Group : GroupBase
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
    public string IconFarm { get; set; }

    [JsonProperty("members")]
    public int Members { get; set; }

    [JsonProperty("pool_count")]
    public int PoolCount { get; set; }

    [JsonProperty("topic_count")]
    public int TopicCount { get; set; }

    [JsonProperty("invitation_only")]
    public bool InvitationOnly { get; set; }

    /// <summary>
    /// The url for the group's icon.
    /// </summary>
    [JsonIgnore]
    public string GroupIconUrl => UtilityMethods.BuddyIcon(IconServer, IconFarm, Id);
}