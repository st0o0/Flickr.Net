using Flickr.Net.Core.Internals.Attributes;
using Flickr.Net.Core.Internals.JsonConverters;
using Flickr.Net.Core.NewEntities.Collections;
using Newtonsoft.Json;

namespace Flickr.Net.Core.NewEntities;

public class Institution
{
    [JsonProperty("nsid")]
    public string Id { get; set; }

    [JsonProperty("date_launch")]
    [JsonConverter(typeof(FlickrTimestampToDateTimeConverter))]
    public DateTime LaunchDate { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("urls")]
    public Urls Urls { get; set; }
}
