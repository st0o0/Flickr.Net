using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;
[FlickrJsonPropertyName("person")]
/// <summary>Represents a person tagged in a photo (people in photos).</summary>
public record PeoplePerson : FlickrEntityBase<NsId>
{    [JsonPropertyName("username")]
    /// <summary>The username.</summary>
    public string? Username { get; init; }
    [JsonPropertyName("iconserver")]
    /// <summary>The icon server for buddy icon URL construction.</summary>
    public string? IconServer { get; init; }
    [JsonPropertyName("iconfarm")]
    /// <summary>The icon farm for buddy icon URL construction.</summary>
    public string? IconFarm { get; init; }
    [JsonPropertyName("realname")]
    /// <summary>The real name.</summary>
    public string? Realname { get; init; }
    [JsonPropertyName("added_by")]
    /// <summary>The NSID of the user who added this person tag.</summary>
    public string? AddedBy { get; init; }
    [JsonPropertyName("x")]
    /// <summary>The X coordinate.</summary>
    public string? X { get; init; }
    [JsonPropertyName("y")]
    /// <summary>The Y coordinate.</summary>
    public string? Y { get; init; }
    [JsonPropertyName("w")]
    /// <summary>The width.</summary>
    public string? W { get; init; }
    [JsonPropertyName("h")]
    /// <summary>The height.</summary>
    public string? H { get; init; }
}
