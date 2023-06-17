using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Flickr.Net.Core.Enums;

/// <summary>
/// An enumeration of different media types tto search for.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum MediaType
{
    /// <summary>
    /// Default MediaType. Does not correspond to a value that is sent to Flickr.
    /// </summary>
    [EnumMember(Value = "")]
    None,

    /// <summary>
    /// All media types will be return.
    /// </summary>
    [EnumMember(Value = "all")]
    All,

    /// <summary>
    /// Only photos will be returned.
    /// </summary>
    [EnumMember(Value = "photos")]
    Photos,

    /// <summary>
    /// Only videos will be returned.
    /// </summary>
    [EnumMember(Value = "videos")]
    Videos
}