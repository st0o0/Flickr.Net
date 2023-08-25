using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("comment")]
public record Comment : FlickrEntityBase<Id>, IBuddyIcon
{
    [JsonPropertyName("author")]
    public string Author { get; set; }

    [JsonPropertyName("author_is_deleted")]
    public bool AuthorIsDeleted { get; set; }

    [JsonPropertyName("authorname")]
    public string Authorname { get; set; }

    [JsonPropertyName("iconserver")]
    public string IconServer { get; set; }

    [JsonPropertyName("iconfarm")]
    public int IconFarm { get; set; }

    [JsonPropertyName("datecreate")]
    public DateTime CreateDate { get; set; }

    [JsonPropertyName("permalink")]
    public string Permalink { get; set; }

    [JsonPropertyName("path_alias")]
    public string PathAlias { get; set; }

    [JsonPropertyName("realname")]
    public string Realname { get; set; }

    [JsonPropertyName("_content")]
    public string Content { get; set; }
}
