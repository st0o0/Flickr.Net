using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("person")]
public record PhotoPerson : FlickrEntityBase<NsId>, IBuddyIcon
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("username")]
    public string Username { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("favedate")]
    public DateTime FaveDate { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("ispro")]
    public bool IsPro { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("is_deleted")]
    public bool IsDeleted { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("iconserver")]
    public string IconServer { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("iconfarm")]
    public int IconFarm { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("path_alias")]
    public string PathAlias { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("has_stats")]
    public bool HasStats { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("pro_badge")]
    public string ProBadge { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("expire")]
    public string Expire { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("gender")]
    public string Gender { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("ignored")]
    public bool Ignored { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("contact")]
    public bool Contact { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("friend")]
    public bool Friend { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("family")]
    public bool Family { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("revcontact")]
    public bool Revcontact { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("revfriend")]
    public bool Revfriend { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("revfamily")]
    public bool Revfamily { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("realname")]
    public string Realname { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("location")]
    public string Location { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("timezone")]
    public TimeZone Timezone { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("photosurl")]
    public string PhotosUrl { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("profileurl")]
    public string ProfileUrl { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("mobileurl")]
    public string MobileUrl { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("photos")]
    public PhotoDateInfos PhotoDateInfos { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("has_adfree")]
    public bool HasAdfree { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("has_free_standard_shipping")]
    public bool HasFreeStandardShipping { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("has_free_educational_resources")]
    public bool HasFreeEducationalResources { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("mbox_sha1sum")]
    public string MboxSha1sum { get; set; }
}

/// <summary>
/// </summary>
public struct TimeZone
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("label")]
    public string Label { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("offset")]
    public string Offset { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("timezone_id")]
    public string TimezoneId { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("timezone")]
    public int Timezone { get; set; }
}

/// <summary>
/// </summary>
public struct PhotoDateInfos
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("firstdatetaken")]
    public DateTime FirstDateTaken { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("firstdate")]
    public DateTime FirstDate { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("count")]
    public int Count { get; set; }
}