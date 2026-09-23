using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;
/// <summary>Represents a user's profile information.</summary>
public record Profile : FlickrEntityBase<Id>
{
    [JsonPropertyName("nsid")]
    public string? Nsid { get; init; }
    [JsonPropertyName("join_date")]
    public DateTime JoinDate { get; init; }
    [JsonPropertyName("occupation")]
    public string? Occupation { get; init; }
    [JsonPropertyName("hometown")]
    public string? Hometown { get; init; }
    [JsonPropertyName("showcase_set")]
    public string? ShowcaseSet { get; init; }
    [JsonPropertyName("showcase_set_title")]
    public string? ShowcaseSetTitle { get; init; }
    [JsonPropertyName("first_name")]
    public string? FirstName { get; init; }
    [JsonPropertyName("last_name")]
    public string? LastName { get; init; }
    [JsonPropertyName("email")]
    public string? Email { get; init; }
    [JsonPropertyName("profile_description")]
    public string? ProfileDescription { get; init; }
    [JsonPropertyName("city")]
    public string? City { get; init; }
    [JsonPropertyName("country")]
    /// <summary>The country place information.</summary>
    public string? Country { get; init; }
    [JsonPropertyName("facebook")]
    public string? Facebook { get; init; }
    [JsonPropertyName("twitter")]
    public string? Twitter { get; init; }
    [JsonPropertyName("tumblr")]
    public string? Tumblr { get; init; }
    [JsonPropertyName("instagram")]
    public string? Instagram { get; init; }
    [JsonPropertyName("pinterest")]
    public string? Pinterest { get; init; }
}
