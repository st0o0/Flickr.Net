namespace Flickr.Net.Core.Entities;

/// <summary>
/// The referrer details returned by <see cref="IFlickrStats.GetCollectionReferrersAsync(DateTime,
/// string, string, int, int, CancellationToken)"/>, <see
/// cref="IFlickrStats.GetPhotoReferrersAsync(DateTime, string, string, int, int,
/// CancellationToken)"/>, <see cref="IFlickrStats.GetPhotosetReferrersAsync(DateTime, string,
/// string, int, int, CancellationToken)"/> and <see
/// cref="IFlickrStats.GetPhotostreamReferrersAsync(DateTime, string, int, int, CancellationToken)"/>.
/// </summary>
public sealed class StatReferrer : IFlickrParsable
{
    /// <summary>
    /// The url that the referrer referred from.
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// The number of times that URL was referred from.
    /// </summary>
    public int Views { get; set; }

    /// <summary>
    /// Then the referrer is a search engine this will contain the search term used.
    /// </summary>
    public string SearchTerm { get; set; }

    void IFlickrParsable.Load(System.Xml.XmlReader reader)
    {
        if (reader.LocalName != "referrer")
        {
            UtilityMethods.CheckParsingException(reader);
        }

        while (reader.MoveToNextAttribute())
        {
            switch (reader.LocalName)
            {
                case "url":
                    Url = reader.Value;
                    break;

                case "searchterm":
                    SearchTerm = reader.Value;
                    break;

                case "views":
                    Views = int.Parse(reader.Value, System.Globalization.NumberFormatInfo.InvariantInfo);
                    break;

                default:
                    UtilityMethods.CheckParsingException(reader);
                    break;
            }
        }

        reader.Skip();
    }
}