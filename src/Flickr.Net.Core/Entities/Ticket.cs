using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Ticket : FlickrEntityBase<Id>
{
    [JsonProperty("complete")]
    public StatusType Complete { get; set; }

    [JsonProperty("photoid")]
    public string PhotoId { get; set; }

    [JsonProperty("invalid")]
    public bool Invalid { get; set; }
}
