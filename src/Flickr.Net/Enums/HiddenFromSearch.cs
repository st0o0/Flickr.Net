﻿namespace Flickr.Net.Enums;

/// <summary>
/// Determines weither the photo is visible in public searches. The default is 1, Visible.
/// </summary>
public enum HiddenFromSearch
{
    /// <summary>
    /// No preference specified, defaults to your preferences on Flickr.
    /// </summary>
    [EnumMember(Value = "0")]
    None = 0,

    /// <summary>
    /// Photo is visible to public searches.
    /// </summary>
    [EnumMember(Value = "1")]
    Visible = 1,

    /// <summary>
    /// photo is hidden from public searches.
    /// </summary>
    [EnumMember(Value = "2")]
    Hidden = 2
}