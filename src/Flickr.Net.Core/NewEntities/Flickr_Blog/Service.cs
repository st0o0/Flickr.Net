using Newtonsoft.Json;

namespace Flickr.Net.Core.NewEntities.Flickr_Blog;

/// <summary>
/// </summary>
public class Service
{
    /// <summary>
    /// </summary>
    [JsonProperty("id")]
    public string Id { get; set; }

    /// <summary>
    /// </summary>
    [JsonProperty("_content")]
    public string Content { get; set; }
}