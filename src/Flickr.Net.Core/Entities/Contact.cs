using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

/// <summary>
/// </summary>
public record Contact : FlickrEntityBase<NsId>, IBuddyIcon
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("username")]
    public string UserName { get; set; }

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
    [JsonPropertyName("realname")]
    public string RealName { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("location")]
    public string Location { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("path_alias")]
    public string PathAlias { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("photos_uploaded")]
    public int UploadedPhotos { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("friend")]
    public bool Friend { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("family")]
    public bool Family { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("ignored")]
    public bool Ignored { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("ispro")]
    public bool IsPro { get; set; }
}