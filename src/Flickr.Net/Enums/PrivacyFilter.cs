using System.Runtime.Serialization;

namespace Flickr.Net.Enums;

/// <summary>
/// When searching for photos you can filter on the privacy of the photos.
/// </summary>
public enum PrivacyFilter
{
    /// <summary>
    /// Do not filter.
    /// </summary>
    [EnumMember(Value = "0")]
    None = 0,

    /// <summary>
    /// Show only public photos.
    /// </summary>
    [EnumMember(Value = "1")]
    PublicPhotos = 1,

    /// <summary>
    /// Show photos which are marked as private but viewable by friends.
    /// </summary>
    [EnumMember(Value = "2")]
    PrivateVisibleToFriends = 2,

    /// <summary>
    /// Show photos which are marked as private but viewable by family contacts.
    /// </summary>
    [EnumMember(Value = "3")]
    PrivateVisibleToFamily = 3,

    /// <summary>
    /// Show photos which are marked as private but viewable by friends and family contacts.
    /// </summary>
    [EnumMember(Value = "4")]
    PrivateVisibleToFriendsFamily = 4,

    /// <summary>
    /// Show photos which are marked as completely private.
    /// </summary>
    [EnumMember(Value = "5")]
    CompletelyPrivate = 5
}