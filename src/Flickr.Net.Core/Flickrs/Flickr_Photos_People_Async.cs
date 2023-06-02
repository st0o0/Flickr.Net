using Flickr.Net.Core.Entities;
using Flickr.Net.Core.Entities.Collections;

namespace Flickr.Net.Core;

public partial class Flickr
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
    public async Task PhotosPeopleAddAsync(string photoId, string userId, int? personX = null, int? personY = null, int? personWidth = null, int? personHeight = null, CancellationToken cancellationToken = default)
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

    /// <summary>
    /// Remove a person from a photo.
    /// </summary>
    /// <param name="photoId">The id of the photo to remove a person from.</param>
    /// <param name="userId">The NSID of the person to remove from the photo.</param>
    public async Task PhotosPeopleDeleteAsync(string photoId, string userId, CancellationToken cancellationToken = default)
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

    /// <summary>
    /// Remove the bounding box from a person in a photo
    /// </summary>
    /// <param name="photoId">The id of the photo to edit a person in.</param>
    /// <param name="userId">The NSID of the person whose bounding box you want to remove.</param>
    public async Task PhotosPeopleDeleteCoordsAsync(string photoId, string userId, CancellationToken cancellationToken = default)
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

    /// <summary>
    /// Edit the bounding box of an existing person on a photo.
    /// </summary>
    /// <param name="photoId">The id of the photo to edit a person in.</param>
    /// <param name="userId">The NSID of the person to edit in a photo.</param>
    /// <param name="personX">The left-most pixel co-ordinate of the box around the person.</param>
    /// <param name="personY">The top-most pixel co-ordinate of the box around the person.</param>
    /// <param name="personWidth">The width (in pixels) of the box around the person.</param>
    /// <param name="personHeight">The height (in pixels) of the box around the person.</param>
    public async Task PhotosPeopleEditCoordsAsync(string photoId, string userId, int personX, int personY, int personWidth, int personHeight, CancellationToken cancellationToken = default)
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

    /// <summary>
    /// Get a list of people in a given photo.
    /// </summary>
    /// <param name="photoId">The id of the photo to get a list of people for.</param>
    public async Task<PhotoPersonCollection> PhotosPeopleGetListAsync(string photoId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.people.getList" },
            { "photo_id", photoId }
        };

        return await GetResponseAsync<PhotoPersonCollection>(parameters, cancellationToken);
    }
}