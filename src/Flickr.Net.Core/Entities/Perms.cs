using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Perms : FlickrEntityBase<Id>
{
    [JsonProperty("ispublic")]
    public bool IsPublic { get; set; }

    [JsonProperty("isfriend")]
    public bool IsFriend { get; set; }

    [JsonProperty("isfamily")]
    public bool IsFamily { get; set; }

    [JsonProperty("permcomment")]
    public PermissionComment PermComment { get; set; }

    [JsonProperty("permaddmeta")]
    public PermissionAddMeta PermAddMeta { get; set; }

    [JsonProperty("permprint")]
    public int PermPrint { get; set; }
}
