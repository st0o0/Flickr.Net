using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Enums;

namespace Flickr.Net;

/// <summary>
/// </summary>
public record Group : GroupBase, IBuddyIcon
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("admin")]
    public bool Admin { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("photos")]
    public int Photos { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("privacy")]
    public PoolPrivacy Privacy { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("iconserver")]
    public string IconServer { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("iconfarm")]
    public int IconFarm { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("members")]
    public int Members { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("pool_count")]
    public int PoolCount { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("topic_count")]
    public int TopicCount { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("invitation_only")]
    public bool InvitationOnly { get; set; }
}