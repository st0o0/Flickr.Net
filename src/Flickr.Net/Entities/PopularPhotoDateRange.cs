using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Internals.Attributes;

namespace Flickr.Net;

/// <summary>Represents the date range for most popular photo statistics.</summary>
[FlickrJsonPropertyName("daterange")]
public record PopularPhotoDateRange : FlickrEntityBase
{
    /// <summary>The start date of the range.</summary>
    [JsonPropertyName("startdate")]
    public string? StartDate { get; init; }

    /// <summary>The end date of the range.</summary>
    [JsonPropertyName("enddate")]
    public string? EndDate { get; init; }
}
