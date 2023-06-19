//namespace Flickr.Net.Core.Entities;

///// <summary>
///// An instance of a photo returned by <see cref="IFlickrGalleries.GetPhotosAsync(string,
///// PhotoSearchExtras, CancellationToken)"/>.
///// </summary>
//public class GalleryPhoto : Photo, IFlickrParsable
//{
//    /// <summary>
//    /// The comment added to this photo in the gallery, if any.
//    /// </summary>
//    public string Comment { get; set; }

//    void IFlickrParsable.Load(System.Xml.XmlReader reader)
//    {
//        Load(reader, false);

//        if (reader.LocalName == "comment")
//        {
//            Comment = reader.ReadElementContentAsString();
//        }

//        if (reader.LocalName == "description")
//        {
//            Description = reader.ReadElementContentAsString();
//        }

//        if (reader.NodeType == XmlNodeType.EndElement && reader.LocalName == "photo")
//        {
//            reader.Skip();
//        }
//    }
//}