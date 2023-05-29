using System.Xml;

namespace FlickrNet.Core.Entities.Collections;

/// <summary>
/// A list of <see cref="PhotoComment"/> items.
/// </summary>
public sealed class PhotoCommentCollection : System.Collections.ObjectModel.Collection<PhotoComment>, IFlickrParsable
{
    /// <summary>
    /// The ID of photo for these comments.
    /// </summary>
    public string PhotoId { get; set; }

    void IFlickrParsable.Load(XmlReader reader)
    {
        if (reader.LocalName != "comments")
        {
            UtilityMethods.CheckParsingException(reader);
        }

        while (reader.MoveToNextAttribute())
        {
            switch (reader.LocalName)
            {
                case "photo_id":
                    PhotoId = reader.Value;
                    break;

                default:
                    UtilityMethods.CheckParsingException(reader);
                    break;
            }
        }

        reader.Read();

        while (reader.LocalName == "comment")
        {
            PhotoComment comment = new();
            ((IFlickrParsable)comment).Load(reader);
            Add(comment);
        }
        reader.Skip();
    }
}