using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

/// <summary>
/// Represents a person associated with a Flickr photo (e.g. who favorited or tagged in it).
/// </summary>
[FlickrJsonPropertyName("person")]
public record PhotoPerson : FlickrEntityBase<NsId>, IBuddyIcon
{
    /// <summary>Gets or sets the person's username.</summary>
    [JsonPropertyName("username")]
    public string Username { get; set; }

    /// <summary>Gets or sets the date the person favorited the photo.</summary>
    [JsonPropertyName("favedate")]
    public DateTime FaveDate { get; set; }

    /// <summary>Gets or sets whether the person has a Pro account.</summary>
    [JsonPropertyName("ispro")]
    public bool IsPro { get; set; }

    /// <summary>Gets or sets whether the person's account has been deleted.</summary>
    [JsonPropertyName("is_deleted")]
    public bool IsDeleted { get; set; }

    /// <summary>Gets or sets the icon server for the person's buddy icon.</summary>
    [JsonPropertyName("iconserver")]
    public string IconServer { get; set; }

    /// <summary>Gets or sets the icon farm for the person's buddy icon.</summary>
    [JsonPropertyName("iconfarm")]
    public int IconFarm { get; set; }

    /// <summary>Gets or sets the person's custom URL path alias.</summary>
    [JsonPropertyName("path_alias")]
    public string PathAlias { get; set; }

    /// <summary>Gets or sets whether the person has access to stats.</summary>
    [JsonPropertyName("has_stats")]
    public bool HasStats { get; set; }

    /// <summary>Gets or sets the person's Pro badge type.</summary>
    [JsonPropertyName("pro_badge")]
    public string ProBadge { get; set; }

    /// <summary>Gets or sets the account expiration date.</summary>
    [JsonPropertyName("expire")]
    public string Expire { get; set; }

    /// <summary>Gets or sets the person's gender.</summary>
    [JsonPropertyName("gender")]
    public string Gender { get; set; }

    /// <summary>Gets or sets whether the person is ignored by the calling user.</summary>
    [JsonPropertyName("ignored")]
    public bool Ignored { get; set; }

    /// <summary>Gets or sets whether the person is a contact of the calling user.</summary>
    [JsonPropertyName("contact")]
    public bool Contact { get; set; }

    /// <summary>Gets or sets whether the person is a friend of the calling user.</summary>
    [JsonPropertyName("friend")]
    public bool Friend { get; set; }

    /// <summary>Gets or sets whether the person is family of the calling user.</summary>
    [JsonPropertyName("family")]
    public bool Family { get; set; }

    /// <summary>Gets or sets whether the person considers the calling user a contact.</summary>
    [JsonPropertyName("revcontact")]
    public bool Revcontact { get; set; }

    /// <summary>Gets or sets whether the person considers the calling user a friend.</summary>
    [JsonPropertyName("revfriend")]
    public bool Revfriend { get; set; }

    /// <summary>Gets or sets whether the person considers the calling user family.</summary>
    [JsonPropertyName("revfamily")]
    public bool Revfamily { get; set; }

    /// <summary>Gets or sets the person's real name.</summary>
    [JsonPropertyName("realname")]
    public string Realname { get; set; }

    /// <summary>Gets or sets the person's location.</summary>
    [JsonPropertyName("location")]
    public string Location { get; set; }

    /// <summary>Gets or sets the person's timezone information.</summary>
    [JsonPropertyName("timezone")]
    public TimeZone Timezone { get; set; }

    /// <summary>Gets or sets the person's profile description.</summary>
    [JsonPropertyName("description")]
    public string Description { get; set; }

    /// <summary>Gets or sets the URL to the person's photo stream.</summary>
    [JsonPropertyName("photosurl")]
    public string PhotosUrl { get; set; }

    /// <summary>Gets or sets the URL to the person's profile page.</summary>
    [JsonPropertyName("profileurl")]
    public string ProfileUrl { get; set; }

    /// <summary>Gets or sets the person's mobile URL.</summary>
    [JsonPropertyName("mobileurl")]
    public string MobileUrl { get; set; }

    /// <summary>Gets or sets aggregated photo date information.</summary>
    [JsonPropertyName("photos")]
    public PhotoDateInfos PhotoDateInfos { get; set; }

    /// <summary>Gets or sets whether the person has an ad-free experience.</summary>
    [JsonPropertyName("has_adfree")]
    public bool HasAdfree { get; set; }

    /// <summary>Gets or sets whether the person has free standard shipping.</summary>
    [JsonPropertyName("has_free_standard_shipping")]
    public bool HasFreeStandardShipping { get; set; }

    /// <summary>Gets or sets whether the person has free educational resources.</summary>
    [JsonPropertyName("has_free_educational_resources")]
    public bool HasFreeEducationalResources { get; set; }

    /// <summary>Gets or sets the SHA1 hash of the person's email address.</summary>
    [JsonPropertyName("mbox_sha1sum")]
    public string MboxSha1sum { get; set; }
}

/// <summary>
/// Represents timezone information for a Flickr user.
/// </summary>
public struct TimeZone
{
    /// <summary>Gets or sets the timezone display label.</summary>
    [JsonPropertyName("label")]
    public string Label { get; set; }

    /// <summary>Gets or sets the UTC offset string.</summary>
    [JsonPropertyName("offset")]
    public string Offset { get; set; }

    /// <summary>Gets or sets the IANA timezone identifier.</summary>
    [JsonPropertyName("timezone_id")]
    public string TimezoneId { get; set; }

    /// <summary>Gets or sets the timezone numeric offset.</summary>
    [JsonPropertyName("timezone")]
    public int Timezone { get; set; }
}

/// <summary>
/// Aggregated photo date statistics for a Flickr user.
/// </summary>
public struct PhotoDateInfos
{
    /// <summary>Gets or sets the date the user's first photo was taken.</summary>
    [JsonPropertyName("firstdatetaken")]
    public DateTime FirstDateTaken { get; set; }

    /// <summary>Gets or sets the date the user's first photo was uploaded.</summary>
    [JsonPropertyName("firstdate")]
    public DateTime FirstDate { get; set; }

    /// <summary>Gets or sets the total photo count.</summary>
    [JsonPropertyName("count")]
    public int Count { get; set; }
}
