namespace FlickrNet.Core.Enums;

/// <summary>
/// When searching for photos you can filter on the privacy of the photos.
/// </summary>
[Serializable]
public enum PrivacyFilter
{
    /// <summary>
    /// Do not filter.
    /// </summary>
    None = 0,

    /// <summary>
    /// Show only public photos.
    /// </summary>
    PublicPhotos = 1,

    /// <summary>
    /// Show photos which are marked as private but viewable by friends.
    /// </summary>
    PrivateVisibleToFriends = 2,

    /// <summary>
    /// Show photos which are marked as private but viewable by family contacts.
    /// </summary>
    PrivateVisibleToFamily = 3,

    /// <summary>
    /// Show photos which are marked as private but viewable by friends and family contacts.
    /// </summary>
    PrivateVisibleToFriendsFamily = 4,

    /// <summary>
    /// Show photos which are marked as completely private.
    /// </summary>
    CompletelyPrivate = 5
}