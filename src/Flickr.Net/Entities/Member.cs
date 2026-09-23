using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Enums;

namespace Flickr.Net;
/// <summary>Represents a member of a Flickr group.</summary>
public record Member : FlickrEntityBase<NsId>, IBuddyIcon
{
    [JsonPropertyName("username")]
    /// <summary>The username.</summary>
    public string? UserName { get; init; }
    [JsonPropertyName("iconserver")]
    /// <summary>The icon server for buddy icon URL construction.</summary>
    public string? IconServer { get; init; }
    [JsonPropertyName("iconfarm")]
    /// <summary>The icon farm for buddy icon URL construction.</summary>
    public string? IconFarm { get; init; }
    [JsonPropertyName("membertype")]
    /// <summary>The type.</summary>
    public MemberType Type { get; init; }
}
