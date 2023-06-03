﻿namespace Flickr.Net.Core;

public partial class Flickr : IFlickrPhotosPeople
{
    async Task IFlickrPhotosPeople.AddAsync(string photoId, string userId, int? personX, int? personY, int? personWidth, int? personHeight, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.people.add" },
            { "photo_id", photoId },
            { "user_id", userId }
        };

        if (personX != null)
        {
            parameters.Add("person_x", personX.Value.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (personY != null)
        {
            parameters.Add("person_y", personY.Value.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (personWidth != null)
        {
            parameters.Add("person_w", personWidth.Value.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (personHeight != null)
        {
            parameters.Add("person_h", personHeight.Value.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    async Task IFlickrPhotosPeople.DeleteAsync(string photoId, string userId, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.people.delete" },
            { "photo_id", photoId },
            { "user_id", userId }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    async Task IFlickrPhotosPeople.DeleteCoordsAsync(string photoId, string userId, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.people.deleteCoords" },
            { "photo_id", photoId },
            { "user_id", userId }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    async Task IFlickrPhotosPeople.EditCoordsAsync(string photoId, string userId, int personX, int personY, int personWidth, int personHeight, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.people.editCoords" },
            { "photo_id", photoId },
            { "user_id", userId },
            { "person_x", personX.ToString(System.Globalization.NumberFormatInfo.InvariantInfo) },
            { "person_y", personY.ToString(System.Globalization.NumberFormatInfo.InvariantInfo) },
            { "person_w", personWidth.ToString(System.Globalization.NumberFormatInfo.InvariantInfo) },
            { "person_h", personHeight.ToString(System.Globalization.NumberFormatInfo.InvariantInfo) }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    async Task<PhotoPersonCollection> IFlickrPhotosPeople.GetListAsync(string photoId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.people.getList" },
            { "photo_id", photoId }
        };

        return await GetResponseAsync<PhotoPersonCollection>(parameters, cancellationToken);
    }
}

public interface IFlickrPhotosPeople
{
    /// <summary>
    /// Add a person to a photo. Coordinates and sizes of boxes are optional; they are measured in pixels, based on the 500px image size shown on individual photo pages.
    /// </summary>
    /// <param name="photoId">The id of the photo to add a person to.</param>
    /// <param name="userId">The NSID of the user to add to the photo.</param>
    /// <param name="personX">The left-most pixel co-ordinate of the box around the person.</param>
    /// <param name="personY">The top-most pixel co-ordinate of the box around the person.</param>
    /// <param name="personWidth">The width (in pixels) of the box around the person.</param>
    /// <param name="personHeight">The height (in pixels) of the box around the person.</param>
    Task AddAsync(string photoId, string userId, int? personX = null, int? personY = null, int? personWidth = null, int? personHeight = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove a person from a photo.
    /// </summary>
    /// <param name="photoId">The id of the photo to remove a person from.</param>
    /// <param name="userId">The NSID of the person to remove from the photo.</param>
    Task DeleteAsync(string photoId, string userId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove the bounding box from a person in a photo
    /// </summary>
    /// <param name="photoId">The id of the photo to edit a person in.</param>
    /// <param name="userId">The NSID of the person whose bounding box you want to remove.</param>
    Task DeleteCoordsAsync(string photoId, string userId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Edit the bounding box of an existing person on a photo.
    /// </summary>
    /// <param name="photoId">The id of the photo to edit a person in.</param>
    /// <param name="userId">The NSID of the person to edit in a photo.</param>
    /// <param name="personX">The left-most pixel co-ordinate of the box around the person.</param>
    /// <param name="personY">The top-most pixel co-ordinate of the box around the person.</param>
    /// <param name="personWidth">The width (in pixels) of the box around the person.</param>
    /// <param name="personHeight">The height (in pixels) of the box around the person.</param>
    Task EditCoordsAsync(string photoId, string userId, int personX, int personY, int personWidth, int personHeight, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a list of people in a given photo.
    /// </summary>
    /// <param name="photoId">The id of the photo to get a list of people for.</param>
    Task<PhotoPersonCollection> GetListAsync(string photoId, CancellationToken cancellationToken = default);
}