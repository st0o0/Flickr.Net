using System.Globalization;

namespace Flickr.Net.Internals.Extensions;

/// <summary>
/// </summary>
internal static class DateTimeExtensions
{
    private static readonly DateTime UnixStartDate = DateTime.UnixEpoch;

    /// <summary>
    /// Converts a <see cref="DateTime"/> object into a unix timestamp number.
    /// </summary>
    /// <param name="date">The date to convert.</param>
    /// <returns>A long for the number of seconds since 1st January 1970, as per unix specification.</returns>
    public static string ToUnixTimestamp(this DateTime date) => (date - UnixStartDate).TotalSeconds.ToString("0", NumberFormatInfo.InvariantInfo);

    /// <summary>
    /// Dates the to my sql.
    /// </summary>
    /// <param name="date">The date.</param>
    /// <returns>A string.</returns>
    public static string ToMySql(this DateTime date) => date.ToString("yyyy-MM-dd HH:mm:ss", DateTimeFormatInfo.InvariantInfo);
}