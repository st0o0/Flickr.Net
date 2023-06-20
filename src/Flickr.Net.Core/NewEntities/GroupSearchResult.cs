using Flickr.Net.Core.Internals.Attributes;
using Flickr.Net.Core.Internals.JsonConverters;
using Newtonsoft.Json;

namespace Flickr.Net.Core.NewEntities;

[FlickrJsonPropertyName("group")]
public class GroupSearchResult
{
    [JsonProperty("nsid")]
    public string Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("eighteenplus")]
    [JsonConverter(typeof(BoolConverter))]
    public bool EighteenPlus { get; set; }
}