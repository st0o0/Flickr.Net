using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net.NewEntities.Flickr_Photos;

[FlickrJsonPropertyName("photo")]
/// <summary>Represents the geographic location of a photo.</summary>
public record PhotoLocation : FlickrEntityBase<Id>
{
    [JsonPropertyName("location")]
    public Location? Location { get; init; }
}
