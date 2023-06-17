using Flickr.Net.Core.Internals.Attributes;
using Newtonsoft.Json;

namespace Flickr.Net.Core.NewEntities.Collections;

/// <summary>
/// </summary>
[FlickrJsonPropertyName("items")]
internal class Items
{
    /// <summary>
    /// </summary>
    [JsonProperty("item")]
    public List<Item> Item { get; set; }
}
