using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;

/// <summary>
/// </summary>
public record Usage : FlickrEntityBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("candownload")]
    public bool CanDownload { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("canblog")]
    public bool CanBlog { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("canprint")]
    public bool CanPrint { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("canshare")]
    public bool CanShare { get; set; }
}
