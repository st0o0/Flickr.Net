using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Enums;

namespace Flickr.Net;
/// <summary>Represents a reply in a group discussion topic.</summary>
public record Reply : FlickrEntityBase<Id>, IBuddyIcon
{    [JsonPropertyName("author")]
    /// <summary>The NSID of the author.</summary>
    public string? Author { get; init; }
    [JsonPropertyName("authorname")]
    /// <summary>The display name of the author.</summary>
    public string? AuthorName { get; init; }
    [JsonPropertyName("is_pro")]
    /// <summary>Whether the user has a Pro account.</summary>
    public bool IsPro { get; init; }
    [JsonPropertyName("role")]
    /// <summary>The member role in the group.</summary>
    public MemberType Role { get; init; }
    [JsonPropertyName("iconserver")]
    /// <summary>The icon server for buddy icon URL construction.</summary>
    public string? IconServer { get; init; }
    [JsonPropertyName("iconfarm")]
    /// <summary>The icon farm for buddy icon URL construction.</summary>
    public int IconFarm { get; init; }
    [JsonPropertyName("can_edit")]
    /// <summary>Whether the current user can edit this.</summary>
    public bool CanEdit { get; init; }
    [JsonPropertyName("can_delete")]
    /// <summary>Whether the current user can delete this.</summary>
    public bool CanDelete { get; init; }
    [JsonPropertyName("datecreate")]
    /// <summary>The creation date.</summary>
    public DateTime CreateDate { get; init; }
    [JsonPropertyName("lastedit")]
    public DateTime LastEdit { get; init; }
    [JsonPropertyName("message")]
    public List<string> Messages { get; init; } = [];
}
