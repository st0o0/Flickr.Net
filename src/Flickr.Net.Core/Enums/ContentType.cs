using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Flickr.Net.Core.Enums;

/// <summary>
/// What type of content is the upload representing.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum ContentType
{
    /// <summary>
    /// No content type specified.
    /// </summary>
    [EnumMember(Value = "none")]
    None = 0,

    /// <summary>
    /// For normal photographs.
    /// </summary>
    [EnumMember(Value = "photo")]
    Photo = 1,

    /// <summary>
    /// For screenshots.
    /// </summary>
    [EnumMember(Value = "screenshot")]
    Screenshot = 2,

    /// <summary>
    /// For other uploads, such as artwork.
    /// </summary>
    [EnumMember(Value = "other")]
    Other = 3
}