using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

/// <summary>
/// </summary>
public record Permissions : FlickrEntityBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("permcomment")]
    public PermissionComment PermComment { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("permaddmeta")]
    public PermissionAddMeta PermAddMeta { get; set; }
}
