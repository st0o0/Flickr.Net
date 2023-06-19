using Flickr.Net.Core.Internals.JsonConverters;
using Newtonsoft.Json;

namespace Flickr.Net.Core.NewEntities;

public class Group
{
    [JsonProperty("nsid")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("eighteenplus")]
    [JsonConverter(typeof(BoolConverter))]
    public bool EighteenPlus { get; set; }

    [JsonProperty("admin")]
    [JsonConverter(typeof(BoolConverter))]
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
    [JsonConverter(typeof(BoolConverter))]
    public bool InvitationOnly { get; set; }

    /// <summary>
    /// The url for the group's icon.
    /// </summary>
    [JsonIgnore]
    public string GroupIconUrl => UtilityMethods.BuddyIcon(IconServer, IconFarm, Id);
}
