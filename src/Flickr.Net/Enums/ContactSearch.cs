namespace Flickr.Net.Enums;

/// <summary>
/// Allows you to perform a search on a users contacts.
/// </summary>
public enum ContactSearch
{
    /// <summary>
    /// Do not perform a contact search.
    /// </summary>
    [EnumMember(Value = "")]
    None = 0,

    /// <summary>
    /// Perform a search on all a users contacts.
    /// </summary>
    [EnumMember(Value = "all")]
    AllContacts = 1,

    /// <summary>
    /// Perform a search on only a users friends and family contacts.
    /// </summary>
    [EnumMember(Value = "ff")]
    FriendsAndFamilyOnly = 2
}