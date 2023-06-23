using Flickr.Net.Core.Bases;
using Newtonsoft.Json;

namespace Flickr.Net.Core;

public record Permissions : FlickrEntityBase
{
    [JsonProperty("permcomment")]
    public PermissionComment PermComment { get; set; }

    [JsonProperty("permaddmeta")]
    public PermissionAddMeta PermAddMeta { get; set; }
}
