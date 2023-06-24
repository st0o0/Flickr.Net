using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;
using Newtonsoft.Json;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("person")]
public record PhotoPerson : FlickrEntityBase<NsId>
{
    [JsonProperty("username")]
    public string Username { get; set; }

    [JsonProperty("favedate")]
    public DateTime FaveDate { get; set; }

    [JsonProperty("ispro")]
    public bool IsPro { get; set; }

    [JsonProperty("is_deleted")]
    public bool IsDeleted { get; set; }

    [JsonProperty("iconserver")]
    public string IconServer { get; set; }

    [JsonProperty("iconfarm")]
    public int Iconfarm { get; set; }

    [JsonProperty("path_alias")]
    public string PathAlias { get; set; }

    [JsonProperty("has_stats")]
    public bool HasStats { get; set; }

    [JsonProperty("pro_badge")]
    public string ProBadge { get; set; }

    [JsonProperty("expire")]
    public string Expire { get; set; }

    [JsonProperty("gender")]
    public string Gender { get; set; }

    [JsonProperty("ignored")]
    public bool Ignored { get; set; }

    [JsonProperty("contact")]
    public bool Contact { get; set; }

    [JsonProperty("friend")]
    public bool Friend { get; set; }

    [JsonProperty("family")]
    public bool Family { get; set; }

    [JsonProperty("revcontact")]
    public bool Revcontact { get; set; }

    [JsonProperty("revfriend")]
    public bool Revfriend { get; set; }

    [JsonProperty("revfamily")]
    public bool Revfamily { get; set; }

    [JsonProperty("realname")]
    public string Realname { get; set; }

    [JsonProperty("location")]
    public string Location { get; set; }

    [JsonProperty("timezone")]
    public TimeZone Timezone { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }

    [JsonProperty("photosurl")]
    public string PhotosUrl { get; set; }

    [JsonProperty("profileurl")]
    public string ProfileUrl { get; set; }

    [JsonProperty("mobileurl")]
    public string MobileUrl { get; set; }

    [JsonProperty("photos")]
    public PhotoDateInfos PhotoDateInfos { get; set; }

    [JsonProperty("has_adfree")]
    public bool HasAdfree { get; set; }

    [JsonProperty("has_free_standard_shipping")]
    public bool HasFreeStandardShipping { get; set; }

    [JsonProperty("has_free_educational_resources")]
    public bool HasFreeEducationalResources { get; set; }

    [JsonProperty("mbox_sha1sum")]
    public string MboxSha1sum { get; set; }
}

public struct TimeZone
{
    [JsonProperty("label")]
    public string Label { get; set; }

    [JsonProperty("offset")]
    public string Offset { get; set; }

    [JsonProperty("timezone_id")]
    public string TimezoneId { get; set; }

    [JsonProperty("timezone")]
    public int Timezone { get; set; }
}

public struct PhotoDateInfos
{
    [JsonProperty("firstdatetaken")]
    public DateTime FirstDateTaken { get; set; }

    [JsonProperty("firstdate")]
    public DateTime FirstDate { get; set; }

    [JsonProperty("count")]
    public int Count { get; set; }
}