using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record CollectionSet : FlickrEntityBase<Id>
{
    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }
}