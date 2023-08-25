using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Contact : FlickrEntityBase<NsId>, IBuddyIcon
{
    [JsonPropertyName("username")]
    public string UserName { get; set; }

    [JsonPropertyName("iconserver")]
    public string IconServer { get; set; }

    [JsonPropertyName("iconfarm")]
    public int IconFarm { get; set; }

    [JsonPropertyName("realname")]
    public string RealName { get; set; }

    [JsonPropertyName("location")]
    public string Location { get; set; }

    [JsonPropertyName("path_alias")]
    public string PathAlias { get; set; }

    [JsonPropertyName("photos_uploaded")]
    public int UploadedPhotos { get; set; }

    [JsonPropertyName("friend")]
    public bool Friend { get; set; }

    [JsonPropertyName("family")]
    public bool Family { get; set; }

    [JsonPropertyName("ignored")]
    public bool Ignored { get; set; }

    [JsonPropertyName("ispro")]
    public bool IsPro { get; set; }
}