using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Enums;

namespace Flickr.Net;
/// <summary>Represents a Flickr group.</summary>
public record Group : GroupBase, IBuddyIcon
{    [JsonPropertyName("admin")]
    /// <summary>Whether the current user is an admin of this group.</summary>
    public bool Admin { get; init; }
    [JsonPropertyName("photos")]
    /// <summary>The number of photos.</summary>
    public int Photos { get; init; }
    [JsonPropertyName("privacy")]
    /// <summary>The privacy level.</summary>
    public PoolPrivacy Privacy { get; init; }
    [JsonPropertyName("iconserver")]
    /// <summary>The icon server for buddy icon URL construction.</summary>
    public string? IconServer { get; init; }
    [JsonPropertyName("iconfarm")]
    /// <summary>The icon farm for buddy icon URL construction.</summary>
    public int IconFarm { get; init; }
    [JsonPropertyName("members")]
    /// <summary>The number of members.</summary>
    public int Members { get; init; }
    [JsonPropertyName("pool_count")]
    /// <summary>The number of photos in the pool.</summary>
    public int PoolCount { get; init; }
    [JsonPropertyName("topic_count")]
    /// <summary>The number of discussion topics.</summary>
    public int TopicCount { get; init; }
    [JsonPropertyName("invitation_only")]
    /// <summary>Whether membership requires an invitation.</summary>
    public bool InvitationOnly { get; init; }
}
