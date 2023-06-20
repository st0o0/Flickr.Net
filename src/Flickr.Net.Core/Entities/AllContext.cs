namespace Flickr.Net.Core.Entities;

/// <summary>
/// All contexts that a photo is in.
/// </summary>
public sealed class AllContexts : IFlickrParsable
{
    /// <summary>
    /// An array of <see cref="ContextSet"/> objects for the current photo.
    /// </summary>
    public Collection<ContextSet> Sets { get; set; }

    /// <summary>
    /// An array of <see cref="ContextGroup"/> objects for the current photo.
    /// </summary>
    public Collection<ContextGroup> Groups { get; set; }

    /// <summary>
    /// Default constructor.
    /// </summary>
    public AllContexts()
    {
        Sets = new Collection<ContextSet>();
        Groups = new Collection<ContextGroup>();
    }

    void IFlickrParsable.Load(XmlReader reader)
    {
        while (reader.NodeType != XmlNodeType.EndElement)
        {
            switch (reader.LocalName)
            {
                case "set":
                    ContextSet set = new()
                    {
                        PhotosetId = reader.GetAttribute("id"),
                        Title = reader.GetAttribute("title")
                    };
                    Sets.Add(set);
                    reader.Read();
                    break;

                case "pool":
                    ContextGroup group = new()
                    {
                        GroupId = reader.GetAttribute("id"),
                        Title = reader.GetAttribute("title")
                    };
                    Groups.Add(group);
                    reader.Read();
                    break;
            }
        }
    }
}