using System.Text.Json.Serialization;
using Flickr.Net.Bases;
using Flickr.Net.Enums;

namespace Flickr.Net;

/// <summary>
/// Represents a geographic location associated with a Flickr photo.
/// </summary>
public record Location : FlickrEntityBase
{
    /// <summary>Gets or sets the latitude coordinate.</summary>
    [JsonPropertyName("latitude")]
    public double Latitude { get; init; }

    /// <summary>Gets or sets the longitude coordinate.</summary>
    [JsonPropertyName("longitude")]
    public double Longitude { get; init; }

    /// <summary>Gets or sets the accuracy level of the location.</summary>
    [JsonPropertyName("accuracy")]
    public GeoAccuracy Accuracy { get; init; }

    /// <summary>Gets or sets the context of the location (indoors/outdoors).</summary>
    [JsonPropertyName("context")]
    public GeoContext Context { get; init; }

    /// <summary>Gets or sets the locality (city/town).</summary>
    [JsonPropertyName("locality")]
    public Locality Locality { get; init; }

    /// <summary>Gets or sets the county.</summary>
    [JsonPropertyName("county")]
    public County County { get; init; }

    /// <summary>Gets or sets the region (state/province).</summary>
    [JsonPropertyName("region")]
    public Region Region { get; init; }

    /// <summary>Gets or sets the country.</summary>
    [JsonPropertyName("country")]
    public Country Country { get; init; }

    /// <summary>Gets or sets the neighbourhood.</summary>
    [JsonPropertyName("neighbourhood")]
    public Neighbourhood Neighbourhood { get; init; }
}

/// <summary>
/// Wrapper for a neighbourhood name value.
/// </summary>
public struct Neighbourhood
{
    /// <summary>Gets or sets the neighbourhood name.</summary>
    [JsonPropertyName("_content")]
    public string? Content { get; init; }

    /// <summary>Implicitly converts a <see cref="Neighbourhood"/> to a string.</summary>
    public static implicit operator string(Neighbourhood username) => username.Content!;

    /// <summary>Implicitly converts a string to a <see cref="Neighbourhood"/>.</summary>
    public static implicit operator Neighbourhood(string username) => new() { Content = username };
}

/// <summary>
/// Wrapper for a locality (city/town) name value.
/// </summary>
public struct Locality
{
    /// <summary>Gets or sets the locality name.</summary>
    [JsonPropertyName("_content")]
    public string? Content { get; init; }

    /// <summary>Implicitly converts a <see cref="Locality"/> to a string.</summary>
    public static implicit operator string(Locality username) => username.Content!;

    /// <summary>Implicitly converts a string to a <see cref="Locality"/>.</summary>
    public static implicit operator Locality(string username) => new() { Content = username };
}

/// <summary>
/// Wrapper for a country name value.
/// </summary>
public struct Country
{
    /// <summary>Gets or sets the country name.</summary>
    [JsonPropertyName("_content")]
    public string? Content { get; init; }

    /// <summary>Implicitly converts a <see cref="Country"/> to a string.</summary>
    public static implicit operator string(Country username) => username.Content!;

    /// <summary>Implicitly converts a string to a <see cref="Country"/>.</summary>
    public static implicit operator Country(string username) => new() { Content = username };
}

/// <summary>
/// Wrapper for a county name value.
/// </summary>
public struct County
{
    /// <summary>Gets or sets the county name.</summary>
    [JsonPropertyName("_content")]
    public string? Content { get; init; }

    /// <summary>Implicitly converts a <see cref="County"/> to a string.</summary>
    public static implicit operator string(County username) => username.Content!;

    /// <summary>Implicitly converts a string to a <see cref="County"/>.</summary>
    public static implicit operator County(string username) => new() { Content = username };
}

/// <summary>
/// Wrapper for a region (state/province) name value.
/// </summary>
public struct Region
{
    /// <summary>Gets or sets the region name.</summary>
    [JsonPropertyName("_content")]
    public string? Content { get; init; }

    /// <summary>Implicitly converts a <see cref="Region"/> to a string.</summary>
    public static implicit operator string(Region username) => username.Content!;

    /// <summary>Implicitly converts a string to a <see cref="Region"/>.</summary>
    public static implicit operator Region(string username) => new() { Content = username };
}
