using System.Runtime.Serialization;

namespace Flickr.Net.Enums;

/// <summary>
/// An enumeration defining who can add comments.
/// </summary>
public enum PermissionComment
{
    /// <summary>
    /// Nobody.
    /// </summary>
    [EnumMember(Value = "0")]
    Nobody = 0,

    /// <summary>
    /// Friends and family only.
    /// </summary>
    [EnumMember(Value = "1")]
    FriendsAndFamily = 1,

    /// <summary>
    /// Contacts only.
    /// </summary>
    [EnumMember(Value = "2")]
    ContactsOnly = 2,

    /// <summary>
    /// All Flickr users.
    /// </summary>
    [EnumMember(Value = "3")]
    Everybody = 3
}