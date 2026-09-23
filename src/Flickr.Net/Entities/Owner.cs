using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;
/// <summary>Represents the owner of a photo with profile details.</summary>
public record Owner : FlickrEntityBase<NsId>
{
    [JsonPropertyName("username")]
    /// <summary>The username.</summary>
    public string? Username { get; init; }
    [JsonPropertyName("realname")]
    /// <summary>The real name.</summary>
    public string? Realname { get; init; }
    [JsonPropertyName("location")]
    /// <summary>The user's location.</summary>
    public string? Location { get; init; }
    [JsonPropertyName("iconserver")]
    /// <summary>The icon server for buddy icon URL construction.</summary>
    public string? IconServer { get; init; }
    [JsonPropertyName("iconfarm")]
    /// <summary>The icon farm for buddy icon URL construction.</summary>
    public int IconFarm { get; init; }
    [JsonPropertyName("path_alias")]
    /// <summary>The URL-friendly path alias.</summary>
    public string? PathAlias { get; init; }
    [JsonPropertyName("gift")]
    /// <summary>The gift eligibility information.</summary>
    public Gift? Gift { get; init; }
}
