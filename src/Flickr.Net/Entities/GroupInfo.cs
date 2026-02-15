using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Enums;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("group")]
public record GroupInfo : FlickrEntityBase<Id>, IBuddyIcon
{
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
    [JsonPropertyName("lang")]
    public string Lang { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("ispoolmoderated")]
    public bool IsPoolModerated { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("members")]
    public int Members { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("privacy")]
    public PoolPrivacy Privacy { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("throttle")]
    public Throttle Throttle { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("restrictions")]
    public Restrictions Restrictions { get; set; }
}