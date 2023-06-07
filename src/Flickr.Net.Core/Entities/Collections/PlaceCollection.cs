namespace Flickr.Net.Core.Entities.Collections;

/// <summary>
/// A list of <see cref="Place"/> items.
/// </summary>
public sealed class PlaceCollection : System.Collections.ObjectModel.Collection<Place>, IFlickrParsable
{
    void IFlickrParsable.Load(System.Xml.XmlReader reader)
    {
        reader.Read();

        while (reader.LocalName == "place")
        {
            Place place = new();
            ((IFlickrParsable)place).Load(reader);
            Add(place);
        }

        reader.Skip();
    }
}