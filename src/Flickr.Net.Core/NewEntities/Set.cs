using Newtonsoft.Json;

namespace Flickr.Net.Core.NewEntities;

public class Set
{
    [JsonProperty("id")]
    public string Id { get; set; }

    [JsonProperty("title")]
    public string Title { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; }
}