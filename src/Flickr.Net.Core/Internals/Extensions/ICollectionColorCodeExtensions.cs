namespace Flickr.Net.Core.Internals.Extensions;

/// <summary>
/// </summary>
public static class ICollectionColorCodeExtensions
{
    /// <summary>
    /// Colors the codes to string.
    /// </summary>
    /// <param name="codes">The codes.</param>
    /// <returns>A string.</returns>
    internal static string ToFlickrString(this ICollection<string> codes)
    {
        Dictionary<string, string> codeMap = new()
        {
            { "red", "0" },
            { "darkorange", "1" },
            { "dark orange", "1" },
            { "orange", "2" },
            { "palepink", "b" },
            { "pale pink", "b" },
            { "yellow", "3" },
            { "lemonyellow", "4" },
            { "lemon yellow", "4" },
            { "school bus yellow", "3" },
            { "schoolbusyellow", "3" },
            { "green", "5" },
            { "darklimegreen", "6" },
            { "dark lime green", "6" },
            { "limegreen", "6" },
            { "lime green", "6" },
            { "cyan", "7" },
            { "blue", "8" },
            { "violet", "9" },
            { "purple", "9" },
            { "pink", "a" },
            { "white", "c" },
            { "grey", "d" },
            { "black", "e" },
        };

        var colorList = codes
            .Where(x => !string.IsNullOrEmpty(x))
            .Select(x => x.ToLower())
            .Where(x => x.Length == 1 && codeMap.ContainsValue(x))
            .Select(x => codeMap.GetValueOrDefault(x))
            .Where(x => !string.IsNullOrEmpty(x))
            .Distinct();

        return string.Join(",", colorList.ToArray());
    }
}
