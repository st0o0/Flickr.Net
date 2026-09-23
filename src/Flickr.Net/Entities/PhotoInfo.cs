using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Enums;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

/// <summary>
/// Represents detailed information about a Flickr photo.
/// </summary>
[FlickrJsonPropertyName("photo")]
public record PhotoInfo : PhotoBase, IBuddyIcon, IWebUrl, ISquareUrl, ILargeSquareUrl, IThumbnailUrl, ISmallUrl, ISmall320Url, ISmall400Url, IMediumUrl, IMedium640Url, IMedium800Url, ILargeUrl, ILarge1600Url, ILarge2048Url, IOriginalUrl
{
    /// <summary>Gets or sets the server farm ID.</summary>
    [JsonPropertyName("farm")]
    public int Farm { get; set; }

    /// <summary>Gets or sets the date the photo was uploaded.</summary>
    [JsonPropertyName("dateuploaded")]
    public DateTime UploadedDate { get; set; }

    /// <summary>Gets or sets whether the photo is a favorite of the calling user.</summary>
    [JsonPropertyName("isfavorite")]
    public bool IsFavorite { get; set; }

    /// <summary>Gets or sets the license type of the photo.</summary>
    [JsonPropertyName("license")]
    public LicenseType License { get; set; }

    /// <summary>Gets or sets the safety level of the photo.</summary>
    [JsonPropertyName("safety_level")]
    public SafetyLevel SafetyLevel { get; set; }

    /// <summary>Gets or sets the rotation angle in degrees.</summary>
    [JsonPropertyName("rotation")]
    public int Rotation { get; set; }

    /// <summary>Gets or sets the secret for accessing the original image.</summary>
    [JsonPropertyName("originalsecret")]
    public string OriginalSecret { get; set; }

    /// <summary>Gets or sets the file format of the original image.</summary>
    [JsonPropertyName("originalformat")]
    public string OriginalFormat { get; set; }

    /// <summary>Gets or sets the photo owner information.</summary>
    [JsonPropertyName("owner")]
    public Owner Owner { get; set; }

    /// <summary>Gets or sets the photo title.</summary>
    [JsonPropertyName("title")]
    public Title Title { get; set; }

    /// <summary>Gets or sets the photo description.</summary>
    [JsonPropertyName("description")]
    public Description Description { get; set; }

    /// <summary>Gets or sets the photo visibility settings.</summary>
    [JsonPropertyName("visibility")]
    public Visibility Visibility { get; set; }

    /// <summary>Gets or sets the photo date information.</summary>
    [JsonPropertyName("dates")]
    public Dates Dates { get; set; }

    /// <summary>Gets or sets the total view count.</summary>
    [JsonPropertyName("views")]
    public int Views { get; set; }

    /// <summary>Gets or sets the editability permissions for the calling user.</summary>
    [JsonPropertyName("editability")]
    public Editability Editability { get; set; }

    /// <summary>Gets or sets the public editability permissions.</summary>
    [JsonPropertyName("publiceditability")]
    public PublicEditability PublicEditability { get; set; }

    /// <summary>Gets or sets the usage restrictions for the photo.</summary>
    [JsonPropertyName("usage")]
    public Usage Usage { get; set; }

    /// <summary>Gets or sets the comment count.</summary>
    [JsonPropertyName("comments")]
    public Comments Comments { get; set; }

    /// <summary>Gets or sets the photo notes.</summary>
    [JsonPropertyName("notes")]
    public Notes Notes { get; set; }

    /// <summary>Gets or sets the people tagged in the photo.</summary>
    [JsonPropertyName("people")]
    public People People { get; set; }

    /// <summary>Gets or sets the photo tags.</summary>
    [JsonPropertyName("tags")]
    public PhotoInfoTags Tags { get; set; }

    /// <summary>Gets or sets the photo's geographic location.</summary>
    [JsonPropertyName("location")]
    public Location Location { get; set; }

    /// <summary>Gets or sets the geographic permissions.</summary>
    [JsonPropertyName("geoperms")]
    public GeoPermissions Geoperms { get; set; }

    /// <summary>Gets or sets the URLs associated with the photo.</summary>
    [JsonPropertyName("urls")]
    public Urls Urls { get; set; }

    /// <summary>Gets or sets the media type (photo or video).</summary>
    [JsonPropertyName("media")]
    public MediaType Media { get; set; }
}

/// <summary>
/// Wrapper for a photo title value.
/// </summary>
public struct Title
{
    /// <summary>Gets or sets the title string value.</summary>
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    /// <summary>Implicitly converts a <see cref="Title"/> to a string.</summary>
    public static implicit operator string(Title username) => username.Content;

    /// <summary>Implicitly converts a string to a <see cref="Title"/>.</summary>
    public static implicit operator Title(string username) => new() { Content = username };
}

/// <summary>
/// Wrapper for a comment count value.
/// </summary>
public struct Comments
{
    /// <summary>Gets or sets the comment count value.</summary>
    [JsonPropertyName("_content")]
    public int Content { get; set; }

    /// <summary>Implicitly converts a <see cref="Comments"/> to an int.</summary>
    public static implicit operator int(Comments username) => username.Content;

    /// <summary>Implicitly converts an int to a <see cref="Comments"/>.</summary>
    public static implicit operator Comments(int username) => new() { Content = username };
}

/// <summary>
/// Represents public editability permissions for a photo.
/// </summary>
public record PublicEditability : Editability;

/// <summary>
/// Represents editability permissions for a photo.
/// </summary>
public record Editability
{
    /// <summary>Gets or sets whether commenting is allowed.</summary>
    [JsonPropertyName("cancomment")]
    public bool CanComment { get; set; }

    /// <summary>Gets or sets whether adding metadata is allowed.</summary>
    [JsonPropertyName("canaddmeta")]
    public bool CanAddMeta { get; set; }
}

/// <summary>
/// Represents people-tagging information for a photo.
/// </summary>
public record People
{
    /// <summary>Gets or sets whether the photo has people tagged.</summary>
    [JsonPropertyName("haspeople")]
    public bool HasPeople { get; set; }
}
