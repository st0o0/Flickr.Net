﻿using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

/// <summary>
/// </summary>
public record Item : FlickrEntityBase<Id>, ISmallUrl, ISquareUrl, IBuddyIcon
{
    /// <summary>
    /// </summary>
    [JsonProperty("title")]
    public string Title { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("activity")]
    public Activity Activity { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("type")]
    public ItemType Type { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("primary")]
    public string Primary { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("secret")]
    public string Secret { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("server")]
    public string Server { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("farm")]
    public int Farm { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("comments")]
    public int Comments { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("views")]
    public int Views { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("photos")]
    public int Photos { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("more")]
    public int More { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("notes")]
    public int Notes { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("faves")]
    public int Favorites { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("owner")]
    public string OwnerId { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("realname")]
    public string RealName { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("ownername")]
    public string OwnerName { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("iconserver")]
    public string OwnerServer { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("iconfarm")]
    public string OwnerFarm { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("notesnew")]
    public string NewNotes { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("notesold")]
    public string OldNotes { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("commentsnew")]
    public string NewComments { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("commentsold")]
    public string OldComments { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("media")]
    public MediaType Media { get; set; }
}
