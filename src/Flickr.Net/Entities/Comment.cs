using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

[FlickrJsonPropertyName("comment")]
/// <summary>Represents a comment on a photo.</summary>
public record Comment : FlickrEntityBase<Id>, IBuddyIcon
{
    [JsonPropertyName("author")]
    /// <summary>The NSID of the author.</summary>
    public string? Author { get; init; }
    [JsonPropertyName("author_is_deleted")]
    /// <summary>Whether the author's account has been deleted.</summary>
    public bool AuthorIsDeleted { get; init; }
    [JsonPropertyName("authorname")]
    /// <summary>The display name of the author.</summary>
    public string? Authorname { get; init; }
    [JsonPropertyName("iconserver")]
    /// <summary>The icon server for buddy icon URL construction.</summary>
    public string? IconServer { get; init; }
    [JsonPropertyName("iconfarm")]
    /// <summary>The icon farm for buddy icon URL construction.</summary>
    public int IconFarm { get; init; }
    [JsonPropertyName("datecreate")]
    /// <summary>The creation date.</summary>
    public DateTime CreateDate { get; init; }
    [JsonPropertyName("permalink")]
    /// <summary>The permanent URL link.</summary>
    public string? Permalink { get; init; }
    [JsonPropertyName("path_alias")]
    /// <summary>The URL-friendly path alias.</summary>
    public string? PathAlias { get; init; }
    [JsonPropertyName("realname")]
    /// <summary>The real name.</summary>
    public string? Realname { get; init; }
    [JsonPropertyName("_content")]
    /// <summary>The text content.</summary>
    public string? Content { get; init; }
}
