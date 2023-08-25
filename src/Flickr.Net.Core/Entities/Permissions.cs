using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Permissions : FlickrEntityBase
{
    [JsonPropertyName("permcomment")]
    public PermissionComment PermComment { get; set; }

    [JsonPropertyName("permaddmeta")]
    public PermissionAddMeta PermAddMeta { get; set; }
}
