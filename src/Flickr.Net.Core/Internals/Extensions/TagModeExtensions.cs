namespace Flickr.Net.Core.Internals.Extensions;

/// <summary>
/// 
/// </summary>
public static class TagModeExtensions
{
    /// <summary>
    /// Convert a <see cref="TagMode"/> to a string used when passing to Flickr.
    /// </summary>
    /// <param name="tagMode">The tag mode to convert.</param>
    /// <returns>The string to pass to Flickr.</returns>
    public static string ToFlickrString(this TagMode tagMode) => tagMode switch
    {
        TagMode.None => string.Empty,
        TagMode.AllTags => "all",
        TagMode.AnyTag => "any",
        TagMode.Boolean => "bool",
        _ => string.Empty,
    };
}