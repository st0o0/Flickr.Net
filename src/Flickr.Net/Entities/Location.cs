using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Enums;

namespace Flickr.Net;

/// <summary>
/// </summary>
public record Location : FlickrEntityBase
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("latitude")]
    public double Latitude { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("longitude")]
    public double Longitude { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("accuracy")]
    public GeoAccuracy Accuracy { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("context")]
    public GeoContext Context { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("locality")]
    public Locality Locality { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("county")]
    public County County { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("region")]
    public Region Region { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("country")]
    public Country Country { get; set; }

    /// <summary>
    /// </summary>
    [JsonPropertyName("neighbourhood")]
    public Neighbourhood Neighbourhood { get; set; }
}

/// <summary>
/// </summary>
public struct Neighbourhood
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    /// <summary>
    /// </summary>
    public static implicit operator string(Neighbourhood username) => username.Content;

    /// <summary>
    /// </summary>
    public static implicit operator Neighbourhood(string username) => new() { Content = username };
}

/// <summary>
/// </summary>
public struct Locality
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    /// <summary>
    /// </summary>
    public static implicit operator string(Locality username) => username.Content;

    /// <summary>
    /// </summary>
    public static implicit operator Locality(string username) => new() { Content = username };
}

/// <summary>
/// </summary>
public struct Country
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    /// <summary>
    /// </summary>
    public static implicit operator string(Country username) => username.Content;

    /// <summary>
    /// </summary>
    public static implicit operator Country(string username) => new() { Content = username };
}

/// <summary>
/// </summary>
public struct County
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    /// <summary>
    /// </summary>
    public static implicit operator string(County username) => username.Content;

    /// <summary>
    /// </summary>
    public static implicit operator County(string username) => new() { Content = username };
}

/// <summary>
/// </summary>
public struct Region
{
    /// <summary>
    /// </summary>
    [JsonPropertyName("_content")]
    public string Content { get; set; }

    /// <summary>
    /// </summary>
    public static implicit operator string(Region username) => username.Content;

    /// <summary>
    /// </summary>
    public static implicit operator Region(string username) => new() { Content = username };
}