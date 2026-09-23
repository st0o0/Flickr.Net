using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;
/// <summary>Represents upload limits for a user's account.</summary>
public record Limits : FlickrEntityBase<NsId>
{
    [JsonPropertyName("photos")]
    public PhotoLimits? Photos { get; init; }
    [JsonPropertyName("videos")]
    public VideoLimits? Videos { get; init; }
}
/// <summary>Photo-specific upload and display limits.</summary>
public record PhotoLimits
{
    [JsonPropertyName("maxdisplaypx")]
    /// <summary>The maximum display size in pixels.</summary>
    public int Maxdisplaypx { get; init; }
    [JsonPropertyName("maxupload")]
    /// <summary>The maximum upload file size in bytes.</summary>
    public int Maxupload { get; init; }
}
/// <summary>Video-specific upload and duration limits.</summary>
public record VideoLimits
{
    [JsonPropertyName("maxduration")]
    /// <summary>The maximum video duration in seconds.</summary>
    public int Maxduration { get; init; }
    [JsonPropertyName("maxupload")]
    /// <summary>The maximum upload file size in bytes.</summary>
    public int Maxupload { get; init; }
}
