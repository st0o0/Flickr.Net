namespace Flickr.Net.Entities;

/// <summary>
/// </summary>
/// <remarks>
/// </remarks>
/// <param name="woeId"></param>
public readonly struct WoeId(string woeId)
{
    private readonly string _woeId = woeId;

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