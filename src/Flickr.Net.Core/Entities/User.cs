﻿using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

/// <summary>
/// Contains details of a user
/// </summary>
[FlickrJsonPropertyName("user")]
public record User : FlickrEntityBase<NsId>
{
    /// <summary>
    /// The username of the found user.
    /// </summary>
    [JsonPropertyName("username")]
    public string UserName { get; set; }

    /// <summary>
    /// The full name of the user. Only returned by <see
    /// cref="IFlickrOAuth.GetAccessTokenAsync(OAuthRequestToken, string, CancellationToken)"/>.
    /// </summary>
    [JsonPropertyName("fullname")]
    public string FullName { get; set; }
}