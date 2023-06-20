using Flickr.Net.Core.Bases;
using Newtonsoft.Json;

namespace Flickr.Net.Core;

public record Limits : FlickrEntityBase<NsId>
{
    [JsonProperty("photos")]
    public PhotoLimits Photos { get; set; }

    [JsonProperty("videos")]
    public VideoLimits Videos { get; set; }
}

public record PhotoLimits
{
    [JsonProperty("maxdisplaypx")]
    public int Maxdisplaypx { get; set; }

    [JsonProperty("maxupload")]
    public int Maxupload { get; set; }
}

public record VideoLimits
{
    [JsonProperty("maxduration")]
    public int Maxduration { get; set; }

    [JsonProperty("maxupload")]
    public int Maxupload { get; set; }
}