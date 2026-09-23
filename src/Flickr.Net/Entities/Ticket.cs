using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Enums;

namespace Flickr.Net;
/// <summary>Represents an asynchronous upload ticket.</summary>
public record Ticket : FlickrEntityBase<Id>
{    [JsonPropertyName("complete")]
    /// <summary>The completion status.</summary>
    public StatusType Complete { get; init; }
    [JsonPropertyName("photoid")]
    /// <summary>The photo identifier.</summary>
    public string? PhotoId { get; init; }
    [JsonPropertyName("invalid")]
    /// <summary>Whether the ticket is invalid.</summary>
    public bool Invalid { get; init; }
}
