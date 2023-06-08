namespace Flickr.Net.Core.Entities;

/// <summary>
/// The details of a tag of a photo.
/// </summary>
public sealed class PhotoInfoUrl : IFlickrParsable
{
    /// <summary>
    /// The url for the photoset.
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// The type of the url.
    /// </summary>
    public string UrlType { get; set; }

    void IFlickrParsable.Load(System.Xml.XmlReader reader)
    {
        if (reader.LocalName != "url")
        {
            UtilityMethods.CheckParsingException(reader);
        }

        while (reader.MoveToNextAttribute())
        {
            switch (reader.LocalName)
            {
                case "type":
                    UrlType = reader.Value;
                    break;

                default:
                    UtilityMethods.CheckParsingException(reader);
                    break;
            }
        }

        reader.Read();

        Url = reader.ReadContentAsString();

        if (Url.Contains("www.flickr.com"))
        {
            Url = Url.Replace("http://", "https://");
        }

        reader.Skip();
    }
}