using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("who")]
public record Who : FlickrEntityBase<Id>
{
    [JsonProperty("tags")]
    public UserTags Tags { get; set; }
}
