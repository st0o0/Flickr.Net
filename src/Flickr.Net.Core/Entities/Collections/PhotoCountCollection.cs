//namespace Flickr.Net.Core.Entities.Collections;

///// <summary>
///// The information about the number of photos a user has.
///// </summary>
//public sealed class PhotoCountCollection : System.Collections.ObjectModel.Collection<PhotoCount>, IFlickrParsable
//{
//    void IFlickrParsable.Load(System.Xml.XmlReader reader)
//    {
//        if (reader.LocalName != "photocounts")
//        {
//            UtilityMethods.CheckParsingException(reader);
//        }

// reader.Read();

// while (reader.LocalName == "photocount") { PhotoCount c = new();
// ((IFlickrParsable)c).Load(reader); Add(c); }

//        // Skip to next element (if any)
//        reader.Skip();
//    }
//}