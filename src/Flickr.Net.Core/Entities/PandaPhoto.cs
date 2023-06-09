﻿using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("photo")]
public record PandaPhoto : DeluxePhotoBase
{
    [JsonProperty("ownername")]
    public string OwnerName { get; set; }
}