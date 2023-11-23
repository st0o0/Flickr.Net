using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;
using Flickr.Net.Core.Internals.Attributes;

namespace Flickr.Net.Core;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("comment")]
public record Comment : FlickrEntityBase<Id>, IBuddyIcon
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("author")]
    public string Author { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("author_is_deleted")]
    public bool AuthorIsDeleted { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("authorname")]
    public string Authorname { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("iconserver")]
    public string IconServer { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("iconfarm")]
    public int IconFarm { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("datecreate")]
    public DateTime CreateDate { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("permalink")]
    public string Permalink { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("path_alias")]
    public string PathAlias { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("realname")]
    public string Realname { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("_content")]
    public string Content { get; set; }
}
