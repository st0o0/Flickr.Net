using System.Collections.ObjectModel;
using System.Xml;

namespace Flickr.Net.Core.Entities;

/// <summary>
/// A set context for a photo.
/// </summary>
public class ContextSet
{
    /// <summary>
    /// The Photoset ID of the set the selected photo is in.
    /// </summary>
    public string PhotosetId { get; set; }

    /// <summary>
    /// The title of the set the selected photo is in.
    /// </summary>
    public string Title { get; set; }
}
