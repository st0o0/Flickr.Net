﻿using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("stats")]
public record Views : FlickrEntityBase
{
    [JsonProperty("total")]
    public TotalViews Total { get; set; }

    [JsonProperty("photos")]
    public PhotoViews Photos { get; set; }

    [JsonProperty("photostream")]
    public PhotostreamViews Photostream { get; set; }

    [JsonProperty("sets")]
    public SetViews Sets { get; set; }

    [JsonProperty("collections")]
    public CollectionViews Collections { get; set; }
}

public record CollectionViews : ViewBase
{ }

public record PhotoViews : ViewBase
{ }

public record PhotostreamViews : ViewBase
{ }

public record SetViews : ViewBase
{ }

public record TotalViews : ViewBase
{ }

public record ViewBase
{
    [JsonProperty("views")]
    public int Views { get; set; }

    public static implicit operator ViewBase(int value) => new() { Views = value };

    public static implicit operator int(ViewBase value) => value.Views;
}
