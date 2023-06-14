namespace Flickr.Net.Core.Entities;

/// <summary>
/// </summary>
public readonly struct PlaceId
{
    private readonly string _placeId;

    /// <summary>
    /// </summary>
    /// <param name="placeId"></param>
    public PlaceId(string placeId)
    {
        _placeId = placeId;
    }

    /// <summary>
    /// </summary>
    /// <param name="placeId"></param>
    public static implicit operator string(PlaceId placeId) => placeId.ToString();

    /// <summary>
    /// </summary>
    /// <param name="placeId"></param>
    public static implicit operator PlaceId(string placeId) => new(placeId);

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return _placeId;
    }
}