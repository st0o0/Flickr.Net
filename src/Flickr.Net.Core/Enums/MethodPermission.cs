namespace Flickr.Net.Core.Enums;

/// <summary>
/// An enumeration listing the permission levels required for calling the Flickr API methods.
/// </summary>
public enum MethodPermission
{
    /// <summary>
    /// No permissions required.
    /// </summary>
    None = 0,

    /// <summary>
    /// A minimum of 'read' permissions required.
    /// </summary>
    Read = 1,

    /// <summary>
    /// A minimum of 'write' permissions required.
    /// </summary>
    Write = 2
}