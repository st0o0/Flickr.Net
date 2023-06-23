using Flickr.Net.Core.Bases;
using Newtonsoft.Json;

namespace Flickr.Net.Core;

public record Location : FlickrEntityBase
{
    [JsonProperty("latitude")]
    public double Latitude { get; set; }

    [JsonProperty("longitude")]
    public double Longitude { get; set; }

    [JsonProperty("accuracy")]
    public GeoAccuracy Accuracy { get; set; }

    [JsonProperty("context")]
    public GeoContext Context { get; set; }

    [JsonProperty("locality")]
    public Locality Locality { get; set; }

    [JsonProperty("county")]
    public County County { get; set; }

    [JsonProperty("region")]
    public Region Region { get; set; }

    [JsonProperty("country")]
    public Country Country { get; set; }

    [JsonProperty("neighbourhood")]
    public Neighbourhood Neighbourhood { get; set; }
}

public struct Neighbourhood
{
    [JsonProperty("_content")]
    public string Content { get; set; }

    public static implicit operator string(Neighbourhood username) => username.Content;

    public static implicit operator Neighbourhood(string username) => new() { Content = username };
}

public struct Locality
{
    [JsonProperty("_content")]
    public string Content { get; set; }

    public static implicit operator string(Locality username) => username.Content;

    public static implicit operator Locality(string username) => new() { Content = username };
}

public struct Country
{
    [JsonProperty("_content")]
    public string Content { get; set; }

    public static implicit operator string(Country username) => username.Content;

    public static implicit operator Country(string username) => new() { Content = username };
}

public struct County
{
    [JsonProperty("_content")]
    public string Content { get; set; }

    public static implicit operator string(County username) => username.Content;

    public static implicit operator County(string username) => new() { Content = username };
}

public struct Region
{
    [JsonProperty("_content")]
    public string Content { get; set; }

    public static implicit operator string(Region username) => username.Content;

    public static implicit operator Region(string username) => new() { Content = username };
}