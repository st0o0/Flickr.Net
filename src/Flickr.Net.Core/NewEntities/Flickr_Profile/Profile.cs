using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;
public record Profile : FlickrEntityBase<Id>
{
    [JsonProperty("nsid")]
    public string Nsid { get; set; }

    [JsonProperty("join_date")]
    public DateTime JoinDate { get; set; }

    [JsonProperty("occupation")]
    public string Occupation { get; set; }

    [JsonProperty("hometown")]
    public string Hometown { get; set; }

    [JsonProperty("showcase_set")]
    public string ShowcaseSet { get; set; }

    [JsonProperty("showcase_set_title")]
    public string ShowcaseSetTitle { get; set; }

    [JsonProperty("first_name")]
    public string FirstName { get; set; }

    [JsonProperty("last_name")]
    public string LastName { get; set; }

    [JsonProperty("email")]
    public string Email { get; set; }

    [JsonProperty("profile_description")]
    public string ProfileDescription { get; set; }

    [JsonProperty("city")]
    public string City { get; set; }

    [JsonProperty("country")]
    public string Country { get; set; }

    [JsonProperty("facebook")]
    public string Facebook { get; set; }

    [JsonProperty("twitter")]
    public string Twitter { get; set; }

    [JsonProperty("tumblr")]
    public string Tumblr { get; set; }

    [JsonProperty("instagram")]
    public string Instagram { get; set; }

    [JsonProperty("pinterest")]
    public string Pinterest { get; set; }
}
