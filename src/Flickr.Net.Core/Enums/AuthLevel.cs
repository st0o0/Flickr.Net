namespace Flickr.Net.Core.Enums;

/// <summary>
/// Used to specify the authentication levels needed for the Auth methods.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum AuthLevel
{
    /// <summary>
    /// No access required - do not use this value!
    /// </summary>
    [EnumMember(Value = "none")]
    None,

    /// <summary>
    /// Read only access is required by your application.
    /// </summary>
    [EnumMember(Value = "read")]
    Read,

    /// <summary>
    /// Read and write access is required by your application.
    /// </summary>
    [EnumMember(Value = "write")]
    Write,

    /// <summary>
    /// Read, write and delete access is required by your application. Deleting does not mean just
    /// the ability to delete photos, but also other meta data such as tags.
    /// </summary>
    [EnumMember(Value = "delete")]
    Delete
}