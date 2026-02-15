using System.Runtime.Serialization;

namespace Flickr.Net.Enums;

/// <summary>
/// The various pricay settings for a group.
/// </summary>
public enum PoolPrivacy
{
    /// <summary>
    /// No privacy setting specified.
    /// </summary>
    [EnumMember(Value = "0")]
    None = 0,

    /// <summary>
    /// The group is a private group. You cannot view pictures or posts until you are a member. The
    /// group is also invite only.
    /// </summary>
    [EnumMember(Value = "1")]
    Private = 1,

    /// <summary>
    /// A public group where you can see posts and photos in the group. The group is however invite only.
    /// </summary>
    [EnumMember(Value = "2")]
    InviteOnlyPublic = 2,

    /// <summary>
    /// A public group.
    /// </summary>
    [EnumMember(Value = "3")]
    OpenPublic = 3
}