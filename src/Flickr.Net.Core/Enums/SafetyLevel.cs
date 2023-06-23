using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Flickr.Net.Core.Enums;

/// <summary>
/// Safety level of the photographic image.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum SafetyLevel
{
    /// <summary>
    /// No safety level specified.
    /// </summary>
    [EnumMember(Value = "0")]
    None = 0,

    /// <summary>
    /// Very safe (suitable for a global family audience).
    /// </summary>
    [EnumMember(Value = "1")]
    Safe = 1,

    /// <summary>
    /// Moderate (the odd articstic nude is ok, but thats the limit).
    /// </summary>
    [EnumMember(Value = "2")]
    Moderate = 2,

    /// <summary>
    /// Restricted (suitable for over 18s only).
    /// </summary>
    [EnumMember(Value = "3")]
    Restricted = 3
}