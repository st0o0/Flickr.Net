using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Person : FlickrEntityBase<Id>, IBuddyIcon
{
    [JsonPropertyName("nsid")]
    public string Nsid { get; set; }

    [JsonPropertyName("ispro")]
    public bool IsPro { get; set; }

    [JsonPropertyName("is_deleted")]
    public bool IsDeleted { get; set; }

    [JsonPropertyName("iconserver")]
    public string IconServer { get; set; }

    [JsonPropertyName("iconfarm")]
    public int IconFarm { get; set; }

    [JsonPropertyName("path_alias")]
    public object PathAlias { get; set; }

    [JsonPropertyName("has_stats")]
    public bool HasStats { get; set; }

    [JsonPropertyName("username")]
    public Username Username { get; set; }

    [JsonPropertyName("realname")]
    public Realname Realname { get; set; }

    [JsonPropertyName("mbox_sha1sum")]
    public MboxSha1sum MboxSha1sum { get; set; }

    [JsonPropertyName("location")]
    public Location Location { get; set; }

    [JsonPropertyName("description")]
    public Description Description { get; set; }

    [JsonPropertyName("photosurl")]
    public PhotosUrl PhotoUrl { get; set; }

    [JsonPropertyName("profileurl")]
    public ProfileUrl ProfileUrl { get; set; }

    [JsonPropertyName("mobileurl")]
    public MobileUrl Mobileurl { get; set; }

    [JsonPropertyName("photos")]
    public PhotoInfos PhotoInfos { get; set; }

    [JsonPropertyName("upload_count")]
    public int UploadCount { get; set; }

    [JsonPropertyName("upload_limit")]
    public int UploadLimit { get; set; }

    [JsonPropertyName("upload_limit_status")]
    public string UploadLimitStatus { get; set; }

    [JsonPropertyName("is_cognito_user")]
    public bool IsCognitoUser { get; set; }

    [JsonPropertyName("all_rights_reserved_photos_count")]
    public int AllRightsReservedPhotosCount { get; set; }

    [JsonPropertyName("has_adfree")]
    public bool HasAdfree { get; set; }

    [JsonPropertyName("has_free_standard_shipping")]
    public bool HasFreeStandardShipping { get; set; }

    [JsonPropertyName("has_free_educational_resources")]
    public bool HasFreeEducationalResources { get; set; }
}

public struct PhotoInfos
{
    [JsonPropertyName("firstdatetaken")]
    public FirstDateTaken Firstdatetaken { get; set; }

    [JsonPropertyName("firstdate")]
    public FirstDate Firstdate { get; set; }

    [JsonPropertyName("count")]
    public Count Count { get; set; }

    [JsonPropertyName("views")]
    public PhotoInfoViews Views { get; set; }
}

public struct Username
{
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    public static implicit operator string(Username username) => username.Content;

    public static implicit operator Username(string username) => new() { Content = username };
}

public struct PhotoInfoViews
{
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    public static implicit operator string(PhotoInfoViews username) => username.Content;

    public static implicit operator PhotoInfoViews(string username) => new() { Content = username };
}

public struct Realname
{
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    public static implicit operator string(Realname username) => username.Content;

    public static implicit operator Realname(string username) => new() { Content = username };
}

public struct PhotosUrl
{
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    public static implicit operator string(PhotosUrl username) => username.Content;

    public static implicit operator PhotosUrl(string username) => new() { Content = username };
}

public struct ProfileUrl
{
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    public static implicit operator string(ProfileUrl username) => username.Content;

    public static implicit operator ProfileUrl(string username) => new() { Content = username };
}

public struct Count
{
    [JsonPropertyName("_content")]
    public int Content { get; set; }

    public static implicit operator int(Count username) => username.Content;

    public static implicit operator Count(int username) => new() { Content = username };
}

public struct Description
{
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    public static implicit operator string(Description username) => username.Content;

    public static implicit operator Description(string username) => new() { Content = username };
}

public struct FirstDate
{
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    public static implicit operator string(FirstDate username) => username.Content;

    public static implicit operator FirstDate(string username) => new() { Content = username };
}

public struct FirstDateTaken
{
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    public static implicit operator string(FirstDateTaken username) => username.Content;

    public static implicit operator FirstDateTaken(string username) => new() { Content = username };
}

public struct LocationInfo
{
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    public static implicit operator string(LocationInfo username) => username.Content;

    public static implicit operator LocationInfo(string username) => new() { Content = username };
}

public struct MboxSha1sum
{
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    public static implicit operator string(MboxSha1sum username) => username.Content;

    public static implicit operator MboxSha1sum(string username) => new() { Content = username };
}

public struct MobileUrl
{
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    public static implicit operator string(MobileUrl username) => username.Content;

    public static implicit operator MobileUrl(string username) => new() { Content = username };
}