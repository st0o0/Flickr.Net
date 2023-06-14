namespace Flickr.Net.Core.Entities;

/// <summary>
/// Details of a particular license available from Flickr.
/// </summary>
public sealed class License : IFlickrParsable
{
    /// <summary>
    /// The ID of the license. Used by <see cref="IFlickrPhotos.GetInfoAsync(string, string,
    /// CancellationToken)"/> and <see cref="IFlickrPhotos.GetInfoAsync(string, string, CancellationToken)"/>.
    /// </summary>
    public LicenseType LicenseId { get; set; }

    /// <summary>
    /// The name of the license.
    /// </summary>
    public string LicenseName { get; set; }

    /// <summary>
    /// The URL for the license text.
    /// </summary>
    public string LicenseUrl { get; set; }

    void IFlickrParsable.Load(System.Xml.XmlReader reader)
    {
        while (reader.MoveToNextAttribute())
        {
            switch (reader.LocalName)
            {
                case "id":
                    LicenseId = (LicenseType)reader.ReadContentAsInt();
                    break;

                case "name":
                    LicenseName = reader.Value;
                    break;

                case "url":
                    if (!string.IsNullOrEmpty(reader.Value))
                    {
                        LicenseUrl = reader.Value;
                    }
                    break;

                default:
                    UtilityMethods.CheckParsingException(reader);
                    break;
            }
        }

        reader.Read();
    }
}