using System.Collections.ObjectModel;
using System.Xml;

namespace Flickr.Net.Core.Entities;

/// <summary>
/// The collection.
/// </summary>
/// <remarks/>
public sealed class Collection : IFlickrParsable
{
    private readonly Collection<CollectionSet> _subsets = new();
    private readonly Collection<Collection> _subcollections = new();

    /// <remarks/>
    /// <summary>
    /// Gets or sets the collection id.
    /// </summary>
    public string CollectionId { get; set; }

    /// <remarks/>
    /// <summary>
    /// Gets or sets the title.
    /// </summary>
    public string Title { get; set; }

    /// <remarks/>
    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    public string Description { get; set; }

    /// <remarks/>
    /// <summary>
    /// Gets or sets the icon large.
    /// </summary>
    public string IconLarge { get; set; }

    /// <remarks/>
    /// <summary>
    /// Gets or sets the icon small.
    /// </summary>
    public string IconSmall { get; set; }

    /// <summary>
    /// The URL of the collection. Only returned when creating a new collection.
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// An array of <see cref="CollectionSet"/> objects.
    /// </summary>
    public Collection<CollectionSet> Sets
    {
        get { return _subsets; }
    }

    /// <summary>
    /// An array of <see cref="Collection"/> objects.
    /// </summary>
    public Collection<Collection> Collections
    {
        get { return _subcollections; }
    }

    void IFlickrParsable.Load(XmlReader reader)
    {
        if (reader.LocalName != "collection")
        {
            UtilityMethods.CheckParsingException(reader);
        }

        while (reader.MoveToNextAttribute())
        {
            switch (reader.LocalName)
            {
                case "id":
                    CollectionId = reader.Value;
                    break;

                case "title":
                    Title = reader.Value;
                    break;

                case "description":
                    Description = reader.Value;
                    break;

                case "iconlarge":
                    IconLarge = reader.Value;
                    break;

                case "iconsmall":
                    IconSmall = reader.Value;
                    break;

                case "url":
                    Url = reader.Value;
                    break;

                default:
                    UtilityMethods.CheckParsingException(reader);
                    break;
            }
        }

        reader.MoveToElement();

        // If this is an empty collection then skip to next item, which wont be a child, but may be
        // a sibling.
        if (reader.IsEmptyElement)
        {
            reader.Skip();
            return;
        }

        reader.Read();

        while (reader.NodeType == XmlNodeType.Element && (reader.LocalName == "collection" || reader.LocalName == "set"))
        {
            if (reader.LocalName == "collection")
            {
                Collection c = new();
                ((IFlickrParsable)c).Load(reader);
                _subcollections.Add(c);
            }
            else
            {
                CollectionSet s = new();
                ((IFlickrParsable)s).Load(reader);
                _subsets.Add(s);
            }
        }

        // Skip to next element (if any)
        reader.Skip();
    }
}