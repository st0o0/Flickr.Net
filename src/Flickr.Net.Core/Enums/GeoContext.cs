namespace Flickr.Net.Core.Enums;

/// <summary>
/// The context to set a geotagged photo as. Used by <see
/// cref="IFlickrPhotosGeo.SetContextAsync(string, GeoContext, CancellationToken)"/>.
/// </summary>
public enum GeoContext
{
    /// <summary>
    /// The photo has no defined context.
    /// </summary>
    [EnumMember(Value = "0")]
    NotDefined = 0,

    /// <summary>
    /// The photo was taken indoors.
    /// </summary>
    [EnumMember(Value = "1")]
    Indoors = 1,

    /// <summary>
    /// The photo was taken outdoors.
    /// </summary>
    [EnumMember(Value = "2")]
    Outdoors = 2
}