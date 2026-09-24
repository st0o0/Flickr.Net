using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;

/// <summary>
/// Represents a Flickr user.
/// </summary>
public record Person : FlickrEntityBase<Id>, IBuddyIcon
{
    /// <summary>Gets or sets the user's NSID.</summary>
    [JsonPropertyName("nsid")]
    public string? Nsid { get; init; }

    /// <summary>Gets or sets whether the user has a Pro account.</summary>
    [JsonPropertyName("ispro")]
    public bool IsPro { get; init; }

    /// <summary>Gets or sets whether the user account has been deleted.</summary>
    [JsonPropertyName("is_deleted")]
    public bool IsDeleted { get; init; }

    /// <summary>Gets or sets the icon server for the user's buddy icon.</summary>
    [JsonPropertyName("iconserver")]
    public string? IconServer { get; init; }

    /// <summary>Gets or sets the icon farm for the user's buddy icon.</summary>
    [JsonPropertyName("iconfarm")]
    public int IconFarm { get; init; }

    /// <summary>Gets or sets the user's custom URL path alias.</summary>
    [JsonPropertyName("path_alias")]
    public string? PathAlias { get; init; }

    /// <summary>Whether the authenticated user has added this person as a contact.</summary>
    [JsonPropertyName("contact")]
    public bool? Contact { get; init; }

    /// <summary>Whether the authenticated user has marked this person as a friend.</summary>
    [JsonPropertyName("friend")]
    public bool? Friend { get; init; }

    /// <summary>Whether the authenticated user has marked this person as family.</summary>
    [JsonPropertyName("family")]
    public bool? Family { get; init; }

    /// <summary>Whether this person has added the authenticated user as a contact.</summary>
    [JsonPropertyName("revcontact")]
    public bool? RevContact { get; init; }

    /// <summary>Whether this person has marked the authenticated user as a friend.</summary>
    [JsonPropertyName("revfriend")]
    public bool? RevFriend { get; init; }

    /// <summary>Whether this person has marked the authenticated user as a family member.</summary>
    [JsonPropertyName("revfamily")]
    public bool? RevFamily { get; init; }

    /// <summary>Gets or sets whether the user has access to stats.</summary>
    [JsonPropertyName("has_stats")]
    public bool HasStats { get; init; }

    /// <summary>Gets or sets the user's username.</summary>
    [JsonPropertyName("username")]
    public Username Username { get; init; }

    /// <summary>Gets or sets the user's real name.</summary>
    [JsonPropertyName("realname")]
    public Realname Realname { get; init; }

    /// <summary>Gets or sets the SHA1 hash of the user's email address.</summary>
    [JsonPropertyName("mbox_sha1sum")]
    public MboxSha1sum MboxSha1sum { get; init; }

    /// <summary>Gets or sets the user's location.</summary>
    [JsonPropertyName("location")]
    public Location? Location { get; init; }

    /// <summary>Gets or sets the user's profile description.</summary>
    [JsonPropertyName("description")]
    public Description Description { get; init; }

    /// <summary>Gets or sets the URL to the user's photo stream.</summary>
    [JsonPropertyName("photosurl")]
    public PhotosUrl PhotoUrl { get; init; }

    /// <summary>Gets or sets the URL to the user's profile page.</summary>
    [JsonPropertyName("profileurl")]
    public ProfileUrl ProfileUrl { get; init; }

    /// <summary>Gets or sets the user's mobile URL.</summary>
    [JsonPropertyName("mobileurl")]
    public MobileUrl Mobileurl { get; init; }

    /// <summary>Gets or sets aggregated photo information for the user.</summary>
    [JsonPropertyName("photos")]
    public PhotoInfos PhotoInfos { get; init; }

    /// <summary>Gets or sets the number of photos the user has uploaded.</summary>
    [JsonPropertyName("upload_count")]
    public int UploadCount { get; init; }

    /// <summary>Gets or sets the user's upload limit.</summary>
    [JsonPropertyName("upload_limit")]
    public int UploadLimit { get; init; }

    /// <summary>Gets or sets the status of the user's upload limit.</summary>
    [JsonPropertyName("upload_limit_status")]
    public string? UploadLimitStatus { get; init; }

    /// <summary>Gets or sets whether the user is a Cognito user.</summary>
    [JsonPropertyName("is_cognito_user")]
    public bool IsCognitoUser { get; init; }

    /// <summary>Gets or sets the count of the user's all-rights-reserved photos.</summary>
    [JsonPropertyName("all_rights_reserved_photos_count")]
    public int AllRightsReservedPhotosCount { get; init; }

    /// <summary>Gets or sets whether the user has an ad-free experience.</summary>
    [JsonPropertyName("has_adfree")]
    public bool HasAdfree { get; init; }

    /// <summary>Gets or sets whether the user has free standard shipping.</summary>
    [JsonPropertyName("has_free_standard_shipping")]
    public bool HasFreeStandardShipping { get; init; }

    /// <summary>Gets or sets whether the user has free educational resources.</summary>
    [JsonPropertyName("has_free_educational_resources")]
    public bool HasFreeEducationalResources { get; init; }
}

/// <summary>
/// Aggregated photo statistics for a Flickr user.
/// </summary>
public struct PhotoInfos
{
    /// <summary>Gets or sets the date the user's first photo was taken.</summary>
    [JsonPropertyName("firstdatetaken")]
    public FirstDateTaken Firstdatetaken { get; init; }

    /// <summary>Gets or sets the date the user's first photo was uploaded.</summary>
    [JsonPropertyName("firstdate")]
    public FirstDate Firstdate { get; init; }

    /// <summary>Gets or sets the total photo count.</summary>
    [JsonPropertyName("count")]
    public Count Count { get; init; }

    /// <summary>Gets or sets the total view count.</summary>
    [JsonPropertyName("views")]
    public PhotoInfoViews Views { get; init; }
}

/// <summary>
/// Wrapper for a Flickr username value.
/// </summary>
public struct Username
{
    /// <summary>Gets or sets the username string value.</summary>
    [JsonPropertyName("_content")]
    public string? Content { get; init; }

    /// <summary>Implicitly converts a <see cref="Username"/> to a string.</summary>
    public static implicit operator string(Username username) => username.Content!;

    /// <summary>Implicitly converts a string to a <see cref="Username"/>.</summary>
    public static implicit operator Username(string username) => new() { Content = username };
}

/// <summary>
/// Wrapper for photo view count information.
/// </summary>
public struct PhotoInfoViews
{
    /// <summary>Gets or sets the view count string value.</summary>
    [JsonPropertyName("_content")]
    public string? Content { get; init; }

    /// <summary>Implicitly converts a <see cref="PhotoInfoViews"/> to a string.</summary>
    public static implicit operator string(PhotoInfoViews username) => username.Content!;

    /// <summary>Implicitly converts a string to a <see cref="PhotoInfoViews"/>.</summary>
    public static implicit operator PhotoInfoViews(string username) => new() { Content = username };
}

/// <summary>
/// Wrapper for a Flickr user's real name value.
/// </summary>
public struct Realname
{
    /// <summary>Gets or sets the real name string value.</summary>
    [JsonPropertyName("_content")]
    public string? Content { get; init; }

    /// <summary>Implicitly converts a <see cref="Realname"/> to a string.</summary>
    public static implicit operator string(Realname username) => username.Content!;

    /// <summary>Implicitly converts a string to a <see cref="Realname"/>.</summary>
    public static implicit operator Realname(string username) => new() { Content = username };
}

/// <summary>
/// Wrapper for a Flickr user's photos URL.
/// </summary>
public struct PhotosUrl
{
    /// <summary>Gets or sets the URL string value.</summary>
    [JsonPropertyName("_content")]
    public string? Content { get; init; }

    /// <summary>Implicitly converts a <see cref="PhotosUrl"/> to a string.</summary>
    public static implicit operator string(PhotosUrl username) => username.Content!;

    /// <summary>Implicitly converts a string to a <see cref="PhotosUrl"/>.</summary>
    public static implicit operator PhotosUrl(string username) => new() { Content = username };
}

/// <summary>
/// Wrapper for a Flickr user's profile URL.
/// </summary>
public struct ProfileUrl
{
    /// <summary>Gets or sets the URL string value.</summary>
    [JsonPropertyName("_content")]
    public string? Content { get; init; }

    /// <summary>Implicitly converts a <see cref="ProfileUrl"/> to a string.</summary>
    public static implicit operator string(ProfileUrl username) => username.Content!;

    /// <summary>Implicitly converts a string to a <see cref="ProfileUrl"/>.</summary>
    public static implicit operator ProfileUrl(string username) => new() { Content = username };
}

/// <summary>
/// Wrapper for an integer count value.
/// </summary>
public struct Count
{
    /// <summary>Gets or sets the integer count value.</summary>
    [JsonPropertyName("_content")]
    public int Content { get; init; }

    /// <summary>Implicitly converts a <see cref="Count"/> to an int.</summary>
    public static implicit operator int(Count username) => username.Content;

    /// <summary>Implicitly converts an int to a <see cref="Count"/>.</summary>
    public static implicit operator Count(int username) => new() { Content = username };
}

/// <summary>
/// Wrapper for a Flickr description value.
/// </summary>
public struct Description
{
    /// <summary>Gets or sets the description string value.</summary>
    [JsonPropertyName("_content")]
    public string? Content { get; init; }

    /// <summary>Implicitly converts a <see cref="Description"/> to a string.</summary>
    public static implicit operator string(Description username) => username.Content!;

    /// <summary>Implicitly converts a string to a <see cref="Description"/>.</summary>
    public static implicit operator Description(string username) => new() { Content = username };
}

/// <summary>
/// Wrapper for the first upload date value.
/// </summary>
public struct FirstDate
{
    /// <summary>Gets or sets the date string value.</summary>
    [JsonPropertyName("_content")]
    public string? Content { get; init; }

    /// <summary>Implicitly converts a <see cref="FirstDate"/> to a string.</summary>
    public static implicit operator string(FirstDate username) => username.Content!;

    /// <summary>Implicitly converts a string to a <see cref="FirstDate"/>.</summary>
    public static implicit operator FirstDate(string username) => new() { Content = username };
}

/// <summary>
/// Wrapper for the first date taken value.
/// </summary>
public struct FirstDateTaken
{
    /// <summary>Gets or sets the date string value.</summary>
    [JsonPropertyName("_content")]
    public string? Content { get; init; }

    /// <summary>Implicitly converts a <see cref="FirstDateTaken"/> to a string.</summary>
    public static implicit operator string(FirstDateTaken username) => username.Content!;

    /// <summary>Implicitly converts a string to a <see cref="FirstDateTaken"/>.</summary>
    public static implicit operator FirstDateTaken(string username) => new() { Content = username };
}

/// <summary>
/// Wrapper for a user's location info value.
/// </summary>
public struct LocationInfo
{
    /// <summary>Gets or sets the location string value.</summary>
    [JsonPropertyName("_content")]
    public string? Content { get; init; }

    /// <summary>Implicitly converts a <see cref="LocationInfo"/> to a string.</summary>
    public static implicit operator string(LocationInfo username) => username.Content!;

    /// <summary>Implicitly converts a string to a <see cref="LocationInfo"/>.</summary>
    public static implicit operator LocationInfo(string username) => new() { Content = username };
}

/// <summary>
/// Wrapper for the SHA1 hash of a user's email address.
/// </summary>
public struct MboxSha1sum
{
    /// <summary>Gets or sets the SHA1 hash string value.</summary>
    [JsonPropertyName("_content")]
    public string? Content { get; init; }

    /// <summary>Implicitly converts a <see cref="MboxSha1sum"/> to a string.</summary>
    public static implicit operator string(MboxSha1sum username) => username.Content!;

    /// <summary>Implicitly converts a string to a <see cref="MboxSha1sum"/>.</summary>
    public static implicit operator MboxSha1sum(string username) => new() { Content = username };
}

/// <summary>
/// Wrapper for a user's mobile URL value.
/// </summary>
public struct MobileUrl
{
    /// <summary>Gets or sets the URL string value.</summary>
    [JsonPropertyName("_content")]
    public string? Content { get; init; }

    /// <summary>Implicitly converts a <see cref="MobileUrl"/> to a string.</summary>
    public static implicit operator string(MobileUrl username) => username.Content!;

    /// <summary>Implicitly converts a string to a <see cref="MobileUrl"/>.</summary>
    public static implicit operator MobileUrl(string username) => new() { Content = username };
}
