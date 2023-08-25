using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Reply : FlickrEntityBase<Id>, IBuddyIcon
{
    [JsonPropertyName("author")]
    public string Author { get; set; }

    [JsonPropertyName("authorname")]
    public string AuthorName { get; set; }

    [JsonPropertyName("is_pro")]
    public bool IsPro { get; set; }

    [JsonPropertyName("role")]
    public MemberType Role { get; set; }

    [JsonPropertyName("iconserver")]
    public string IconServer { get; set; }

    [JsonPropertyName("iconfarm")]
    public int IconFarm { get; set; }

    [JsonPropertyName("can_edit")]
    public bool CanEdit { get; set; }

    [JsonPropertyName("can_delete")]
    public bool CanDelete { get; set; }

    [JsonPropertyName("datecreate")]
    public DateTime CreateDate { get; set; }

    [JsonPropertyName("lastedit")]
    public DateTime LastEdit { get; set; }

    [JsonPropertyName("message")]
    public List<string> Messages { get; set; }
}