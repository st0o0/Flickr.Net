using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

[FlickrJsonPropertyName("pool")]
/// <summary>Represents a group pool context for a photo.</summary>
public record Pool : FlickrEntityBase<Id>
{
    [JsonPropertyName("title")]
    /// <summary>The title.</summary>
    public string? Title { get; init; }
    [JsonPropertyName("url")]
    /// <summary>The URL.</summary>
    public string? Url { get; init; }
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
}
