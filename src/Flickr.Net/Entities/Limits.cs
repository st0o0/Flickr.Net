using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;

/// <summary>
/// </summary>
public record Limits : FlickrEntityBase<NsId>
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("photos")]
    public PhotoLimits Photos { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("videos")]
    public VideoLimits Videos { get; set; }
}

/// <summary>
/// </summary>
public record PhotoLimits
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("maxdisplaypx")]
    public int Maxdisplaypx { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("maxupload")]
    public int Maxupload { get; set; }
}

/// <summary>
/// </summary>
public record VideoLimits
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("maxduration")]
    public int Maxduration { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("maxupload")]
    public int Maxupload { get; set; }
}