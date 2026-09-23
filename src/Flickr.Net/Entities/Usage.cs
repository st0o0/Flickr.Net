using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;
/// <summary>Represents bandwidth and storage usage statistics.</summary>
public record Usage : FlickrEntityBase
{    [JsonPropertyName("candownload")]
    /// <summary>Whether the photo can be downloaded.</summary>
    public bool CanDownload { get; init; }
    [JsonPropertyName("canblog")]
    /// <summary>Whether the photo can be blogged.</summary>
    public bool CanBlog { get; init; }
    [JsonPropertyName("canprint")]
    /// <summary>Whether the photo can be printed.</summary>
    public bool CanPrint { get; init; }
    [JsonPropertyName("canshare")]
    /// <summary>Whether the photo can be shared.</summary>
    public bool CanShare { get; init; }
}
