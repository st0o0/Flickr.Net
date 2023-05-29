using System.Collections.ObjectModel;

namespace FlickrNet.Core.Entities.Collections;

/// <summary>
/// A collection of <see cref="Subscription"/> instances for the calling user.
/// </summary>
public sealed class SubscriptionCollection : Collection<Subscription>, IFlickrParsable
{
    void IFlickrParsable.Load(System.Xml.XmlReader reader)
    {
        if (reader == null)
        {
            throw new ArgumentNullException(nameof(reader));
        }

        if (reader.LocalName != "subscriptions") { UtilityMethods.CheckParsingException(reader); return; }

        reader.Read();

        while (reader.LocalName == "subscription")
        {
            Subscription item = new();
            ((IFlickrParsable)item).Load(reader);
            Add(item);
        }

        reader.Skip();
    }
}