using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Flickr.Net.Core.Enums;

/// <summary>
/// The type of the <see cref="Item"/>.
/// </summary>
[DataContract]
[JsonConverter(typeof(StringEnumConverter))]
public enum ItemType
{
    /// <summary>
    /// The type is unknown, either not set of a new unsupported type.
    /// </summary>
    [EnumMember(Value = "")]
    Unknown,

    /// <summary>
    /// The activity item is on a photoset.
    /// </summary>
    [EnumMember(Value = "photoset")]
    Photoset,

    /// <summary>
    /// The activitiy item is on a photo.
    /// </summary>
    [EnumMember(Value = "photo")]
    Photo,

    /// <summary>
    /// The activity item is on a gallery.
    /// </summary>
    [EnumMember(Value = "gallery")]
    Gallery
}