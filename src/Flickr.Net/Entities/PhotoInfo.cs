using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("photo")]
public record PhotoInfo : PhotoBase, IBuddyIcon, IWebUrl, ISquareUrl, ILargeSquareUrl, IThumbnailUrl, ISmallUrl, ISmall320Url, ISmall400Url, IMediumUrl, IMedium640Url, IMedium800Url, ILargeUrl, ILarge1600Url, ILarge2048Url, IOriginalUrl
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("farm")]
    public int Farm { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("dateuploaded")]
    public DateTime UploadedDate { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("isfavorite")]
    public bool IsFavorite { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("license")]
    public LicenseType License { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("safety_level")]
    public SafetyLevel SafetyLevel { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("rotation")]
    public int Rotation { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("originalsecret")]
    public string OriginalSecret { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("originalformat")]
    public string OriginalFormat { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("owner")]
    public Owner Owner { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("title")]
    public Title Title { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("description")]
    public Description Description { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("visibility")]
    public Visibility Visibility { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("dates")]
    public Dates Dates { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("views")]
    public int Views { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("editability")]
    public Editability Editability { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("publiceditability")]
    public PublicEditability PublicEditability { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("usage")]
    public Usage Usage { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("comments")]
    public Comments Comments { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("notes")]
    public Notes Notes { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("people")]
    public People People { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("tags")]
    public PhotoInfoTags Tags { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("location")]
    public Location Location { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("geoperms")]
    public GeoPermissions Geoperms { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("urls")]
    public Urls Urls { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("media")]
    public MediaType Media { get; set; }
}

/// <summary>
/// </summary>
public struct Title
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    /// <summary>
    /// </summary>
    public static implicit operator string(Title username) => username.Content;

    /// <summary>
    /// </summary>
    public static implicit operator Title(string username) => new() { Content = username };
}

/// <summary>
/// </summary>
public struct Comments
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("_content")]
    public int Content { get; set; }

    /// <summary>
    /// </summary>
    public static implicit operator int(Comments username) => username.Content;

    /// <summary>
    /// </summary>
    public static implicit operator Comments(int username) => new() { Content = username };
}

/// <summary>
/// </summary>
public record PublicEditability : Editability
{
}

/// <summary>
/// </summary>
public record Editability
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("cancomment")]
    public bool CanComment { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("canaddmeta")]
    public bool CanAddMeta { get; set; }
}

/// <summary>
/// </summary>
public record People
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("haspeople")]
    public bool HasPeople { get; set; }
}