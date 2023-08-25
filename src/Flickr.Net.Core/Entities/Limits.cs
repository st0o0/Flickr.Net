using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Limits : FlickrEntityBase<NsId>
{
    [JsonPropertyName("photos")]
    public PhotoLimits Photos { get; set; }

    [JsonPropertyName("videos")]
    public VideoLimits Videos { get; set; }
}

public record PhotoLimits
{
    [JsonPropertyName("maxdisplaypx")]
    public int Maxdisplaypx { get; set; }

    [JsonPropertyName("maxupload")]
    public int Maxupload { get; set; }
}

public record VideoLimits
{
    [JsonPropertyName("maxduration")]
    public int Maxduration { get; set; }

    [JsonPropertyName("maxupload")]
    public int Maxupload { get; set; }
}