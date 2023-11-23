using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

/// <summary>
/// </summary>
public record Ticket : FlickrEntityBase<Id>
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("complete")]
    public StatusType Complete { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("photoid")]
    public string PhotoId { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("invalid")]
    public bool Invalid { get; set; }
}
