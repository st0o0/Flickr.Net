using Flickr.Net.Core.Bases;
using Newtonsoft.Json;

namespace Flickr.Net.Core;

public record Reply : FlickrEntityBase<Id>
{
    [JsonProperty("author")]
    public string Author { get; set; }

    [JsonProperty("authorname")]
    public string AuthorName { get; set; }

    [JsonProperty("is_pro")]
    public bool IsPro { get; set; }

    [JsonProperty("role")]
    public MemberType Role { get; set; }

    [JsonProperty("iconserver")]
    public string Iconserver { get; set; }

    [JsonProperty("iconfarm")]
    public string Iconfarm { get; set; }

    [JsonProperty("can_edit")]
    public bool CanEdit { get; set; }

    [JsonProperty("can_delete")]
    public bool CanDelete { get; set; }

    [JsonProperty("datecreate")]
    public DateTime CreateDate { get; set; }

    [JsonProperty("lastedit")]
    public DateTime LastEdit { get; set; }

    [JsonProperty("message")]
    public List<string> Messages { get; set; }
}