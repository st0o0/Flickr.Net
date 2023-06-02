using Flickr.Net.Core.Entities.Interfaces;

namespace Flickr.Net.Core.Entities.Collections;

/// <summary>
/// List containing <see cref="Tag"/> items.
/// </summary>
public sealed class TagCollection : System.Collections.ObjectModel.Collection<Tag>, IFlickrParsable
{
    void IFlickrParsable.Load(System.Xml.XmlReader reader)
    {
        reader.ReadToDescendant("tag");

        while (reader.LocalName == "tag")
        {
            Tag member = new();
            ((IFlickrParsable)member).Load(reader);
            Add(member);
        }

        reader.Skip();
    }
}