using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;

/// <summary>
/// </summary>
public record Profile : FlickrEntityBase<Id>
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("nsid")]
    public string Nsid { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("join_date")]
    public DateTime JoinDate { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("occupation")]
    public string Occupation { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("hometown")]
    public string Hometown { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("showcase_set")]
    public string ShowcaseSet { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("showcase_set_title")]
    public string ShowcaseSetTitle { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("profile_description")]
    public string ProfileDescription { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("city")]
    public string City { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("country")]
    public string Country { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("facebook")]
    public string Facebook { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("twitter")]
    public string Twitter { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("tumblr")]
    public string Tumblr { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("instagram")]
    public string Instagram { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("pinterest")]
    public string Pinterest { get; set; }
}
