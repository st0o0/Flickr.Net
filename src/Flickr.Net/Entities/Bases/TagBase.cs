﻿using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;

/// <inheritdoc/>
public record TagBase : FlickrEntityBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("_content")]
    public string Content { get; set; }
}
