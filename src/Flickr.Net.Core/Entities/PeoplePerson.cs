using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("person")]
public record PeoplePerson : FlickrEntityBase<NsId>
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("username")]
    public string Username { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("iconserver")]
    public string Iconserver { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("iconfarm")]
    public string Iconfarm { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("realname")]
    public string Realname { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("added_by")]
    public string AddedBy { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("x")]
    public string X { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("y")]
    public string Y { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("w")]
    public string W { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("h")]
    public string H { get; set; }
}
