namespace Flickr.Net.Core.Enums;

/// <summary>
/// Used to specify the authentication levels needed for the Auth methods.
/// </summary>
[Serializable]
public enum AuthLevel
{
    /// <summary>
    /// No access required - do not use this value!
    /// </summary>
    None,

    /// <summary>
    /// Read only access is required by your application.
    /// </summary>
    Read,

    /// <summary>
    /// Read and write access is required by your application.
    /// </summary>
    Write,

    /// <summary>
    /// Read, write and delete access is required by your application.
    /// Deleting does not mean just the ability to delete photos, but also other meta data such as tags.
    /// </summary>
    Delete
}