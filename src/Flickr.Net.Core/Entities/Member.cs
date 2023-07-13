using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Member : FlickrEntityBase<NsId>, IBuddyIcon
{
    [JsonProperty("username")]
    public string UserName { get; set; }

    [JsonProperty("iconserver")]
    public string IconServer { get; set; }

    [JsonProperty("iconfarm")]
    public string IconFarm { get; set; }

    [JsonProperty("membertype")]
    public MemberType Type { get; set; }
}