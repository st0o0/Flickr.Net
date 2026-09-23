namespace Flickr.Net.Entities;
/// <param name="woeId"></param>
public readonly struct WoeId(string woeId)
{
    private readonly string _woeId = woeId;
    /// <param name="woeId"></param>
    public static implicit operator string(WoeId woeId) => woeId.ToString();
    /// <param name="woeId"></param>
    public static implicit operator WoeId(string woeId) => new(woeId);
    /// <returns></returns>
    public override string ToString()
    {
        return _woeId;
    }
}