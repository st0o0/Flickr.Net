using System.Runtime.Serialization;
using Flickr.Net.Internals;

namespace Flickr.Net.Enums;

/// <summary>
/// Geo-taggin accuracy. Used in <see cref="BoundaryBox.Accuracy"/>.
/// </summary>
/// <remarks>Level descriptions are only approximate.</remarks>
public enum GeoAccuracy
{
    /// <summary>
    /// No accuracy level specified.
    /// </summary>
    [EnumMember(Value = "0")]
    None = 0,

    /// <summary>
    /// World level, level 1.
    /// </summary>
    [EnumMember(Value = "1")]
    World = 1,

    /// <summary>
    /// Level 2
    /// </summary>
    [EnumMember(Value = "2")]
    Level2 = 2,

    /// <summary>
    /// Level 3 - approximately Country level.
    /// </summary>
    [EnumMember(Value = "3")]
    Country = 3,

    /// <summary>
    /// Level 4
    /// </summary>
    [EnumMember(Value = "4")]
    Level4 = 4,

    /// <summary>
    /// Level 5
    /// </summary>
    [EnumMember(Value = "5")]
    Level5 = 5,

    /// <summary>
    /// Level 6 - approximately Region level
    /// </summary>
    [EnumMember(Value = "6")]
    Region = 6,

    /// <summary>
    /// Level 7
    /// </summary>
    [EnumMember(Value = "7")]
    Level7 = 7,

    /// <summary>
    /// Level 8
    /// </summary>
    [EnumMember(Value = "8")]
    Level8 = 8,

    /// <summary>
    /// Level 9
    /// </summary>
    [EnumMember(Value = "9")]
    Level9 = 9,

    /// <summary>
    /// Level 10
    /// </summary>
    [EnumMember(Value = "10")]
    Level10 = 10,

    /// <summary>
    /// Level 11 - approximately City level
    /// </summary>
    [EnumMember(Value = "11")]
    City = 11,

    /// <summary>
    /// Level 12
    /// </summary>
    [EnumMember(Value = "12")]
    Level12 = 12,

    /// <summary>
    /// Level 13
    /// </summary>
    [EnumMember(Value = "13")]
    Level13 = 13,

    /// <summary>
    /// Level 14
    /// </summary>
    [EnumMember(Value = "14")]
    Level14 = 14,

    /// <summary>
    /// Level 15
    /// </summary>
    [EnumMember(Value = "15")]
    Level15 = 15,

    /// <summary>
    /// Street level (16) - the most accurate level and the default.
    /// </summary>
    [EnumMember(Value = "16")]
    Street = 16
}