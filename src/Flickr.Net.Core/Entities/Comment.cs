using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

[FlickrJsonPropertyName("comment")]
public record Comment : FlickrEntityBase<Id>, IBuddyIcon
{
    [JsonProperty("author")]
    public string Author { get; set; }

    [JsonProperty("author_is_deleted")]
    public bool AuthorIsDeleted { get; set; }

    [JsonProperty("authorname")]
    public string Authorname { get; set; }

    [JsonProperty("iconserver")]
    public string IconServer { get; set; }

    [JsonProperty("iconfarm")]
    public int IconFarm { get; set; }

    [JsonProperty("datecreate")]
    public DateTime CreateDate { get; set; }

    [JsonProperty("permalink")]
    public string Permalink { get; set; }

    [JsonProperty("path_alias")]
    public string PathAlias { get; set; }

    [JsonProperty("realname")]
    public string Realname { get; set; }

    [JsonProperty("_content")]
    public string Content { get; set; }
}
