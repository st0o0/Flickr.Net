using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("topic")]
public record Topic : FlickrEntityBase, IBuddyIcon
{
    [JsonPropertyName("topic_id")]
    public string TopicId { get; set; }

    [JsonPropertyName("subject")]
    public string Subject { get; set; }

    [JsonPropertyName("group_id")]
    public string GroupId { get; set; }

    [JsonPropertyName("iconserver")]
    public string Iconserver { get; set; }

    [JsonPropertyName("iconfarm")]
    public string Iconfarm { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("author")]
    public string Author { get; set; }

    [JsonPropertyName("authorname")]
    public string AuthorName { get; set; }

    [JsonPropertyName("role")]
    public MemberType Role { get; set; }

    [JsonPropertyName("author_iconserver")]
    public string AuthorIconServer { get; set; }

    [JsonPropertyName("author_iconfarm")]
    public string AuthorIconFarm { get; set; }

    [JsonPropertyName("can_edit")]
    public bool CanEdit { get; set; }

    [JsonPropertyName("can_delete")]
    public bool CanDelete { get; set; }

    [JsonPropertyName("can_reply")]
    public bool CanReply { get; set; }

    [JsonPropertyName("is_sticky")]
    public bool IsSticky { get; set; }

    [JsonPropertyName("is_locked")]
    public bool IsLocked { get; set; }

    [JsonPropertyName("datecreate")]
    public DateTime CreateDate { get; set; }

    [JsonPropertyName("datelastpost")]
    public DateTime LastPostDate { get; set; }

    [JsonPropertyName("total")]
    public int Total { get; set; }

    [JsonPropertyName("page")]
    public int Page { get; set; }

    [JsonPropertyName("per_page")]
    public int PerPage { get; set; }

    [JsonPropertyName("pages")]
    public int Pages { get; set; }

    [JsonPropertyName("message")]
    public string Message { get; set; }
}