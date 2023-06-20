using Flickr.Net.Core.Internals.JsonConverters;
using Newtonsoft.Json;

namespace Flickr.Net.Core.NewEntities;

public class Reply
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("author")]
    public string Author { get; set; }

    [JsonProperty("authorname")]
    public string AuthorName { get; set; }

    [JsonProperty("is_pro")]
    [JsonConverter(typeof(BoolConverter))]
    public bool IsPro { get; set; }

    [JsonProperty("role")]
    public MemberType Role { get; set; }

    [JsonProperty("iconserver")]
    public string Iconserver { get; set; }

    [JsonProperty("iconfarm")]
    public string Iconfarm { get; set; }

    [JsonProperty("can_edit")]
    [JsonConverter(typeof(BoolConverter))]
    public bool CanEdit { get; set; }

    [JsonProperty("can_delete")]
    [JsonConverter(typeof(BoolConverter))]
    public bool CanDelete { get; set; }

    [JsonProperty("datecreate")]
    [JsonConverter(typeof(TimestampToDateTimeConverter))]
    public DateTime CreateDate { get; set; }

    [JsonProperty("lastedit")]
    [JsonConverter(typeof(TimestampToDateTimeConverter))]
    public DateTime LastEdit { get; set; }

    [JsonProperty("message")]
    public List<string> Messages { get; set; }
}