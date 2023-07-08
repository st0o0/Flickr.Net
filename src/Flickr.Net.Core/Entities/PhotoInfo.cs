using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("photo")]
public record PhotoInfo : PhotoBase
{
    [JsonProperty("farm")]
    public int Farm { get; set; }

    [JsonProperty("dateuploaded")]
    public DateTime UploadedDate { get; set; }

    [JsonProperty("isfavorite")]
    public bool IsFavorite { get; set; }

    [JsonProperty("license")]
    public LicenseType License { get; set; }

    [JsonProperty("safety_level")]
    public SafetyLevel SafetyLevel { get; set; }

    [JsonProperty("rotation")]
    public int Rotation { get; set; }

    [JsonProperty("originalsecret")]
    public string OriginalSecret { get; set; }

    [JsonProperty("originalformat")]
    public string OriginalFormat { get; set; }

    [JsonProperty("owner")]
    public Owner Owner { get; set; }

    [JsonProperty("title")]
    public Title Title { get; set; }

    [JsonProperty("description")]
    public Description Description { get; set; }

    [JsonProperty("visibility")]
    public Visibility Visibility { get; set; }

    [JsonProperty("dates")]
    public Dates Dates { get; set; }

    [JsonProperty("views")]
    public int Views { get; set; }

    [JsonProperty("editability")]
    public Editability Editability { get; set; }

    [JsonProperty("publiceditability")]
    public PublicEditability PublicEditability { get; set; }

    [JsonProperty("usage")]
    public Usage Usage { get; set; }

    [JsonProperty("comments")]
    public Comments Comments { get; set; }

    [JsonProperty("notes")]
    public Notes Notes { get; set; }

    [JsonProperty("people")]
    public People People { get; set; }

    [JsonProperty("tags")]
    public PhotoInfoTags Tags { get; set; }

    [JsonProperty("location")]
    public Location Location { get; set; }

    [JsonProperty("geoperms")]
    public GeoPermissions Geoperms { get; set; }

    [JsonProperty("urls")]
    public Urls Urls { get; set; }

    [JsonProperty("media")]
    public MediaType Media { get; set; }
}

public struct Title
{
    [JsonProperty("_content")]
    public string Content { get; set; }

    public static implicit operator string(Title username) => username.Content;

    public static implicit operator Title(string username) => new() { Content = username };
}

public struct Comments
{
    [JsonProperty("_content")]
    public int Content { get; set; }

    public static implicit operator int(Comments username) => username.Content;

    public static implicit operator Comments(int username) => new() { Content = username };
}

public record PublicEditability : Editability
{
}

public record Editability
{
    [JsonProperty("cancomment")]
    public bool CanComment { get; set; }

    [JsonProperty("canaddmeta")]
    public bool CanAddMeta { get; set; }
}

public record People
{
    [JsonProperty("haspeople")]
    public bool HasPeople { get; set; }
}