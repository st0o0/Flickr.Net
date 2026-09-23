using System.Runtime.Serialization;

namespace Flickr.Net.Enums;
/// <summary>Type of URL associated with a Flickr entity.</summary>
public enum UrlType
{
    [EnumMember(Value = "none")]
    None,
    [EnumMember(Value = "site")]
    Site,
    [EnumMember(Value = "license")]
    License,
    [EnumMember(Value = "flickr")]
    Flickr,
    [EnumMember(Value = "photopage")]
    PhotoPage,
}
