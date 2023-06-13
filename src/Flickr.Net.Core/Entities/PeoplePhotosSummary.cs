namespace Flickr.Net.Core.Entities;

/// <summary>
/// A summary of a users photos.
/// </summary>
public sealed class PersonPhotosSummary : IFlickrParsable
{
    /// <summary>
    /// The first date the user uploaded a picture, converted into <see cref="DateTime"/> format.
    /// </summary>
    public DateTime FirstDate { get; set; }

    /// <summary>
    /// The first date the user took a picture, converted into <see cref="DateTime"/> format.
    /// </summary>
    public DateTime FirstTakenDate { get; set; }

    /// <summary>
    /// The total number of photos for the user.
    /// </summary>
    /// <remarks/>
    public int PhotoCount { get; set; }

    /// <summary>
    /// The total number of photos for the user.
    /// </summary>
    /// <remarks/>
    public int Views { get; set; }

    void IFlickrParsable.Load(System.Xml.XmlReader reader)
    {
        reader.Read();

        while (reader.LocalName != "photos")
        {
            switch (reader.LocalName)
            {
                case "firstdatetaken":
                    FirstTakenDate = UtilityMethods.ParseDateWithGranularity(reader.ReadElementContentAsString());
                    break;

                case "firstdate":
                    FirstDate = UtilityMethods.UnixTimestampToDate(reader.ReadElementContentAsString());
                    break;

                case "count":
                    PhotoCount = reader.ReadElementContentAsInt();
                    break;

                case "views":
                    Views = reader.ReadElementContentAsInt();
                    break;

                default:
                    UtilityMethods.CheckParsingException(reader);
                    reader.Skip();
                    break;
            }
        }

        reader.Read();
    }
}