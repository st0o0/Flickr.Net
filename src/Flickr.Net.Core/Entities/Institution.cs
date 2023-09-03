using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Institution : FlickrEntityBase<NsId>
{
    [JsonPropertyName("date_launch")]
    public DateTime LaunchDate { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("urls")]
    public Urls Urls { get; set; }
}