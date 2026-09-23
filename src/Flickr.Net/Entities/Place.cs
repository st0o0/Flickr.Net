using System.Text.Json.Serialization;
using Flickr.Net.Bases;

namespace Flickr.Net;

/// <summary>
/// Represents a geographic place returned by the Flickr Places API.
/// </summary>
public record Place : FlickrEntityBase
{
    /// <summary>The Flickr place ID.</summary>
    [JsonPropertyName("place_id")]
    public string? PlaceId { get; init; }

    /// <summary>The Where On Earth (WOE) identifier.</summary>
    [JsonPropertyName("woeid")]
    public string? WoeId { get; init; }

    /// <summary>The latitude of the place center.</summary>
    [JsonPropertyName("latitude")]
    public double? Latitude { get; init; }

    /// <summary>The longitude of the place center.</summary>
    [JsonPropertyName("longitude")]
    public double? Longitude { get; init; }

    /// <summary>The Flickr URL path for this place.</summary>
    [JsonPropertyName("place_url")]
    public string? PlaceUrl { get; init; }

    /// <summary>The type of place (e.g. locality, region, country).</summary>
    [JsonPropertyName("place_type")]
    public string? PlaceType { get; init; }

    /// <summary>The numeric place type identifier.</summary>
    [JsonPropertyName("place_type_id")]
    public int? PlaceTypeId { get; init; }

    /// <summary>The timezone of the place (e.g. "Europe/Berlin").</summary>
    [JsonPropertyName("timezone")]
    public string? Timezone { get; init; }

    /// <summary>The display name of the place.</summary>
    [JsonPropertyName("name")]
    public string? Name { get; init; }

    /// <summary>The WOE name of the place.</summary>
    [JsonPropertyName("woe_name")]
    public string? WoeName { get; init; }

    /// <summary>The text content, typically the full place name path.</summary>
    [JsonPropertyName("_content")]
    public string? Content { get; init; }

    /// <summary>The number of photos taken at this place.</summary>
    [JsonPropertyName("photo_count")]
    public int? PhotoCount { get; init; }

    /// <summary>The containing neighbourhood, if applicable.</summary>
    [JsonPropertyName("neighbourhood")]
    public PlaceLocation? Neighbourhood { get; init; }

    /// <summary>The containing locality (city/town).</summary>
    [JsonPropertyName("locality")]
    public PlaceLocation? Locality { get; init; }

    /// <summary>The containing county.</summary>
    [JsonPropertyName("county")]
    public PlaceLocation? County { get; init; }

    /// <summary>The containing region (state/province).</summary>
    [JsonPropertyName("region")]
    public PlaceLocation? Region { get; init; }

    /// <summary>The containing country.</summary>
    [JsonPropertyName("country")]
    public PlaceLocation? Country { get; init; }

    /// <summary>Whether this place has shape data available.</summary>
    [JsonPropertyName("has_shapedata")]
    public bool? HasShapeData { get; init; }
}

/// <summary>
/// Represents a location component within a place hierarchy (e.g. locality, region, country).
/// </summary>
public record PlaceLocation
{
    /// <summary>The text content of the location name.</summary>
    [JsonPropertyName("_content")]
    public string? Content { get; init; }

    /// <summary>The Flickr place ID for this location.</summary>
    [JsonPropertyName("place_id")]
    public string? PlaceId { get; init; }

    /// <summary>The WOE ID for this location.</summary>
    [JsonPropertyName("woeid")]
    public string? WoeId { get; init; }

    /// <summary>The latitude of this location.</summary>
    [JsonPropertyName("latitude")]
    public double? Latitude { get; init; }

    /// <summary>The longitude of this location.</summary>
    [JsonPropertyName("longitude")]
    public double? Longitude { get; init; }

    /// <summary>The Flickr URL path for this location.</summary>
    [JsonPropertyName("place_url")]
    public string? PlaceUrl { get; init; }

    /// <summary>The type of place.</summary>
    [JsonPropertyName("place_type")]
    public string? PlaceType { get; init; }

    /// <summary>The numeric place type identifier.</summary>
    [JsonPropertyName("place_type_id")]
    public int? PlaceTypeId { get; init; }
}

/// <summary>
/// Represents a place type definition from the Flickr Places API.
/// </summary>
public record FlickrPlaceType : FlickrEntityBase
{
    /// <summary>The numeric place type identifier.</summary>
    [JsonPropertyName("place_type_id")]
    public int? PlaceTypeId { get; init; }

    /// <summary>The text content (name of the place type).</summary>
    [JsonPropertyName("_content")]
    public string? Content { get; init; }
}

/// <summary>
/// Represents a shape data entry from the shape history of a place.
/// </summary>
public record ShapeData : FlickrEntityBase
{
    /// <summary>The date the shape was created.</summary>
    [JsonPropertyName("created")]
    public string? Created { get; init; }

    /// <summary>The alpha value of the shape.</summary>
    [JsonPropertyName("alpha")]
    public double? Alpha { get; init; }

    /// <summary>The number of points in the shape.</summary>
    [JsonPropertyName("count_points")]
    public int? CountPoints { get; init; }

    /// <summary>The number of edges in the shape.</summary>
    [JsonPropertyName("count_edges")]
    public int? CountEdges { get; init; }

    /// <summary>Whether this shape has a donut hole.</summary>
    [JsonPropertyName("has_donuthole")]
    public bool? HasDonutHole { get; init; }

    /// <summary>Whether this is the default shape.</summary>
    [JsonPropertyName("is_default")]
    public bool? IsDefault { get; init; }

    /// <summary>The polylines that define the shape boundary.</summary>
    [JsonPropertyName("polylines")]
    public ShapePolylines? Polylines { get; init; }
}

/// <summary>
/// Container for polyline data within a shape.
/// </summary>
public record ShapePolylines
{
    /// <summary>The list of polylines.</summary>
    [JsonPropertyName("polyline")]
    public List<ShapePolyline>? Polyline { get; init; }
}

/// <summary>
/// A single polyline defining part of a shape boundary.
/// </summary>
public record ShapePolyline
{
    /// <summary>The encoded polyline text content.</summary>
    [JsonPropertyName("_content")]
    public string? Content { get; init; }
}

/// <summary>
/// Represents a tag associated with a place.
/// </summary>
public record PlaceTag : FlickrEntityBase
{
    /// <summary>The tag count.</summary>
    [JsonPropertyName("count")]
    public int? Count { get; init; }

    /// <summary>The tag text content.</summary>
    [JsonPropertyName("_content")]
    public string? Content { get; init; }
}
