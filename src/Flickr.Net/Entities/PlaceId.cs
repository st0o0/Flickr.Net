namespace Flickr.Net.Entities;
/// <param name="placeId"></param>
public readonly struct PlaceId(string placeId)
{
    private readonly string _placeId = placeId;
    /// <param name="placeId"></param>
    public static implicit operator string(PlaceId placeId) => placeId.ToString();
    /// <param name="placeId"></param>
    public static implicit operator PlaceId(string placeId) => new(placeId);
    /// <returns></returns>
    public override string ToString()
    {
        return _placeId;
    }
}