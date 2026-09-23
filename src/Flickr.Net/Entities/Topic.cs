using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Enums;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;
[FlickrJsonPropertyName("topic")]
/// <summary>Represents a discussion topic in a group.</summary>
public record Topic : FlickrEntityBase, IBuddyIcon
{    [JsonPropertyName("topic_id")]
    public string? TopicId { get; init; }
    [JsonPropertyName("subject")]
    /// <summary>The subject line.</summary>
    public string? Subject { get; init; }
    [JsonPropertyName("group_id")]
    /// <summary>The group NSID.</summary>
    public string? GroupId { get; init; }
    [JsonPropertyName("iconserver")]
    /// <summary>The icon server for buddy icon URL construction.</summary>
    public string? IconServer { get; init; }
    [JsonPropertyName("iconfarm")]
    /// <summary>The icon farm for buddy icon URL construction.</summary>
    public string? IconFarm { get; init; }
    [JsonPropertyName("name")]
    /// <summary>The display name.</summary>
    public string? Name { get; init; }
    [JsonPropertyName("author")]
    /// <summary>The NSID of the author.</summary>
    public string? Author { get; init; }
    [JsonPropertyName("authorname")]
    /// <summary>The display name of the author.</summary>
    public string? AuthorName { get; init; }
    [JsonPropertyName("role")]
    /// <summary>The member role in the group.</summary>
    public MemberType Role { get; init; }
    [JsonPropertyName("author_iconserver")]
    /// <summary>The icon server for the author.</summary>
    public string? AuthorIconServer { get; init; }
    [JsonPropertyName("author_iconfarm")]
    /// <summary>The icon farm for the author.</summary>
    public string? AuthorIconFarm { get; init; }
    [JsonPropertyName("can_edit")]
    /// <summary>Whether the current user can edit this.</summary>
    public bool CanEdit { get; init; }
    [JsonPropertyName("can_delete")]
    /// <summary>Whether the current user can delete this.</summary>
    public bool CanDelete { get; init; }
    [JsonPropertyName("can_reply")]
    /// <summary>Whether the current user can reply.</summary>
    public bool CanReply { get; init; }
    [JsonPropertyName("is_sticky")]
    /// <summary>Whether this topic is pinned/sticky.</summary>
    public bool IsSticky { get; init; }
    [JsonPropertyName("is_locked")]
    /// <summary>Whether this topic is locked.</summary>
    public bool IsLocked { get; init; }
    [JsonPropertyName("datecreate")]
    /// <summary>The creation date.</summary>
    public DateTime CreateDate { get; init; }
    [JsonPropertyName("datelastpost")]
    public DateTime LastPostDate { get; init; }
    [JsonPropertyName("total")]
    /// <summary>The total count.</summary>
    public int Total { get; init; }
    [JsonPropertyName("page")]
    public int Page { get; init; }
    [JsonPropertyName("per_page")]
    public int PerPage { get; init; }
    [JsonPropertyName("pages")]
    public int Pages { get; init; }
    [JsonPropertyName("message")]
    /// <summary>The error message.</summary>
    public string? Message { get; init; }
}
