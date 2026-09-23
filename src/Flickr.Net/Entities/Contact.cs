using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;
/// <summary>Represents a contact (friend/family) of a Flickr user.</summary>
public record Contact : FlickrEntityBase<NsId>, IBuddyIcon
{    [JsonPropertyName("username")]
    /// <summary>The username.</summary>
    public string? UserName { get; init; }
    [JsonPropertyName("iconserver")]
    /// <summary>The icon server for buddy icon URL construction.</summary>
    public string? IconServer { get; init; }
    [JsonPropertyName("iconfarm")]
    /// <summary>The icon farm for buddy icon URL construction.</summary>
    public int IconFarm { get; init; }
    [JsonPropertyName("realname")]
    /// <summary>The real name.</summary>
    public string? RealName { get; init; }
    [JsonPropertyName("location")]
    /// <summary>The user's location.</summary>
    public string? Location { get; init; }
    [JsonPropertyName("path_alias")]
    /// <summary>The URL-friendly path alias.</summary>
    public string? PathAlias { get; init; }
    [JsonPropertyName("photos_uploaded")]
    /// <summary>The number of photos uploaded by this contact.</summary>
    public int UploadedPhotos { get; init; }
    [JsonPropertyName("friend")]
    /// <summary>Whether this contact is marked as a friend.</summary>
    public bool Friend { get; init; }
    [JsonPropertyName("family")]
    /// <summary>Whether this contact is marked as family.</summary>
    public bool Family { get; init; }
    [JsonPropertyName("ignored")]
    /// <summary>Whether this contact is ignored.</summary>
    public bool Ignored { get; init; }
    [JsonPropertyName("ispro")]
    /// <summary>Whether the user has a Pro account.</summary>
    public bool IsPro { get; init; }

    /// <summary>Whether this contact has added the authenticated user as a contact.</summary>
    [JsonPropertyName("rev_contact")]
    public bool? RevContact { get; init; }

    /// <summary>Whether this contact has marked the authenticated user as a friend.</summary>
    [JsonPropertyName("rev_friend")]
    public bool? RevFriend { get; init; }

    /// <summary>Whether this contact has marked the authenticated user as family.</summary>
    [JsonPropertyName("rev_family")]
    public bool? RevFamily { get; init; }
}
