namespace Flickr.Net.Enums;

/// <summary>
/// An enumeration listing the permission levels required for calling the Flickr API methods.
/// </summary>
public enum MethodPermission
{
    /// <summary>
    /// No permissions required.
    /// </summary>
    [EnumMember(Value = "")]
    None = 0,

    /// <summary>
    /// A minimum of 'read' permissions required.
    /// </summary>
    [EnumMember(Value = "read")]
    Read = 1,

    /// <summary>
    /// A minimum of 'write' permissions required.
    /// </summary>
    [EnumMember(Value = "write")]
    Write = 2
}