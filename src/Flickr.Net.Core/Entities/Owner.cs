using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

/// <summary>
/// </summary>
public record Owner : FlickrEntityBase<NsId>
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("username")]
    public string Username { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("realname")]
    public string Realname { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("location")]
    public string Location { get; set; }

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
    [JsonPropertyName("path_alias")]
    public string PathAlias { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("gift")]
    public Gift Gift { get; set; }
}
