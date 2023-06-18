using Flickr.Net.Core.Internals.JsonConverters;
using Newtonsoft.Json;

namespace Flickr.Net.Core.NewEntities;

public class Contact
{
    [JsonProperty("nsid")]
    public string Id { get; set; }

    [JsonProperty("username")]
    public string UserName { get; set; }

    [JsonProperty("iconserver")]
    public string IconServer { get; set; }

    [JsonProperty("realname")]
    public string RealName { get; set; }

    [JsonProperty("friend")]
    [JsonConverter(typeof(BoolConverter))]
    public bool Friend { get; set; }

    [JsonProperty("family")]
    [JsonConverter(typeof(BoolConverter))]
    public bool Family { get; set; }

    [JsonProperty("ignored")]
    [JsonConverter(typeof(BoolConverter))]
    public bool Ignored { get; set; }
}
