using Flickr.Net.Core.Bases;
using Newtonsoft.Json;

namespace Flickr.Net.Core;

public record Contact : FlickrEntityBase<NsId>
{
    [JsonProperty("username")]
    public string UserName { get; set; }

    [JsonProperty("iconserver")]
    public string IconServer { get; set; }

    [JsonProperty("realname")]
    public string RealName { get; set; }

    [JsonProperty("location")]
    public string Location { get; set; }

    [JsonProperty("path_alias")]
    public string PathAlias { get; set; }

    [JsonProperty("photos_uploaded")]
    public int UploadedPhotos { get; set; }

    [JsonProperty("friend")]
    public bool Friend { get; set; }

    [JsonProperty("family")]
    public bool Family { get; set; }

    [JsonProperty("ignored")]
    public bool Ignored { get; set; }

    [JsonProperty("ispro")]
    public bool IsPro { get; set; }
}