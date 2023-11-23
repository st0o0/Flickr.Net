using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;

/// <summary>
/// </summary>
public record Perms : FlickrEntityBase<Id>
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("ispublic")]
    public bool IsPublic { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("isfriend")]
    public bool IsFriend { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("isfamily")]
    public bool IsFamily { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("permcomment")]
    public PermissionComment PermComment { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("permaddmeta")]
    public PermissionAddMeta PermAddMeta { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("permprint")]
    public int PermPrint { get; set; }
}
