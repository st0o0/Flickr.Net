using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("topic")]
public record Topic : FlickrEntityBase, IBuddyIcon
{
    [JsonProperty("topic_id")]
    public string TopicId { get; set; }

    [JsonProperty("subject")]
    public string Subject { get; set; }

    [JsonProperty("group_id")]
    public string GroupId { get; set; }

    [JsonProperty("iconserver")]
    public string Iconserver { get; set; }

    [JsonProperty("iconfarm")]
    public string Iconfarm { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("author")]
    public string Author { get; set; }

    [JsonProperty("authorname")]
    public string AuthorName { get; set; }

    [JsonProperty("role")]
    public MemberType Role { get; set; }

    [JsonProperty("author_iconserver")]
    public string AuthorIconServer { get; set; }

    [JsonProperty("author_iconfarm")]
    public string AuthorIconFarm { get; set; }

    [JsonProperty("can_edit")]
    public bool CanEdit { get; set; }

    [JsonProperty("can_delete")]
    public bool CanDelete { get; set; }

    [JsonProperty("can_reply")]
    public bool CanReply { get; set; }

    [JsonProperty("is_sticky")]
    public bool IsSticky { get; set; }

    [JsonProperty("is_locked")]
    public bool IsLocked { get; set; }

    [JsonProperty("datecreate")]
    public DateTime CreateDate { get; set; }

    [JsonProperty("datelastpost")]
    public DateTime LastPostDate { get; set; }

    [JsonProperty("total")]
    public int Total { get; set; }

    [JsonProperty("page")]
    public int Page { get; set; }

    [JsonProperty("per_page")]
    public int PerPage { get; set; }

    [JsonProperty("pages")]
    public int Pages { get; set; }

    [JsonProperty("message")]
    public string Message { get; set; }
}