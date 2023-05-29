using System.Xml.Serialization;

namespace FlickrNet.Core.Enums;

/// <summary>
/// An enumeration defining who can add comments.
/// </summary>
[Serializable]
public enum PermissionComment
{
    /// <summary>
    /// Nobody.
    /// </summary>
    [XmlEnum("0")]
    Nobody = 0,

    /// <summary>
    /// Friends and family only.
    /// </summary>
    [XmlEnum("1")]
    FriendsAndFamily = 1,

    /// <summary>
    /// Contacts only.
    /// </summary>
    [XmlEnum("2")]
    ContactsOnly = 2,

    /// <summary>
    /// All Flickr users.
    /// </summary>
    [XmlEnum("3")]
    Everybody = 3
}