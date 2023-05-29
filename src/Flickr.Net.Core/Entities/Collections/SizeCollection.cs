namespace FlickrNet.Core.Entities.Collections;

/// <summary>
/// Collection of <see cref="Size"/> items for a given photograph.
/// </summary>
public sealed class SizeCollection : System.Collections.ObjectModel.Collection<Size>, IFlickrParsable
{
    void IFlickrParsable.Load(System.Xml.XmlReader reader)
    {
        reader.Read();

        while (reader.LocalName == "size")
        {
            Size size = new();
            ((IFlickrParsable)size).Load(reader);
            Add(size);
        }

        reader.Skip();
    }
}