namespace Flickr.Net.Core.Entities;

/// <summary>
/// A class containing information about a note on a photo.
/// </summary>
public sealed class PhotoInfoNote : IFlickrParsable
{
    /// <summary>
    /// The notes unique ID.
    /// </summary>
    public string NoteId { get; set; }

    /// <summary>
    /// The User ID of the user who wrote the note.
    /// </summary>
    public string AuthorId { get; set; }

    /// <summary>
    /// The name of the user who wrote the note.
    /// </summary>
    public string AuthorName { get; set; }

    /// <summary>
    /// The real name of the user who wrote the note.
    /// </summary>
    public string AuthorRealName { get; set; }

    /// <summary>
    /// Is the author of this note a Pro Flickr user.
    /// </summary>
    public bool? AuthorIsPro { get; set; }

    /// <summary>
    /// The x (left) position of the top left corner of the note.
    /// </summary>
    public int XPosition { get; set; }

    /// <summary>
    /// The y (top) position of the top left corner of the note.
    /// </summary>
    public int YPosition { get; set; }

    /// <summary>
    /// The width of the note.
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// The height of the note.
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// The text of the note.
    /// </summary>
    public string NoteText { get; set; }

    /// <summary>
    /// The <see cref="System.Drawing.Size"/> of this note. Derived from <see cref="Width"/> and
    /// <see cref="Height"/>.
    /// </summary>
    public System.Drawing.Size Size
    {
        get
        {
            return new System.Drawing.Size(Width, Height);
        }
    }

    /// <summary>
    /// The location of this note on the medium sized thumbnail of this photo. Derived from <see
    /// cref="XPosition"/> and <see cref="YPosition"/>.
    /// </summary>
    public System.Drawing.Point Location
    {
        get
        {
            return new System.Drawing.Point(XPosition, YPosition);
        }
    }

    void IFlickrParsable.Load(System.Xml.XmlReader reader)
    {
        if (reader.LocalName != "note")
        {
            UtilityMethods.CheckParsingException(reader);
        }

        while (reader.MoveToNextAttribute())
        {
            switch (reader.LocalName)
            {
                case "id":
                    NoteId = reader.Value;
                    break;

                case "author":
                    AuthorId = reader.Value;
                    break;

                case "authorname":
                    AuthorName = reader.Value;
                    break;

                case "authorrealname":
                    AuthorRealName = reader.Value;
                    break;

                case "authorispro":
                    AuthorIsPro = reader.Value == "1";
                    break;

                case "x":
                    XPosition = int.Parse(reader.Value, System.Globalization.NumberFormatInfo.InvariantInfo);
                    break;

                case "y":
                    YPosition = int.Parse(reader.Value, System.Globalization.NumberFormatInfo.InvariantInfo);
                    break;

                case "w":
                    Width = int.Parse(reader.Value, System.Globalization.NumberFormatInfo.InvariantInfo);
                    break;

                case "h":
                    Height = int.Parse(reader.Value, System.Globalization.NumberFormatInfo.InvariantInfo);
                    break;

                default:
                    UtilityMethods.CheckParsingException(reader);
                    break;
            }
        }

        reader.Read();

        NoteText = reader.ReadContentAsString();

        reader.Skip();
    }
}
