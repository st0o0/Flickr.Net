using System.Xml.Serialization;

namespace FlickrNet.Core.Enums;

/// <summary>
/// An enumeration defining who can add meta data (tags and notes).
/// </summary>
public enum PermissionAddMeta
{
    /// <summary>
    /// The owner of the photo only.
    /// </summary>
    [XmlEnum("0")]
    Owner = 0,

    /// <summary>
    /// Friends and family only.
    /// </summary>
    [XmlEnum("1")]
    FriendsAndFamily = 1,

    /// <summary>
    /// All contacts.
    /// </summary>
    [XmlEnum("2")]
    Contacts = 2,

    /// <summary>
    /// All Flickr users.
    /// </summary>
    [XmlEnum("3")]
    Everybody = 3
}