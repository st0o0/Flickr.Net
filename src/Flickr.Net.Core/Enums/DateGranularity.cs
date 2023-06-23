using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Flickr.Net.Core.Enums;

/// <summary>
/// DateGranularity, used for setting taken date in <see cref="IFlickrPhotos.SetDatesAsync(string,
/// DateTime?, DateTime?, DateGranularity, CancellationToken)"/>.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum DateGranularity
{
    /// <summary>
    /// The date specified is the exact date the photograph was taken.
    /// </summary>
    [EnumMember(Value = "0")]
    FullDate = 0,

    /// <summary>
    /// The date specified is the year and month the photograph was taken.
    /// </summary>
    [EnumMember(Value = "4")]
    YearMonthOnly = 4,

    /// <summary>
    /// The date specified is the year the photograph was taken.
    /// </summary>
    [EnumMember(Value = "6")]
    YearOnly = 6,

    /// <summary>
    /// The date is an approximation only and only the year is likely to be supplied.
    /// </summary>
    [EnumMember(Value = "8")]
    Circa = 8
}