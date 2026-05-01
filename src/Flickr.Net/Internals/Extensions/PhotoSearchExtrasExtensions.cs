using Flickr.Net.Enums;

namespace Flickr.Net.Internals.Extensions;

/// <summary>
/// </summary>
internal static class PhotoSearchExtrasExtensions
{
    /// <summary>
    /// Utility method to convert the <see cref="PhotoSearchExtras"/> enum to a string.
    /// </summary>
    /// <example>
    /// <code>
    ///PhotoSearchExtras extras = PhotoSearchExtras.DateTaken &amp; PhotoSearchExtras.IconServer;
    ///string val = Utils.ExtrasToString(extras);
    ///Console.WriteLine(val);
    /// </code>
    /// outputs: "date_taken,icon_server";
    /// </example>
    /// <param name="extras"></param>
    /// <returns></returns>
    internal static string ToFlickrString(this PhotoSearchExtras extras)
    {
        var results = new List<string>();
        foreach (var extra in GetFlags(extras))
        {
            var enumString = extra.GetEnumMemberValue();
            results.Add(enumString);
        }

        return string.Join(",", results.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList());
    }

    private static IEnumerable<PhotoSearchExtras> GetFlags(PhotoSearchExtras input)
    {
        foreach (var value in Enum.GetValues<PhotoSearchExtras>())
        {
            if (value != 0 && input.HasFlag(value))
            {
                yield return value;
            }
        }
    }
}