using Flickr.Net.Core.Internals.Attributes;
using Flickr.Net.Core.Internals.JsonConverters;
using Newtonsoft.Json;

namespace Flickr.Net.Core.NewEntities;

[FlickrJsonPropertyName("topic")]
public class Topic
{
    [JsonProperty("topic_id")]
    public string Id { get; set; }

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
    [JsonConverter(typeof(BoolConverter))]
    public bool CanEdit { get; set; }

    [JsonProperty("can_delete")]
    [JsonConverter(typeof(BoolConverter))]
    public bool CanDelete { get; set; }

    [JsonProperty("can_reply")]
    [JsonConverter(typeof(BoolConverter))]
    public bool CanReply { get; set; }

    [JsonProperty("is_sticky")]
    [JsonConverter(typeof(BoolConverter))]
    public bool IsSticky { get; set; }

    [JsonProperty("is_locked")]
    [JsonConverter(typeof(BoolConverter))]
    public bool IsLocked { get; set; }

    [JsonProperty("datecreate")]
    [JsonConverter(typeof(FlickrTimestampToDateTimeConverter))]
    public DateTime CreateDate { get; set; }

    [JsonProperty("datelastpost")]
    [JsonConverter(typeof(FlickrTimestampToDateTimeConverter))]
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