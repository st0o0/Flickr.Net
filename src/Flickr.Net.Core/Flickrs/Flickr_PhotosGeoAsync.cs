using FlickrNet.Core.SearchOptions;

namespace FlickrNet.Core;

public partial class Flickr
{
    /// <summary>
    /// Correct the places hierarchy for all the photos for a user at a given latitude, longitude and accuracy.
    /// </summary>
    /// <remarks>
    /// Batch corrections are processed in a delayed queue so it may take a few minutes before the changes are reflected in a user's photos.
    /// </remarks>
    /// <param name="latitude">The latitude of the photos to be update whose valid range is -90 to 90. Anything more than 6 decimal places will be truncated.</param>
    /// <param name="longitude">The longitude of the photos to be updated whose valid range is -180 to 180. Anything more than 6 decimal places will be truncated.</param>
    /// <param name="accuracy">Recorded accuracy level of the photos to be updated.
    /// World level is 1, Country is ~3, Region ~6, City ~11, Street ~16. Current range is 1-16.
    /// Defaults to 16 if not specified.</param>
    /// <param name="placeId">A Flickr Places ID. (While optional, you must pass either a valid Places ID or a WOE ID.)</param>
    /// <param name="woeId">A Where On Earth (WOE) ID. (While optional, you must pass either a valid Places ID or a WOE ID.)</param>
    public async Task PhotosGeoBatchCorrectLocationAsync(double latitude, double longitude, GeoAccuracy accuracy, string placeId, string woeId, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.geo.batchCorrectLocation" },
            { "lat", latitude.ToString(System.Globalization.NumberFormatInfo.InvariantInfo) },
            { "lon", longitude.ToString(System.Globalization.NumberFormatInfo.InvariantInfo) },
            { "accuracy", accuracy.ToString("D") },
            { "place_id", placeId },
            { "woe_id", woeId }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Correct the places hierarchy for a given photo.
    /// </summary>
    /// <param name="photoId">The ID of the photo whose WOE location is being corrected.</param>
    /// <param name="placeId">A Flickr Places ID. (While optional, you must pass either a valid Places ID or a WOE ID.)</param>
    /// <param name="woeId">A Where On Earth (WOE) ID. (While optional, you must pass either a valid Places ID or a WOE ID.)</param>
    public async Task PhotosGeoCorrectLocationAsync(string photoId, string placeId, string woeId, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.geo.correctLocation" },
            { "photo_id", photoId },
            { "place_id", placeId },
            { "woe_id", woeId }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Returns the location data for a give photo.
    /// </summary>
    /// <param name="photoId">The ID of the photo to return the location information for.</param>
    public async Task<PlaceInfo> PhotosGeoGetLocationAsync(string photoId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.geo.getLocation" },
            { "photo_id", photoId }
        };

        PhotoInfo result = await GetResponseAsync<PhotoInfo>(parameters, cancellationToken);
        return result.Location;
    }

    /// <summary>
    /// Indicate the state of a photo's geotagginess beyond latitude and longitude.
    /// </summary>
    /// <remarks>
    /// Note : photos passed to this method must already be geotagged (using the flickr.photos.geo.setLocation method).
    /// </remarks>
    /// <param name="photoId">The id of the photo to set context data for.</param>
    /// <param name="context">Context is a numeric value representing the photo's geotagginess beyond latitude and longitude.
    /// For example, you may wish to indicate that a photo was taken "indoors" or "outdoors". </param>
    public async Task PhotosGeoSetContextAsync(string photoId, GeoContext context, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.geo.setContext" },
            { "photo_id", photoId },
            { "context", context.ToString("D") }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Sets the geo location for a photo.
    /// </summary>
    /// <param name="photoId">The ID of the photo to set to location for.</param>
    /// <param name="latitude">The latitude of the geo location. A double number ranging from -180.00 to 180.00. Digits beyond 6 decimal places will be truncated.</param>
    /// <param name="longitude">The longitude of the geo location. A double number ranging from -180.00 to 180.00. Digits beyond 6 decimal places will be truncated.</param>
    public async Task PhotosGeoSetLocationAsync(string photoId, double latitude, double longitude, CancellationToken cancellationToken = default)
    {
        await PhotosGeoSetLocationAsync(photoId, latitude, longitude, GeoAccuracy.None, cancellationToken);
    }

    /// <summary>
    /// Sets the geo location for a photo.
    /// </summary>
    /// <param name="photoId">The ID of the photo to set to location for.</param>
    /// <param name="latitude">The latitude of the geo location. A double number ranging from -180.00 to 180.00. Digits beyond 6 decimal places will be truncated.</param>
    /// <param name="longitude">The longitude of the geo location. A double number ranging from -180.00 to 180.00. Digits beyond 6 decimal places will be truncated.</param>
    /// <param name="accuracy">The accuracy of the photos geo location.</param>
    public async Task PhotosGeoSetLocationAsync(string photoId, double latitude, double longitude, GeoAccuracy accuracy, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.geo.setLocation" },
            { "photo_id", photoId },
            { "lat", latitude.ToString(System.Globalization.NumberFormatInfo.InvariantInfo) },
            { "lon", longitude.ToString(System.Globalization.NumberFormatInfo.InvariantInfo) }
        };
        if (accuracy != GeoAccuracy.None)
        {
            parameters.Add("accuracy", accuracy.ToString("D"));
        }

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Return a list of photos for a user at a specific latitude, longitude and accuracy.
    /// </summary>
    /// <param name="latitude">The latitude whose valid range is -90 to 90. Anything more than 6 decimal places will be truncated.</param>
    /// <param name="longitude">The longitude whose valid range is -180 to 180. Anything more than 6 decimal places will be truncated.</param>
    /// <param name="accuracy">Recorded accuracy level of the location information.
    /// World level is 1, Country is ~3, Region ~6, City ~11, Street ~16. Current range is 1-16.
    /// Defaults to 16 if not specified.</param>
    /// <param name="extras"></param>
    /// <param name="perPage">Number of photos to return per page. If this argument is omitted, it defaults to 100.
    /// The maximum allowed value is 500.</param>
    /// <param name="page">The page of results to return. If this argument is omitted, it defaults to 1.</param>
    public async Task<PhotoCollection> PhotosGeoPhotosForLocationAsync(double latitude, double longitude, GeoAccuracy accuracy, PhotoSearchExtras extras, int perPage, int page, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.geo.photosForLocation" },
            { "lat", latitude.ToString(System.Globalization.NumberFormatInfo.InvariantInfo) },
            { "lon", longitude.ToString(System.Globalization.NumberFormatInfo.InvariantInfo) },
            { "accuracy", accuracy.ToString("D") }
        };
        if (extras != PhotoSearchExtras.None)
        {
            parameters.Add("extras", UtilityMethods.ExtrasToString(extras));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<PhotoCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Removes Location information.
    /// </summary>
    /// <param name="photoId">The photo ID of the photo to remove information from.</param>
    public async Task PhotosGeoRemoveLocationAsync(string photoId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.geo.removeLocation" },
            { "photo_id", photoId }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Gets a list of photos that do not contain geo location information.
    /// </summary>
    /// <param name="callback">Callback method to call upon return of the response from Flickr.</param>
    public async Task<PhotoCollection> PhotosGetWithoutGeoDataAsync(CancellationToken cancellationToken = default)
    {
        PartialSearchOptions options = new();
        return await PhotosGetWithoutGeoDataAsync(options, cancellationToken);
    }

    /// <summary>
    /// Gets a list of photos that do not contain geo location information.
    /// </summary>
    /// <param name="options">A limited set of options are supported.</param>
    public async Task<PhotoCollection> PhotosGetWithoutGeoDataAsync(PartialSearchOptions options, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.getWithoutGeoData" }
        };
        UtilityMethods.PartialOptionsIntoArray(options, parameters);

        return await GetResponseAsync<PhotoCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Gets a list of photos that contain geo location information.
    /// </summary>
    /// <remarks>
    /// Note, this method doesn't actually return the location information with the photos,
    /// unless you specify the <see cref="PhotoSearchExtras.Geo"/> option in the <c>extras</c> parameter.
    /// </remarks>
    public async Task<PhotoCollection> PhotosGetWithGeoDataAsync(CancellationToken cancellationToken = default)
    {
        PartialSearchOptions options = new();
        return await PhotosGetWithGeoDataAsync(options, cancellationToken);
    }

    /// <summary>
    /// Gets a list of photos that contain geo location information.
    /// </summary>
    /// <remarks>
    /// Note, this method doesn't actually return the location information with the photos,
    /// unless you specify the <see cref="PhotoSearchExtras.Geo"/> option in the <c>extras</c> parameter.
    /// </remarks>
    /// <param name="options">The options to filter/sort the results by.</param>
    public async Task<PhotoCollection> PhotosGetWithGeoDataAsync(PartialSearchOptions options, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.getWithGeoData" }
        };
        UtilityMethods.PartialOptionsIntoArray(options, parameters);

        return await GetResponseAsync<PhotoCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Get permissions for a photo.
    /// </summary>
    /// <param name="photoId">The id of the photo to get permissions for.</param>
    public async Task<GeoPermissions> PhotosGeoGetPermsAsync(string photoId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.geo.getPerms" },
            { "photo_id", photoId }
        };

        return await GetResponseAsync<GeoPermissions>(parameters, cancellationToken);
    }

    /// <summary>
    /// Set the permission for who can see geotagged photos on Flickr.
    /// </summary>
    /// <param name="photoId">The ID of the photo permissions to update.</param>
    /// <param name="isPublic"></param>
    /// <param name="isContact"></param>
    /// <param name="isFamily"></param>
    /// <param name="isFriend"></param>
    public async Task PhotosGeoSetPermsAsync(string photoId, bool isPublic, bool isContact, bool isFamily, bool isFriend, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.geo.setPerms" },
            { "photo_id", photoId },
            { "is_public", isPublic ? "1" : "0" },
            { "is_contact", isContact ? "1" : "0" },
            { "is_friend", isFriend ? "1" : "0" },
            { "is_family", isFamily ? "1" : "0" }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }
}