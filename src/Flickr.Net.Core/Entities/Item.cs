using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

/// <summary>
/// </summary>
public record Item : FlickrEntityBase<Id>, ISmallUrl, ISquareUrl, IBuddyIcon
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("title")]
    public string Title { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("activity")]
    public Activity Activity { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("type")]
    public ItemType Type { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("primary")]
    public string Primary { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("secret")]
    public string Secret { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("server")]
    public string Server { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("farm")]
    public int Farm { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("comments")]
    public int Comments { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("views")]
    public int Views { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("photos")]
    public int Photos { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("more")]
    public int More { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("notes")]
    public int Notes { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("faves")]
    public int Favorites { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("owner")]
    public string OwnerId { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("realname")]
    public string RealName { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("ownername")]
    public string OwnerName { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("iconserver")]
    public string OwnerServer { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("iconfarm")]
    public string OwnerFarm { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("notesnew")]
    public string NewNotes { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("notesold")]
    public string OldNotes { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("commentsnew")]
    public string NewComments { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("commentsold")]
    public string OldComments { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("media")]
    public MediaType Media { get; set; }
}
