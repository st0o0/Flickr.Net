using System.Xml;

namespace Flickr.Net.Core.Entities;

/// <summary>
/// The next (or previous) photo in the current context.
/// </summary>
public sealed class ContextPhoto : IFlickrParsable
{
    /// <summary>
    /// The id of the next photo. Will be "0" if this photo is the last.
    /// </summary>
    public string PhotoId { get; set; }

    /// <summary>
    /// The secret for the photo.
    /// </summary>
    public string Secret { get; set; }

    /// <summary>
    /// The server for this photo.
    /// </summary>
    public string Server { get; set; }

    /// <summary>
    /// The web server farm for this photos images.
    /// </summary>
    public string Farm { get; set; }

    /// <summary>
    /// The title of the next photo in context.
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// The URL, in the given context, for the next or previous photo.
    /// </summary>
    public string Url { get; set; }

    /// <summary>
    /// The URL for the thumbnail of the photo.
    /// </summary>
    public string ThumbnailUrl { get; set; }

    /// <summary>
    /// The media type of this item.
    /// </summary>
    public MediaType MediaType { get; set; }

    void IFlickrParsable.Load(XmlReader reader)
    {
        while (reader.MoveToNextAttribute())
        {
            switch (reader.LocalName)
            {
                case "id":
                    PhotoId = reader.Value;
                    break;

                case "secret":
                    Secret = reader.Value;
                    break;

                case "server":
                    Server = reader.Value;
                    break;

                case "farm":
                    Farm = reader.Value;
                    break;

                case "title":
                    Title = reader.Value;
                    break;

                case "url":
                    Url = "https://www.flickr.com" + reader.Value;
                    break;

                case "thumb":
                    ThumbnailUrl = reader.Value;
                    break;

                case "media":
                    MediaType = reader.Value == "photo" ? MediaType.Photos : MediaType.Videos;
                    break;
            }
        }

        reader.Read();
    }
}
