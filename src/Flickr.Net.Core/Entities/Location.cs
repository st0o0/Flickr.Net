using System.Text.Json.Serialization;
using Flickr.Net.Core.Bases;

namespace Flickr.Net.Core;

public record Location : FlickrEntityBase
{
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    [JsonPropertyName("accuracy")]
    public GeoAccuracy Accuracy { get; set; }

    [JsonPropertyName("context")]
    public GeoContext Context { get; set; }

    [JsonPropertyName("locality")]
    public Locality Locality { get; set; }

    [JsonPropertyName("county")]
    public County County { get; set; }

    [JsonPropertyName("region")]
    public Region Region { get; set; }

    [JsonPropertyName("country")]
    public Country Country { get; set; }

    [JsonPropertyName("neighbourhood")]
    public Neighbourhood Neighbourhood { get; set; }
}

public struct Neighbourhood
{
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    public static implicit operator string(Neighbourhood username) => username.Content;

    public static implicit operator Neighbourhood(string username) => new() { Content = username };
}

public struct Locality
{
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    public static implicit operator string(Locality username) => username.Content;

    public static implicit operator Locality(string username) => new() { Content = username };
}

public struct Country
{
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    public static implicit operator string(Country username) => username.Content;

    public static implicit operator Country(string username) => new() { Content = username };
}

public struct County
{
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    public static implicit operator string(County username) => username.Content;

    public static implicit operator County(string username) => new() { Content = username };
}

public struct Region
{
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    public static implicit operator string(Region username) => username.Content;

    public static implicit operator Region(string username) => new() { Content = username };
}