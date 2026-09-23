using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Enums;

namespace Flickr.Net;
/// <summary>Represents an item (photo or photoset) in a user's recent activity feed.</summary>
public record Item : FlickrEntityBase<Id>, ISmallUrl, ISquareUrl, IBuddyIcon
{    [JsonPropertyName("title")]
    /// <summary>The title.</summary>
    public string? Title { get; init; }
    [JsonPropertyName("activity")]
    public Activity? Activity { get; init; }
    [JsonPropertyName("type")]
    /// <summary>The type.</summary>
    public ItemType Type { get; init; }
    [JsonPropertyName("primary")]
    /// <summary>The primary photo identifier.</summary>
    public string? Primary { get; init; }
    [JsonPropertyName("secret")]
    /// <summary>The photo secret used in URL construction.</summary>
    public string? Secret { get; init; }
    [JsonPropertyName("server")]
    /// <summary>The server identifier used in URL construction.</summary>
    public string? Server { get; init; }
    [JsonPropertyName("farm")]
    /// <summary>The farm identifier used in URL construction.</summary>
    public int Farm { get; init; }
    [JsonPropertyName("comments")]
    /// <summary>The comments.</summary>
    public int Comments { get; init; }
    [JsonPropertyName("views")]
    /// <summary>The number of views.</summary>
    public int Views { get; init; }
    [JsonPropertyName("photos")]
    /// <summary>The number of photos.</summary>
    public int Photos { get; init; }
    [JsonPropertyName("more")]
    /// <summary>The count of additional items not included in this response.</summary>
    public int More { get; init; }
    [JsonPropertyName("notes")]
    /// <summary>The number of notes.</summary>
    public int Notes { get; init; }
    [JsonPropertyName("faves")]
    /// <summary>The number of favorites.</summary>
    public int Favorites { get; init; }
    [JsonPropertyName("owner")]
    /// <summary>The NSID of the owner.</summary>
    public string? OwnerId { get; init; }
    [JsonPropertyName("realname")]
    /// <summary>The real name.</summary>
    public string? RealName { get; init; }
    [JsonPropertyName("ownername")]
    /// <summary>The display name of the owner.</summary>
    public string? OwnerName { get; init; }
    [JsonPropertyName("iconserver")]
    /// <summary>The icon server of the owner.</summary>
    public string? OwnerServer { get; init; }
    [JsonPropertyName("iconfarm")]
    /// <summary>The icon farm of the owner.</summary>
    public string? OwnerFarm { get; init; }
    [JsonPropertyName("notesnew")]
    /// <summary>The count of new notes since last check.</summary>
    public string? NewNotes { get; init; }
    [JsonPropertyName("notesold")]
    /// <summary>The count of previously seen notes.</summary>
    public string? OldNotes { get; init; }
    [JsonPropertyName("commentsnew")]
    /// <summary>The count of new comments since last check.</summary>
    public string? NewComments { get; init; }
    [JsonPropertyName("commentsold")]
    /// <summary>The count of previously seen comments.</summary>
    public string? OldComments { get; init; }
    [JsonPropertyName("media")]
    /// <summary>The media type (photo or video).</summary>
    public MediaType Media { get; init; }
}
