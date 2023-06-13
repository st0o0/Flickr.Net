namespace Flickr.Net.Core.Entities;

/// <summary>
/// </summary>
public struct WoeId
{
    private readonly string _woeId;

    /// <summary>
    /// </summary>
    public WoeId(string woeId)
    {
        _woeId = woeId;
    }

    /// <summary>
    /// </summary>
    public static implicit operator string(WoeId woeId) => woeId.ToString();

    /// <summary>
    /// </summary>
    public override string ToString()
    {
        return _woeId;
    }
}