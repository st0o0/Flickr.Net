using Flickr.Net.Core.Bases;
using Newtonsoft.Json;

namespace Flickr.Net.Core;

public record Person : FlickrEntityBase<Id>
{
    [JsonProperty("nsid")]
    public string Nsid { get; set; }

    [JsonProperty("ispro")]
    public bool IsPro { get; set; }

    [JsonProperty("is_deleted")]
    public bool IsDeleted { get; set; }

    [JsonProperty("iconserver")]
    public string IconServer { get; set; }

    [JsonProperty("iconfarm")]
    public int IconFarm { get; set; }

    [JsonProperty("path_alias")]
    public object PathAlias { get; set; }

    [JsonProperty("has_stats")]
    public bool HasStats { get; set; }

    [JsonProperty("username")]
    public Username Username { get; set; }

    [JsonProperty("realname")]
    public Realname Realname { get; set; }

    [JsonProperty("mbox_sha1sum")]
    public MboxSha1sum MboxSha1sum { get; set; }

    [JsonProperty("location")]
    public Location Location { get; set; }

    [JsonProperty("description")]
    public Description Description { get; set; }

    [JsonProperty("photosurl")]
    public PhotosUrl PhotoUrl { get; set; }

    [JsonProperty("profileurl")]
    public ProfileUrl ProfileUrl { get; set; }

    [JsonProperty("mobileurl")]
    public MobileUrl Mobileurl { get; set; }

    [JsonProperty("photos")]
    public PhotoInfos PhotoInfos { get; set; }

    [JsonProperty("upload_count")]
    public int UploadCount { get; set; }

    [JsonProperty("upload_limit")]
    public int UploadLimit { get; set; }

    [JsonProperty("upload_limit_status")]
    public string UploadLimitStatus { get; set; }

    [JsonProperty("is_cognito_user")]
    public bool IsCognitoUser { get; set; }

    [JsonProperty("all_rights_reserved_photos_count")]
    public int AllRightsReservedPhotosCount { get; set; }

    [JsonProperty("has_adfree")]
    public bool HasAdfree { get; set; }

    [JsonProperty("has_free_standard_shipping")]
    public bool HasFreeStandardShipping { get; set; }

    [JsonProperty("has_free_educational_resources")]
    public bool HasFreeEducationalResources { get; set; }
}

public struct PhotoInfos
{
    [JsonProperty("firstdatetaken")]
    public FirstDateTaken Firstdatetaken { get; set; }

    [JsonProperty("firstdate")]
    public FirstDate Firstdate { get; set; }

    [JsonProperty("count")]
    public Count Count { get; set; }

    [JsonProperty("views")]
    public Views Views { get; set; }
}

public struct Username
{
    [JsonProperty("_content")]
    public string Content { get; set; }

    public static implicit operator string(Username username) => username.Content;

    public static implicit operator Username(string username) => new() { Content = username };
}

public struct Views
{
    [JsonProperty("_content")]
    public string Content { get; set; }

    public static implicit operator string(Views username) => username.Content;

    public static implicit operator Views(string username) => new() { Content = username };
}

public struct Realname
{
    [JsonProperty("_content")]
    public string Content { get; set; }

    public static implicit operator string(Realname username) => username.Content;

    public static implicit operator Realname(string username) => new() { Content = username };
}

public struct PhotosUrl
{
    [JsonProperty("_content")]
    public string Content { get; set; }

    public static implicit operator string(PhotosUrl username) => username.Content;

    public static implicit operator PhotosUrl(string username) => new() { Content = username };
}

public struct ProfileUrl
{
    [JsonProperty("_content")]
    public string Content { get; set; }

    public static implicit operator string(ProfileUrl username) => username.Content;

    public static implicit operator ProfileUrl(string username) => new() { Content = username };
}

public struct Count
{
    [JsonProperty("_content")]
    public int Content { get; set; }

    public static implicit operator int(Count username) => username.Content;

    public static implicit operator Count(int username) => new() { Content = username };
}

public struct Description
{
    [JsonProperty("_content")]
    public string Content { get; set; }

    public static implicit operator string(Description username) => username.Content;

    public static implicit operator Description(string username) => new() { Content = username };
}

public struct FirstDate
{
    [JsonProperty("_content")]
    public string Content { get; set; }

    public static implicit operator string(FirstDate username) => username.Content;

    public static implicit operator FirstDate(string username) => new() { Content = username };
}

public struct FirstDateTaken
{
    [JsonProperty("_content")]
    public string Content { get; set; }

    public static implicit operator string(FirstDateTaken username) => username.Content;

    public static implicit operator FirstDateTaken(string username) => new() { Content = username };
}

public struct LocationInfo
{
    [JsonProperty("_content")]
    public string Content { get; set; }

    public static implicit operator string(LocationInfo username) => username.Content;

    public static implicit operator LocationInfo(string username) => new() { Content = username };
}

public struct MboxSha1sum
{
    [JsonProperty("_content")]
    public string Content { get; set; }

    public static implicit operator string(MboxSha1sum username) => username.Content;

    public static implicit operator MboxSha1sum(string username) => new() { Content = username };
}

public struct MobileUrl
{
    [JsonProperty("_content")]
    public string Content { get; set; }

    public static implicit operator string(MobileUrl username) => username.Content;

    public static implicit operator MobileUrl(string username) => new() { Content = username };
}