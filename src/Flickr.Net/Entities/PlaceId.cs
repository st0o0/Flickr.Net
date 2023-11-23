namespace Flickr.Net.Entities;

/// <summary>
/// </summary>
/// <remarks>
/// </remarks>
/// <param name="placeId"></param>
public readonly struct PlaceId(string placeId)
{
    private readonly string _placeId = placeId;

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