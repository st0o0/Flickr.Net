using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;

/// <summary>
/// </summary>
public record Person : FlickrEntityBase<Id>, IBuddyIcon
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("nsid")]
    public string Nsid { get; set; }

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
    public object PathAlias { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("has_stats")]
    public bool HasStats { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("username")]
    public Username Username { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("realname")]
    public Realname Realname { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("mbox_sha1sum")]
    public MboxSha1sum MboxSha1sum { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("location")]
    public Location Location { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("description")]
    public Description Description { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("photosurl")]
    public PhotosUrl PhotoUrl { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("profileurl")]
    public ProfileUrl ProfileUrl { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("mobileurl")]
    public MobileUrl Mobileurl { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("photos")]
    public PhotoInfos PhotoInfos { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("upload_count")]
    public int UploadCount { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("upload_limit")]
    public int UploadLimit { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("upload_limit_status")]
    public string UploadLimitStatus { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("is_cognito_user")]
    public bool IsCognitoUser { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("all_rights_reserved_photos_count")]
    public int AllRightsReservedPhotosCount { get; set; }

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
}

/// <summary>
/// </summary>
public struct PhotoInfos
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("firstdatetaken")]
    public FirstDateTaken Firstdatetaken { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("firstdate")]
    public FirstDate Firstdate { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("count")]
    public Count Count { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("views")]
    public PhotoInfoViews Views { get; set; }
}

/// <summary>
/// </summary>
public struct Username
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    /// <summary>
    /// </summary>
    public static implicit operator string(Username username) => username.Content;

    /// <summary>
    /// </summary>
    public static implicit operator Username(string username) => new() { Content = username };
}

/// <summary>
/// </summary>
public struct PhotoInfoViews
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    /// <summary>
    /// </summary>
    public static implicit operator string(PhotoInfoViews username) => username.Content;

    /// <summary>
    /// </summary>
    public static implicit operator PhotoInfoViews(string username) => new() { Content = username };
}

/// <summary>
/// </summary>
public struct Realname
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    /// <summary>
    /// </summary>
    public static implicit operator string(Realname username) => username.Content;

    /// <summary>
    /// </summary>
    public static implicit operator Realname(string username) => new() { Content = username };
}

/// <summary>
/// </summary>
public struct PhotosUrl
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    /// <summary>
    /// </summary>
    public static implicit operator string(PhotosUrl username) => username.Content;

    /// <summary>
    /// </summary>
    public static implicit operator PhotosUrl(string username) => new() { Content = username };
}

/// <summary>
/// </summary>
public struct ProfileUrl
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    /// <summary>
    /// </summary>
    public static implicit operator string(ProfileUrl username) => username.Content;

    /// <summary>
    /// </summary>
    public static implicit operator ProfileUrl(string username) => new() { Content = username };
}

/// <summary>
/// </summary>
public struct Count
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("_content")]
    public int Content { get; set; }

    /// <summary>
    /// </summary>
    public static implicit operator int(Count username) => username.Content;

    /// <summary>
    /// </summary>
    public static implicit operator Count(int username) => new() { Content = username };
}

/// <summary>
/// </summary>
public struct Description
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    /// <summary>
    /// </summary>
    public static implicit operator string(Description username) => username.Content;

    /// <summary>
    /// </summary>
    public static implicit operator Description(string username) => new() { Content = username };
}

/// <summary>
/// </summary>
public struct FirstDate
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    /// <summary>
    /// </summary>
    public static implicit operator string(FirstDate username) => username.Content;

    /// <summary>
    /// </summary>
    public static implicit operator FirstDate(string username) => new() { Content = username };
}

/// <summary>
/// </summary>
public struct FirstDateTaken
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    /// <summary>
    /// </summary>
    public static implicit operator string(FirstDateTaken username) => username.Content;

    /// <summary>
    /// </summary>
    public static implicit operator FirstDateTaken(string username) => new() { Content = username };
}

/// <summary>
/// </summary>
public struct LocationInfo
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    /// <summary>
    /// </summary>
    public static implicit operator string(LocationInfo username) => username.Content;

    /// <summary>
    /// </summary>
    public static implicit operator LocationInfo(string username) => new() { Content = username };
}

/// <summary>
/// </summary>
public struct MboxSha1sum
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    /// <summary>
    /// </summary>
    public static implicit operator string(MboxSha1sum username) => username.Content;

    /// <summary>
    /// </summary>
    public static implicit operator MboxSha1sum(string username) => new() { Content = username };
}

/// <summary>
/// </summary>
public struct MobileUrl
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    /// <summary>
    /// </summary>
    public static implicit operator string(MobileUrl username) => username.Content;

    /// <summary>
    /// </summary>
    public static implicit operator MobileUrl(string username) => new() { Content = username };
}