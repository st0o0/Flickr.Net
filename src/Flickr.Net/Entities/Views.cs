using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("stats")]
public record Views : FlickrEntityBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("total")]
    public TotalViews Total { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("photos")]
    public PhotoViews Photos { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("photostream")]
    public PhotostreamViews Photostream { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("sets")]
    public SetViews Sets { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("collections")]
    public CollectionViews Collections { get; set; }
}

/// <summary>
/// </summary>
public record CollectionViews : ViewBase;

/// <summary>
/// </summary>
public record PhotoViews : ViewBase;

/// <summary>
/// </summary>
public record PhotostreamViews : ViewBase;

/// <summary>
/// </summary>
public record SetViews : ViewBase;

/// <summary>
/// </summary>
public record TotalViews : ViewBase;

/// <summary>
/// </summary>
public record ViewBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("views")]
    public int Views { get; set; }

    /// <summary>
    /// </summary>
    public static implicit operator ViewBase(int value) => new() { Views = value };

    /// <summary>
    /// </summary>
    public static implicit operator int(ViewBase value) => value.Views;
}
