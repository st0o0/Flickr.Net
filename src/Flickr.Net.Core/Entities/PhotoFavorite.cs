﻿namespace Flickr.Net.Core.Entities;

/// <summary>
/// Details of the favourites for a photo.
/// </summary>
public sealed class PhotoFavorite : IFlickrParsable
{
    /// <summary>
    /// The Flickr User ID of the user who favourited the photo.
    /// </summary>
    public string UserId { get; set; }

    /// <summary>
    /// The user name of the user who favourited the photo.
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// The date the hoto was favourited.
    /// </summary>
    public DateTime FavoriteDate { get; set; }

    void IFlickrParsable.Load(XmlReader reader)
    {
        while (reader.MoveToNextAttribute())
        {
            switch (reader.Name)
            {
                case "nsid":
                    UserId = reader.Value;
                    break;

                case "username":
                    UserName = reader.Value;
                    break;

                case "favedate":
                    FavoriteDate = UtilityMethods.UnixTimestampToDate(reader.Value);
                    break;
            }
        }

        reader.Skip();
    }
}