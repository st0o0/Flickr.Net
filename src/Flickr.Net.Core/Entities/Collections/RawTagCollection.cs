namespace Flickr.Net.Core.Entities.Collections;

/// <summary>
/// List containing <see cref="RawTag"/> items.
/// </summary>
public sealed class RawTagCollection : Collection<RawTag>, IFlickrParsable
{
    void IFlickrParsable.Load(XmlReader reader)
    {
        reader.ReadToDescendant("tag");

        while (reader.LocalName == "tag")
        {
            RawTag member = new();
            ((IFlickrParsable)member).Load(reader);
            Add(member);
        }

        reader.Skip();
    }
}