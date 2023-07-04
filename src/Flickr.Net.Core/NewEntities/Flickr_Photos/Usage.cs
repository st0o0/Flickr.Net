using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Usage : FlickrEntityBase
{
    [JsonProperty("candownload")]
    public bool CanDownload { get; set; }

    [JsonProperty("canblog")]
    public bool CanBlog { get; set; }

    [JsonProperty("canprint")]
    public bool CanPrint { get; set; }

    [JsonProperty("canshare")]
    public bool CanShare { get; set; }
}
