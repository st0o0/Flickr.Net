namespace Flickr.Net.Core.Internals.Extensions;

/// <summary>
/// 
/// </summary>
public static class AuthLevelExtensions
{

    /// <summary>
    /// Converts <see cref="AuthLevel"/> to a string.
    /// </summary>
    /// <param name="level">The level to convert.</param>
    /// <returns></returns>
    public static string ToFlickrString(this AuthLevel level) => level switch
    {
        AuthLevel.Delete => "delete",
        AuthLevel.Read => "read",
        AuthLevel.Write => "write",
        AuthLevel.None => "none",
        _ => string.Empty,
    };
}