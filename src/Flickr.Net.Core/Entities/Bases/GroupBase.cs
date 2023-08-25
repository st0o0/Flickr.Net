using System.Text.Json.Serialization;

namespace Flickr.Net.Core.Bases;

public record GroupBase : FlickrEntityBase<NsId>
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("eighteenplus")]
    public bool EighteenPlus { get; set; }
}
