namespace FlickrNet.Core.Entities.Collections;

/// <summary>
/// List containing <see cref="GroupInfo"/> items.
/// </summary>
public sealed class GroupInfoCollection : System.Collections.ObjectModel.Collection<GroupInfo>, IFlickrParsable
{
    void IFlickrParsable.Load(System.Xml.XmlReader reader)
    {
        if (reader.LocalName != "groups")
        {
            UtilityMethods.CheckParsingException(reader);
        }

        reader.Read();

        while (reader.LocalName == "group")
        {
            GroupInfo member = new();
            ((IFlickrParsable)member).Load(reader);
            Add(member);
        }

        reader.Skip();
    }
}