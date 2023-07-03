namespace Flickr.Net.Core.Enums;

/// <summary>
/// The default privacy level for geographic information attached to the user's photos.
/// </summary>
public enum GeoPermissionType
{
    /// <summary>
    /// No default set.
    /// </summary>
    [EnumMember(Value = "0")]
    None = 0,

    /// <summary>
    /// Anyone can see the geographic information.
    /// </summary>
    [EnumMember(Value = "1")]
    Public = 1,

    /// <summary>
    /// Only contacts can see the geographic information.
    /// </summary>
    [EnumMember(Value = "2")]
    ContactsOnly = 2,

    /// <summary>
    /// Only Friends and Family can see the geographic information.
    /// </summary>
    [EnumMember(Value = "3")]
    FriendsAndFamilyOnly = 3,

    /// <summary>
    /// Only Friends can see the geographic information.
    /// </summary>
    [EnumMember(Value = "4")]
    FriendsOnly = 4,

    /// <summary>
    /// Only Family can see the geographic information.
    /// </summary>
    [EnumMember(Value = "5")]
    FamilyOnly = 5,

    /// <summary>
    /// Only you can see the geographic information.
    /// </summary>
    [EnumMember(Value = "6")]
    Private = 6
}