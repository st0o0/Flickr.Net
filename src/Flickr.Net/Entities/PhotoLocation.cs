using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net.NewEntities.Flickr_Photos;

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
