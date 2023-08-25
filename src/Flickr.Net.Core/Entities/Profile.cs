using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;
public record Profile : FlickrEntityBase<Id>
{
    [JsonPropertyName("nsid")]
    public string Nsid { get; set; }

    [JsonPropertyName("join_date")]
    public DateTime JoinDate { get; set; }

    [JsonPropertyName("occupation")]
    public string Occupation { get; set; }

    [JsonPropertyName("hometown")]
    public string Hometown { get; set; }

    [JsonPropertyName("showcase_set")]
    public string ShowcaseSet { get; set; }

    [JsonPropertyName("showcase_set_title")]
    public string ShowcaseSetTitle { get; set; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("profile_description")]
    public string ProfileDescription { get; set; }

    [JsonPropertyName("city")]
    public string City { get; set; }

    [JsonPropertyName("country")]
    public string Country { get; set; }

    [JsonPropertyName("facebook")]
    public string Facebook { get; set; }

    [JsonPropertyName("twitter")]
    public string Twitter { get; set; }

    [JsonPropertyName("tumblr")]
    public string Tumblr { get; set; }

    [JsonPropertyName("instagram")]
    public string Instagram { get; set; }

    [JsonPropertyName("pinterest")]
    public string Pinterest { get; set; }
}
