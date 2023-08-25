using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Camera : FlickrEntityBase<Id>
{
    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("details")]
    public Details Details { get; set; }

    [JsonPropertyName("images")]
    public Image Image { get; set; }
}