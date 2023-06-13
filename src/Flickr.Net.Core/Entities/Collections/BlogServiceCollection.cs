namespace Flickr.Net.Core.Entities.Collections;

/// <summary>
/// A list of the blog services that Flickr aupports.
/// </summary>
public sealed class BlogServiceCollection : System.Collections.ObjectModel.Collection<BlogService>, IFlickrParsable
{
    void IFlickrParsable.Load(XmlReader reader)
    {
        if (reader.LocalName != "services")
        {
            UtilityMethods.CheckParsingException(reader);
        }

        reader.Read();

        while (reader.LocalName == "service")
        {
            BlogService service = new();
            ((IFlickrParsable)service).Load(reader);
            Add(service);
        }

        reader.Skip();
    }
}