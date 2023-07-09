namespace Flickr.Net.Core.Internals.Extensions;

/// <summary>
/// </summary>
public static class CollectionStyleExtensions
{
    /// <summary>
    /// Converts a collection of <see cref="Style"/> values to a string literal containing the
    /// lowercase string representations of each distinct style once, separated by commas.
    /// </summary>
    /// <param name="styles">Set of styles.</param>
    /// <returns>Concatenated styles.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="styles"/> is null.</exception>
    /// <exception cref="OutOfMemoryException">Out of memory.</exception>
    internal static string ToFlickrString(this ICollection<Style> styles) => string.Join(",", styles.Distinct().Select(s => s.GetEnumMemberValue()));
}