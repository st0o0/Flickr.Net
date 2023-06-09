﻿using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("method")]
public record Method : FlickrEntityBase
{
    [JsonProperty("_content")]
    public string Content { get; set; }

    public static implicit operator string(Method method) => method.Content;
}
