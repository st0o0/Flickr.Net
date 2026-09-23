using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Enums;

namespace Flickr.Net;
/// <summary>Represents the permission settings for a photo.</summary>
public record Permissions : FlickrEntityBase
{    [JsonPropertyName("permcomment")]
    /// <summary>The permission level for commenting.</summary>
    public PermissionComment PermComment { get; init; }
    [JsonPropertyName("permaddmeta")]
    /// <summary>The permission level for adding metadata.</summary>
    public PermissionAddMeta PermAddMeta { get; init; }
}
