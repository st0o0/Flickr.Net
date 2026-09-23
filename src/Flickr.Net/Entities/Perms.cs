using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Enums;

namespace Flickr.Net;
/// <summary>Represents the OAuth permission level granted to an application.</summary>
public record Perms : FlickrEntityBase<Id>
{    [JsonPropertyName("ispublic")]
    /// <summary>Whether the content is publicly visible.</summary>
    public bool IsPublic { get; init; }
    [JsonPropertyName("isfriend")]
    /// <summary>Whether the content is visible to friends.</summary>
    public bool IsFriend { get; init; }
    [JsonPropertyName("isfamily")]
    /// <summary>Whether the content is visible to family.</summary>
    public bool IsFamily { get; init; }
    [JsonPropertyName("permcomment")]
    /// <summary>The permission level for commenting.</summary>
    public PermissionComment PermComment { get; init; }
    [JsonPropertyName("permaddmeta")]
    /// <summary>The permission level for adding metadata.</summary>
    public PermissionAddMeta PermAddMeta { get; init; }
    [JsonPropertyName("permprint")]
    /// <summary>The permission level for printing.</summary>
    public int PermPrint { get; init; }
}
