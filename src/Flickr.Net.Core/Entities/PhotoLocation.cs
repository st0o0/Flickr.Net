using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core.NewEntities.Flickr_Photos;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("photo")]
public record PhotoLocation : FlickrEntityBase<Id>
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("location")]
    public Location Location { get; set; }
}
