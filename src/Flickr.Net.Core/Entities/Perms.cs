using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Perms : FlickrEntityBase<Id>
{
    [JsonPropertyName("ispublic")]
    public bool IsPublic { get; set; }

    [JsonPropertyName("isfriend")]
    public bool IsFriend { get; set; }

    [JsonPropertyName("isfamily")]
    public bool IsFamily { get; set; }

    [JsonPropertyName("permcomment")]
    public PermissionComment PermComment { get; set; }

    [JsonPropertyName("permaddmeta")]
    public PermissionAddMeta PermAddMeta { get; set; }

    [JsonPropertyName("permprint")]
    public int PermPrint { get; set; }
}
