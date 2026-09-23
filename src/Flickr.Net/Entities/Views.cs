using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;
[FlickrJsonPropertyName("stats")]
/// <summary>Represents total view counts across a user's content.</summary>
public record Views : FlickrEntityBase
{    [JsonPropertyName("total")]
    public TotalViews? Total { get; init; }
    [JsonPropertyName("photos")]
    public PhotoViews? Photos { get; init; }
    [JsonPropertyName("photostream")]
    public PhotostreamViews Photostream { get; init; }
    [JsonPropertyName("sets")]
    /// <summary>The photosets within this collection.</summary>
    public SetViews Sets { get; init; }
    [JsonPropertyName("collections")]
    public CollectionViews Collections { get; init; }
}
public record CollectionViews : ViewBase;
public record PhotoViews : ViewBase;
public record PhotostreamViews : ViewBase;
public record SetViews : ViewBase;
public record TotalViews : ViewBase;
public record ViewBase
{    [JsonPropertyName("views")]
    /// <summary>The number of views.</summary>
    public int Views { get; init; }
    /// <summary>Converts from a string value.</summary>
    public static implicit operator ViewBase(int value) => new() { Views = value };
    /// <summary>Converts from a string value.</summary>
    public static implicit operator int(ViewBase value) => value.Views;
}
