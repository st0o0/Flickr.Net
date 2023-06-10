namespace Flickr.Net.Core;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrGalleries
{
    async Task IFlickrGalleries.AddPhotoAsync(string galleryId, string photoId, string comment, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.galleries.addPhoto" },
            { "gallery_id", galleryId },
            { "photo_id", photoId }
        };

        if (!string.IsNullOrEmpty(comment))
        {
            parameters.Add("comment", comment);
        }

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    async Task IFlickrGalleries.CreateAsync(string title, string description, string primaryPhotoId, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.galleries.create" },
            { "title", title },
            { "description", description }
        };

        if (!string.IsNullOrEmpty(primaryPhotoId))
        {
            parameters.Add("primary_photo_id", primaryPhotoId);
        }

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    async Task IFlickrGalleries.EditMetaAsync(string galleryId, string title, string description, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.galleries.editMeta" },
            { "gallery_id", galleryId },
            { "title", title }
        };

        if (!string.IsNullOrEmpty(description))
        {
            parameters.Add("description", description);
        }

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    async Task IFlickrGalleries.EditPhotoAsync(string galleryId, string photoId, string comment, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.galleries.editPhoto" },
            { "gallery_id", galleryId },
            { "photo_id", photoId },
            { "comment", comment }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    async Task IFlickrGalleries.EditPhotosAsync(string galleryId, string primaryPhotoId, IEnumerable<string> photoIds, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.galleries.editPhotos" },
            { "gallery_id", galleryId },
            { "primary_photo_id", primaryPhotoId },
            { "photo_ids", string.Join(",", photoIds.ToArray())}
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    async Task<Gallery> IFlickrGalleries.GetInfoAsync(string galleryId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.galleries.getInfo" },
            { "gallery_id", galleryId }
        };

        return await GetResponseAsync<Gallery>(parameters, cancellationToken);
    }

    async Task<GalleryCollection> IFlickrGalleries.GetListAsync(string userId, int page, int perPage, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.galleries.getList" }
        };

        if (!string.IsNullOrEmpty(userId))
        {
            parameters.Add("user_id", userId);
        }

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<GalleryCollection>(parameters, cancellationToken);
    }

    async Task<GalleryCollection> IFlickrGalleries.GetListForPhotoAsync(string photoId, int page, int perPage, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.galleries.getListForPhoto" },
            { "photo_id", photoId }
        };

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<GalleryCollection>(parameters, cancellationToken);
    }

    async Task<GalleryPhotoCollection> IFlickrGalleries.GetPhotosAsync(string galleryId, PhotoSearchExtras extras, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.galleries.getPhotos" },
            { "gallery_id", galleryId }
        };

        if (extras != PhotoSearchExtras.None)
        {
            parameters.Add("extras", UtilityMethods.ExtrasToString(extras));
        }

        return await GetResponseAsync<GalleryPhotoCollection>(parameters, cancellationToken);
    }

    async Task IFlickrGalleries.RemovePhoto(string galleryId, string photoId, string fullResponse, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        var parameters = new Dictionary<string, string>
        {
            { "method", "flickr.galleries.removePhoto" },
            { "gallery_id", galleryId },
            { "photo_id", photoId },
            { "full_response", fullResponse ?? "" }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }
}

/// <summary>
/// The flickr galleries.
/// </summary>
public interface IFlickrGalleries
{
    /// <summary>
    /// Add a photo to a gallery.
    /// </summary>
    /// <param name="galleryId">
    /// The ID of the gallery to add a photo to.
    /// Note: this is the compound ID returned in methods like <see
    ///       cref="IFlickrGalleries.GetListAsync(string, int, int, CancellationToken)"/>, and <see
    ///       cref="IFlickrGalleries.GetListForPhotoAsync(string, int, int, CancellationToken)"/>.
    /// </param>
    /// <param name="photoId">The photo ID to add to the gallery</param>
    /// <param name="comment">A short comment or story to accompany the photo.</param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task AddPhotoAsync(string galleryId, string photoId, string comment = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Create a new gallery for the calling user.
    /// </summary>
    /// <param name="title">The name of the gallery.</param>
    /// <param name="description">A short description for the gallery.</param>
    /// <param name="primaryPhotoId">The first photo to add to your gallery.</param>
    /// <param name="cancellationToken"></param>
    Task CreateAsync(string title, string description, string primaryPhotoId = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Modify the meta-data for a gallery.
    /// </summary>
    /// <param name="galleryId">The gallery ID to update.</param>
    /// <param name="title">The new title for the gallery.</param>
    /// <param name="description">The new description for the gallery.</param>
    /// <param name="cancellationToken"></param>
    Task EditMetaAsync(string galleryId, string title, string description = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Edit the comment for a gallery photo.
    /// </summary>
    /// <param name="galleryId">
    /// The ID of the gallery to add a photo to.
    /// Note: this is the compound ID returned in methods like <see
    ///       cref="IFlickrGalleries.GetListAsync(string, int, int, CancellationToken)"/>, and <see
    ///       cref="IFlickrGalleries.GetListForPhotoAsync(string, int, int, CancellationToken)"/>.
    /// </param>
    /// <param name="photoId">The photo ID to add to the gallery.</param>
    /// <param name="comment">The updated comment the photo.</param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task EditPhotoAsync(string galleryId, string photoId, string comment, CancellationToken cancellationToken = default);

    /// <summary>
    /// Modify the photos in a gallery. Use this method to add, remove and re-order photos.
    /// </summary>
    /// <param name="galleryId">
    /// The id of the gallery to modify. The gallery must belong to the calling user.
    /// </param>
    /// <param name="primaryPhotoId">
    /// The id of the photo to use as the 'primary' photo for the gallery. This id must also be
    /// passed along in photo_ids list argument.
    /// </param>
    /// <param name="photoIds">
    /// An enumeration of photo ids to include in the gallery. They will appear in the set in the
    /// order sent. This list must contain the primary photo id. This list of photos replaces the
    /// existing list.
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task EditPhotosAsync(string galleryId, string primaryPhotoId, IEnumerable<string> photoIds, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get the information about a gallery.
    /// </summary>
    /// <param name="galleryId">The gallery ID you are requesting information for.</param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task<Gallery> GetInfoAsync(string galleryId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a list of galleries for the specified user.
    /// </summary>
    /// <param name="userId">The user to return the galleries for.</param>
    /// <param name="page"></param>
    /// <param name="perPage"></param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task<GalleryCollection> GetListAsync(string userId, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

    /// <summary>
    /// Return the list of galleries to which a photo has been added. Galleries are returned sorted
    /// by date which the photo was added to the gallery.
    /// </summary>
    /// <param name="photoId">The ID of the photo to fetch a list of galleries for.</param>
    /// <param name="page">
    /// The page of results to return. If this argument is omitted, it defaults to 1.
    /// </param>
    /// <param name="perPage">
    /// Number of galleries to return per page. If this argument is omitted, it defaults to 100. The
    /// maximum allowed value is 500.
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task<GalleryCollection> GetListForPhotoAsync(string photoId, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

    /// <summary>
    /// Return the list of photos for a gallery.
    /// </summary>
    /// <param name="galleryId">The ID of the gallery of photos to return.</param>
    /// <param name="extras">A list of extra information to fetch for each returned record.</param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task<GalleryPhotoCollection> GetPhotosAsync(string galleryId, PhotoSearchExtras extras = PhotoSearchExtras.None, CancellationToken cancellationToken = default);

    /// <summary>
    /// Remove a photo from a gallery (and optionally update the gallery description).
    /// </summary>
    /// <param name="galleryId"></param>
    /// <param name="photoId"></param>
    /// <param name="fullResponse"></param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task RemovePhoto(string galleryId, string photoId, string fullResponse = null, CancellationToken cancellationToken = default);
}