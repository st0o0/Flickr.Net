﻿namespace Flickr.Net.Enums;

/// <summary>
/// An enumeration defining who can add meta data (tags and notes).
/// </summary>
public enum PermissionAddMeta
{
    /// <summary>
    /// The owner of the photo only.
    /// </summary>
    [EnumMember(Value = "0")]
    Owner = 0,

    /// <summary>
    /// Friends and family only.
    /// </summary>
    [EnumMember(Value = "1")]
    FriendsAndFamily = 1,

    /// <summary>
    /// All contacts.
    /// </summary>
    [EnumMember(Value = "2")]
    Contacts = 2,

    /// <summary>
    /// All Flickr users.
    /// </summary>
    [EnumMember(Value = "3")]
    Everybody = 3
}