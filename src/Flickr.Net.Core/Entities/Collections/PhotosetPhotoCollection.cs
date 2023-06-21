﻿namespace Flickr.Net.Core.Entities.Collections;

/// <summary>
/// A list of photos contained within a photoset.
/// </summary>
public sealed record PhotosetPhotoCollection : PagedPhotos, IFlickrParsable
{
    /// <summary>
    /// The id for the photoset.
    /// </summary>
    public string PhotosetId { get; set; }

    /// <summary>
    /// The ID of the primary photo for this photoset. May be contained within the list.
    /// </summary>
    public string PrimaryPhotoId { get; set; }

    /// <summary>
    /// The NSID of the owner of this photoset.
    /// </summary>
    public string OwnerId { get; set; }

    /// <summary>
    /// The real name of the owner of this photoset.
    /// </summary>
    public string OwnerName { get; set; }

    /// <summary>
    /// The title of the photoset.
    /// </summary>
    public string Title { get; set; }

    void IFlickrParsable.Load(System.Xml.XmlReader reader)
    {
        if (reader.LocalName != "photoset")
        {
            UtilityMethods.CheckParsingException(reader);
        }

        while (reader.MoveToNextAttribute())
        {
            switch (reader.LocalName)
            {
                case "id":
                    PhotosetId = reader.Value;
                    break;

                case "primary":
                    PrimaryPhotoId = reader.Value;
                    break;

                case "owner":
                    OwnerId = reader.Value;
                    break;

                case "ownername":
                    OwnerName = reader.Value;
                    break;

                case "page":
                    Page = int.Parse(reader.Value, System.Globalization.NumberFormatInfo.InvariantInfo);
                    break;

                case "total":
                    Total = int.Parse(reader.Value, System.Globalization.NumberFormatInfo.InvariantInfo);
                    break;

                case "pages":
                    Pages = int.Parse(reader.Value, System.Globalization.NumberFormatInfo.InvariantInfo);
                    break;

                case "perpage":
                case "per_page":
                    PerPage = int.Parse(reader.Value, System.Globalization.NumberFormatInfo.InvariantInfo);
                    break;

                case "title":
                    Title = reader.Value;
                    break;

                default:
                    UtilityMethods.CheckParsingException(reader);
                    break;
            }
        }

        reader.Read();

        while (reader.LocalName == "photo")
        {
            Photo photo = new();
            ((IFlickrParsable)photo).Load(reader);
            if (string.IsNullOrEmpty(photo.UserId))
            {
                photo.UserId = OwnerId;
            }

            //Add(photo);
        }

        reader.Skip();
    }
}