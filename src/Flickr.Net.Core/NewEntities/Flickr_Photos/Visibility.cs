using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Visibility : FlickrEntityBase
{
    [JsonProperty("ispublic")]
    public bool IsPublic { get; set; }

    [JsonProperty("isfriend")]
    public bool IsFriend { get; set; }

    [JsonProperty("isfamily")]
    public bool IsFamily { get; set; }
}
