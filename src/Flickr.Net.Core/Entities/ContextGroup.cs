using System.Xml;

namespace Flickr.Net.Core.Entities;

/// <summary>
/// A group context got a photo.
/// </summary>
public class ContextGroup
{
    /// <summary>
    /// The Group ID for the group that the selected photo is in.
    /// </summary>
    public string GroupId { get; set; }

    /// <summary>
    /// The title of the group that then selected photo is in.
    /// </summary>
    public string Title { get; set; }
}