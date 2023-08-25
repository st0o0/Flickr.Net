using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("photo")]
public record PhotoInfo : PhotoBase, IBuddyIcon, IWebUrl, ISquareUrl, ILargeSquareUrl, IThumbnailUrl, ISmallUrl, ISmall320Url, ISmall400Url, IMediumUrl, IMedium640Url, IMedium800Url, ILargeUrl, ILarge1600Url, ILarge2048Url, IOriginalUrl
{
    [JsonPropertyName("farm")]
    public int Farm { get; set; }

    [JsonPropertyName("dateuploaded")]
    public DateTime UploadedDate { get; set; }

    [JsonPropertyName("isfavorite")]
    public bool IsFavorite { get; set; }

    [JsonPropertyName("license")]
    public LicenseType License { get; set; }

    [JsonPropertyName("safety_level")]
    public SafetyLevel SafetyLevel { get; set; }

    [JsonPropertyName("rotation")]
    public int Rotation { get; set; }

    [JsonPropertyName("originalsecret")]
    public string OriginalSecret { get; set; }

    [JsonPropertyName("originalformat")]
    public string OriginalFormat { get; set; }

    [JsonPropertyName("owner")]
    public Owner Owner { get; set; }

    [JsonPropertyName("title")]
    public Title Title { get; set; }

    [JsonPropertyName("description")]
    public Description Description { get; set; }

    [JsonPropertyName("visibility")]
    public Visibility Visibility { get; set; }

    [JsonPropertyName("dates")]
    public Dates Dates { get; set; }

    [JsonPropertyName("views")]
    public int Views { get; set; }

    [JsonPropertyName("editability")]
    public Editability Editability { get; set; }

    [JsonPropertyName("publiceditability")]
    public PublicEditability PublicEditability { get; set; }

    [JsonPropertyName("usage")]
    public Usage Usage { get; set; }

    [JsonPropertyName("comments")]
    public Comments Comments { get; set; }

    [JsonPropertyName("notes")]
    public Notes Notes { get; set; }

    [JsonPropertyName("people")]
    public People People { get; set; }

    [JsonPropertyName("tags")]
    public PhotoInfoTags Tags { get; set; }

    [JsonPropertyName("location")]
    public Location Location { get; set; }

    [JsonPropertyName("geoperms")]
    public GeoPermissions Geoperms { get; set; }

    [JsonPropertyName("urls")]
    public Urls Urls { get; set; }

    [JsonPropertyName("media")]
    public MediaType Media { get; set; }
}

public struct Title
{
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    public static implicit operator string(Title username) => username.Content;

    public static implicit operator Title(string username) => new() { Content = username };
}

public struct Comments
{
    [JsonPropertyName("_content")]
    public int Content { get; set; }

    public static implicit operator int(Comments username) => username.Content;

    public static implicit operator Comments(int username) => new() { Content = username };
}

public record PublicEditability : Editability
{
}

public record Editability
{
    [JsonPropertyName("cancomment")]
    public bool CanComment { get; set; }

    [JsonPropertyName("canaddmeta")]
    public bool CanAddMeta { get; set; }
}

public record People
{
    [JsonPropertyName("haspeople")]
    public bool HasPeople { get; set; }
}