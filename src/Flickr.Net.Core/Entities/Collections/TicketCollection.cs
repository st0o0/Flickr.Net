using System.Collections.ObjectModel;

namespace FlickrNet.Core.Entities.Collections;

/// <summary>
/// A collection of <see cref="Ticket"/> instances.
/// </summary>
public sealed class TicketCollection : Collection<Ticket>, IFlickrParsable
{
    void IFlickrParsable.Load(System.Xml.XmlReader reader)
    {
        reader.Read();

        while (reader.LocalName == "ticket")
        {
            Ticket ticket = new();
            ((IFlickrParsable)ticket).Load(reader);
            Add(ticket);
        }

        reader.Skip();
    }
}