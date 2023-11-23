using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

    /// <summary>
    /// </summary>
[FlickrJsonPropertyName("pool")]
public record Pool : FlickrEntityBase<Id>
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("url")]
    public string Url { get; set; }

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
}
