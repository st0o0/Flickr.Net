using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Enums;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

[FlickrJsonPropertyName("group")]
/// <summary>Detailed information about a Flickr group.</summary>
public record GroupInfo : FlickrEntityBase<Id>, IBuddyIcon
{
    [JsonPropertyName("iconserver")]
    /// <summary>The icon server for buddy icon URL construction.</summary>
    public string? IconServer { get; init; }
    [JsonPropertyName("iconfarm")]
    /// <summary>The icon farm for buddy icon URL construction.</summary>
    public int IconFarm { get; init; }
    [JsonPropertyName("lang")]
    /// <summary>The group's primary language.</summary>
    public string? Lang { get; init; }
    [JsonPropertyName("ispoolmoderated")]
    /// <summary>Whether the group pool is moderated.</summary>
    public bool IsPoolModerated { get; init; }
    [JsonPropertyName("name")]
    /// <summary>The display name.</summary>
    public string? Name { get; init; }
    [JsonPropertyName("description")]
    /// <summary>The description.</summary>
    public string? Description { get; init; }
    [JsonPropertyName("members")]
    /// <summary>The number of members.</summary>
    public int Members { get; init; }
    [JsonPropertyName("privacy")]
    /// <summary>The privacy level.</summary>
    public PoolPrivacy Privacy { get; init; }
    /// <summary>The number of photos in the group pool.</summary>
    [JsonPropertyName("pool_count")]
    public int? PoolCount { get; init; }

    /// <summary>The number of discussion topics in the group.</summary>
    [JsonPropertyName("topic_count")]
    public int? TopicCount { get; init; }

    [JsonPropertyName("throttle")]
    public Throttle? Throttle { get; init; }
    [JsonPropertyName("restrictions")]
    public Restrictions? Restrictions { get; init; }
}
