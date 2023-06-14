namespace Flickr.Net.Core.Entities;

/// <summary>
/// </summary>
public readonly struct WoeId
{
    private readonly string _woeId;

    /// <summary>
    /// </summary>
    /// <param name="woeId"></param>
    public WoeId(string woeId)
    {
        _woeId = woeId;
    }

    /// <summary>
    /// </summary>
    /// <param name="woeId"></param>
    public static implicit operator string(WoeId woeId) => woeId.ToString();

    /// <summary>
    /// </summary>
    /// <param name="woeId"></param>
    public static implicit operator WoeId(string woeId) => new(woeId);

    /// <summary>
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return _woeId;
    }
}