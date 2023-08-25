using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Member : FlickrEntityBase<NsId>, IBuddyIcon
{
    [JsonPropertyName("username")]
    public string UserName { get; set; }

    [JsonPropertyName("iconserver")]
    public string IconServer { get; set; }

    [JsonPropertyName("iconfarm")]
    public string IconFarm { get; set; }

    [JsonPropertyName("membertype")]
    public MemberType Type { get; set; }
}