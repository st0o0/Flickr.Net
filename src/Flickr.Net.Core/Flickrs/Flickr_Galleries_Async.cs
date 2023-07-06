using Flickr.Net.Core.Internals.Extensions;

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

        parameters.AppendIf("comment", comment, x => !string.IsNullOrEmpty(x), x => x);

        await GetResponseAsync(parameters, cancellationToken);
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

        parameters.AppendIf("primary_photo_id", primaryPhotoId, x => !string.IsNullOrEmpty(x), x => x);

        await GetResponseAsync(parameters, cancellationToken);
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

        parameters.AppendIf("description", description, x => !string.IsNullOrEmpty(x), x => x);

        await GetResponseAsync(parameters, cancellationToken);
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

        await GetResponseAsync(parameters, cancellationToken);
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

        await GetResponseAsync(parameters, cancellationToken);
    }

    async Task<GalleryInfo> IFlickrGalleries.GetInfoAsync(string galleryId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.galleries.getInfo" },
            { "gallery_id", galleryId }
        };

        return await GetResponseAsync<GalleryInfo>(parameters, cancellationToken);
    }

    async Task<Galleries> IFlickrGalleries.GetListAsync(string userId, int page, int perPage, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.galleries.getList" }
        };

        parameters.AppendIf("user_id", userId, x => x != null, x => x);

        parameters.AppendIf("per_page", perPage, x => x > 0, x => x.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("page", page, x => x > 0, x => x.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        return await GetResponseAsync<UserGalleries>(parameters, cancellationToken);
    }

    async Task<Galleries> IFlickrGalleries.GetListForPhotoAsync(string photoId, int page, int perPage, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.galleries.getListForPhoto" },
            { "photo_id", photoId }
        };

        parameters.AppendIf("per_page", perPage, x => x > 0, x => x.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("page", page, x => x > 0, x => x.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        return await GetResponseAsync<PhotoGalleries>(parameters, cancellationToken);
    }

    async Task<GalleryPhotos> IFlickrGalleries.GetPhotosAsync(string galleryId, PhotoSearchExtras extras, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.galleries.getPhotos" },
            { "gallery_id", galleryId }
        };

        parameters.AppendIf("extras", extras, x => x != PhotoSearchExtras.None, x => x.ToFlickrString());

        return await GetResponseAsync<GalleryPhotos>(parameters, cancellationToken);
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

        await GetResponseAsync(parameters, cancellationToken);
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
    Task<GalleryInfo> GetInfoAsync(string galleryId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a list of galleries for the specified user.
    /// </summary>
    /// <param name="userId">The user to return the galleries for.</param>
    /// <param name="page"></param>
    /// <param name="perPage"></param>
    /// <param name="cancellationToken"></param>
    /// <return><see cref="UserGalleries"/></return>
    Task<Galleries> GetListAsync(string userId, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

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
    /// <return><see cref="PhotoGalleries"/></return>
    Task<Galleries> GetListForPhotoAsync(string photoId, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

    /// <summary>
    /// Return the list of photos for a gallery.
    /// </summary>
    /// <param name="galleryId">The ID of the gallery of photos to return.</param>
    /// <param name="extras">A list of extra information to fetch for each returned record.</param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task<GalleryPhotos> GetPhotosAsync(string galleryId, PhotoSearchExtras extras = PhotoSearchExtras.None, CancellationToken cancellationToken = default);

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