namespace Flickr.Net.Core.Enums;

/// <summary>
/// Used by <see cref="IFlickrPlaces.PlacesForUserAsync(PlaceType, string, string, int, DateTime?,
/// DateTime?, DateTime?, DateTime?, CancellationToken)"/>.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum PlaceType
{
    /// <summary>
    /// No place type selected. Not used by the Flickr API.
    /// </summary>
    [EnumMember(Value = "0")]
    None = 0,

    /// <summary>
    /// Locality.
    /// </summary>
    [EnumMember(Value = "7")]
    Locality = 7,

    /// <summary>
    /// County.
    /// </summary>
    [EnumMember(Value = "9")]
    County = 9,

    /// <summary>
    /// Region.
    /// </summary>
    [EnumMember(Value = "8")]
    Region = 8,

    /// <summary>
    /// Country.
    /// </summary>
    [EnumMember(Value = "12")]
    Country = 12,

    /// <summary>
    /// Neighbourhood.
    /// </summary>
    [EnumMember(Value = "22")]
    Neighbourhood = 22,

    /// <summary>
    /// Continent.
    /// </summary>
    [EnumMember(Value = "29")]
    Continent = 29
}