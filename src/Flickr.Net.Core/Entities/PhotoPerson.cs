using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("person")]
public record PhotoPerson : FlickrEntityBase<NsId>, IBuddyIcon
{
    [JsonPropertyName("username")]
    public string Username { get; set; }

    [JsonPropertyName("favedate")]
    public DateTime FaveDate { get; set; }

    [JsonPropertyName("ispro")]
    public bool IsPro { get; set; }

    [JsonPropertyName("is_deleted")]
    public bool IsDeleted { get; set; }

    [JsonPropertyName("iconserver")]
    public string IconServer { get; set; }

    [JsonPropertyName("iconfarm")]
    public int IconFarm { get; set; }

    [JsonPropertyName("path_alias")]
    public string PathAlias { get; set; }

    [JsonPropertyName("has_stats")]
    public bool HasStats { get; set; }

    [JsonPropertyName("pro_badge")]
    public string ProBadge { get; set; }

    [JsonPropertyName("expire")]
    public string Expire { get; set; }

    [JsonPropertyName("gender")]
    public string Gender { get; set; }

    [JsonPropertyName("ignored")]
    public bool Ignored { get; set; }

    [JsonPropertyName("contact")]
    public bool Contact { get; set; }

    [JsonPropertyName("friend")]
    public bool Friend { get; set; }

    [JsonPropertyName("family")]
    public bool Family { get; set; }

    [JsonPropertyName("revcontact")]
    public bool Revcontact { get; set; }

    [JsonPropertyName("revfriend")]
    public bool Revfriend { get; set; }

    [JsonPropertyName("revfamily")]
    public bool Revfamily { get; set; }

    [JsonPropertyName("realname")]
    public string Realname { get; set; }

    [JsonPropertyName("location")]
    public string Location { get; set; }

    [JsonPropertyName("timezone")]
    public TimeZone Timezone { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("photosurl")]
    public string PhotosUrl { get; set; }

    [JsonPropertyName("profileurl")]
    public string ProfileUrl { get; set; }

    [JsonPropertyName("mobileurl")]
    public string MobileUrl { get; set; }

    [JsonPropertyName("photos")]
    public PhotoDateInfos PhotoDateInfos { get; set; }

    [JsonPropertyName("has_adfree")]
    public bool HasAdfree { get; set; }

    [JsonPropertyName("has_free_standard_shipping")]
    public bool HasFreeStandardShipping { get; set; }

    [JsonPropertyName("has_free_educational_resources")]
    public bool HasFreeEducationalResources { get; set; }

    [JsonPropertyName("mbox_sha1sum")]
    public string MboxSha1sum { get; set; }
}

public struct TimeZone
{
    [JsonPropertyName("label")]
    public string Label { get; set; }

    [JsonPropertyName("offset")]
    public string Offset { get; set; }

    [JsonPropertyName("timezone_id")]
    public string TimezoneId { get; set; }

    [JsonPropertyName("timezone")]
    public int Timezone { get; set; }
}

public struct PhotoDateInfos
{
    [JsonPropertyName("firstdatetaken")]
    public DateTime FirstDateTaken { get; set; }

    [JsonPropertyName("firstdate")]
    public DateTime FirstDate { get; set; }

    [JsonPropertyName("count")]
    public int Count { get; set; }
}