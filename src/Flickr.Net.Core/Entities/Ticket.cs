using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Ticket : FlickrEntityBase<Id>
{
    [JsonPropertyName("complete")]
    public StatusType Complete { get; set; }

    [JsonPropertyName("photoid")]
    public string PhotoId { get; set; }

    [JsonPropertyName("invalid")]
    public bool Invalid { get; set; }
}
