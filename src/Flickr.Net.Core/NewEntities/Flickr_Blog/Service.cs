using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

/// <summary>
/// </summary>
public record Service : FlickrEntityBase<Id>
{
    /// <summary>
    /// </summary>
    [JsonProperty("_content")]
    public string Content { get; set; }
}