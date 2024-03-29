﻿using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("photo")]
public record PhotoExif : PhotoBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("farm")]
    public int Farm { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("camera")]
    public string Camera { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("exif")]
    public List<Exif> Exifs { get; set; }
}
