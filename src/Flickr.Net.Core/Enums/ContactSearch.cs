namespace Flickr.Net.Core.Enums;

/// <summary>
/// Allows you to perform a search on a users contacts.
/// </summary>
[Serializable]
public enum ContactSearch
{
    /// <summary>
    /// Do not perform a contact search.
    /// </summary>
    None = 0,

    /// <summary>
    /// Perform a search on all a users contacts.
    /// </summary>
    AllContacts = 1,

    /// <summary>
    /// Perform a search on only a users friends and family contacts.
    /// </summary>
    FriendsAndFamilyOnly = 2
}