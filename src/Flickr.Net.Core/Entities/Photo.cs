using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("photo")]
public record Photo : UltraDeluxePhotoBase
{
    [JsonProperty("dateadded")]
    public DateTime AddedDate { get; set; }
}