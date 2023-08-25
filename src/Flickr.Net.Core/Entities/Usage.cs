using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Usage : FlickrEntityBase
{
    [JsonPropertyName("candownload")]
    public bool CanDownload { get; set; }

    [JsonPropertyName("canblog")]
    public bool CanBlog { get; set; }

    [JsonPropertyName("canprint")]
    public bool CanPrint { get; set; }

    [JsonPropertyName("canshare")]
    public bool CanShare { get; set; }
}
