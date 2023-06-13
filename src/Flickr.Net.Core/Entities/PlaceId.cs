namespace Flickr.Net.Core.Entities;

/// <summary>
/// </summary>
public struct PlaceId
{
    private readonly string _placeId;

    /// <summary>
    /// </summary>
    public PlaceId(string placeId)
    {
        _placeId = placeId;
    }

    /// <summary>
    /// </summary>
    public static implicit operator string(PlaceId placeId) => placeId.ToString();

    /// <summary>
    /// </summary>
    public override string ToString()
    {
        return _placeId;
    }
}