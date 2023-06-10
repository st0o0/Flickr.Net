namespace Flickr.Net.Core;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrPhotosGeo
{
    async Task IFlickrPhotosGeo.BatchCorrectLocationAsync(double latitude, double longitude, GeoAccuracy accuracy, string placeId, string woeId, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.geo.batchCorrectLocation" },
            { "lat", latitude.ToString(System.Globalization.NumberFormatInfo.InvariantInfo) },
            { "lon", longitude.ToString(System.Globalization.NumberFormatInfo.InvariantInfo) },
            { "accuracy", accuracy.ToString("D") }
        };

        if (!string.IsNullOrEmpty(placeId))
        {
            parameters.Add("place_id", placeId);
        }

        if (!string.IsNullOrEmpty(woeId))
        {
            parameters.Add("woe_id", woeId);
        }

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    async Task IFlickrPhotosGeo.CorrectLocationAsync(string photoId, string placeId, string woeId, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.geo.correctLocation" },
            { "photo_id", photoId }
        };

        if (!string.IsNullOrEmpty(placeId))
        {
            parameters.Add("place_id", placeId);
        }

        if (!string.IsNullOrEmpty(woeId))
        {
            parameters.Add("woe_id", woeId);
        }

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    async Task<PlaceInfo> IFlickrPhotosGeo.GetLocationAsync(string photoId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.geo.getLocation" },
            { "photo_id", photoId }
        };

        PhotoInfo result = await GetResponseAsync<PhotoInfo>(parameters, cancellationToken);
        return result.Location;
    }

    async Task<GeoPermissions> IFlickrPhotosGeo.GetPermsAsync(string photoId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.geo.getPerms" },
            { "photo_id", photoId }
        };

        return await GetResponseAsync<GeoPermissions>(parameters, cancellationToken);
    }

    async Task<PhotoCollection> IFlickrPhotosGeo.PhotosForLocationAsync(double latitude, double longitude, GeoAccuracy accuracy, PhotoSearchExtras extras, int perPage, int page, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.geo.photosForLocation" },
            { "lat", latitude.ToString(System.Globalization.NumberFormatInfo.InvariantInfo) },
            { "lon", longitude.ToString(System.Globalization.NumberFormatInfo.InvariantInfo) }
        };

        if (accuracy != GeoAccuracy.None)
        {
            parameters.Add("accuracy", accuracy.ToString("D"));
        }

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

    async Task IFlickrPhotosGeo.RemoveLocationAsync(string photoId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.geo.removeLocation" },
            { "photo_id", photoId }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    async Task IFlickrPhotosGeo.SetContextAsync(string photoId, GeoContext context, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.geo.setContext" },
            { "photo_id", photoId },
            { "context", context.ToString("D") }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    async Task IFlickrPhotosGeo.SetLocationAsync(string photoId, double latitude, double longitude, GeoAccuracy accuracy, CancellationToken cancellationToken)
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

    async Task IFlickrPhotosGeo.SetPermsAsync(string photoId, bool isPublic, bool isContact, bool isFamily, bool isFriend, CancellationToken cancellationToken)
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

/// <summary>
/// The flickr photos geo.
/// </summary>
public interface IFlickrPhotosGeo
{
    /// <summary>
    /// Correct the places hierarchy for all the photos for a user at a given latitude, longitude
    /// and accuracy.
    /// </summary>
    /// <remarks>
    /// Batch corrections are processed in a delayed queue so it may take a few minutes before the
    /// changes are reflected in a user's photos.
    /// </remarks>
    /// <param name="latitude">
    /// The latitude of the photos to be update whose valid range is -90 to 90. Anything more than 6
    /// decimal places will be truncated.
    /// </param>
    /// <param name="longitude">
    /// The longitude of the photos to be updated whose valid range is -180 to 180. Anything more
    /// than 6 decimal places will be truncated.
    /// </param>
    /// <param name="accuracy">
    /// Recorded accuracy level of the photos to be updated. World level is 1, Country is ~3, Region
    /// ~6, City ~11, Street ~16. Current range is 1-16. Defaults to 16 if not specified.
    /// </param>
    /// <param name="placeId">
    /// A Flickr Places ID. (While optional, you must pass either a valid Places ID or a WOE ID.)
    /// </param>
    /// <param name="woeId">
    /// A Where On Earth (WOE) ID. (While optional, you must pass either a valid Places ID or a WOE ID.)
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task BatchCorrectLocationAsync(double latitude, double longitude, GeoAccuracy accuracy, string placeId = null, string woeId = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Correct the places hierarchy for a given photo.
    /// </summary>
    /// <param name="photoId">The ID of the photo whose WOE location is being corrected.</param>
    /// <param name="placeId">
    /// A Flickr Places ID. (While optional, you must pass either a valid Places ID or a WOE ID.)
    /// </param>
    /// <param name="woeId">
    /// A Where On Earth (WOE) ID. (While optional, you must pass either a valid Places ID or a WOE ID.)
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task CorrectLocationAsync(string photoId, string placeId, string woeId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the location data for a give photo.
    /// </summary>
    /// <param name="photoId">The ID of the photo to return the location information for.</param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task<PlaceInfo> GetLocationAsync(string photoId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get permissions for a photo.
    /// </summary>
    /// <param name="photoId">The id of the photo to get permissions for.</param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task<GeoPermissions> GetPermsAsync(string photoId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Return a list of photos for a user at a specific latitude, longitude and accuracy.
    /// </summary>
    /// <param name="latitude">
    /// The latitude whose valid range is -90 to 90. Anything more than 6 decimal places will be truncated.
    /// </param>
    /// <param name="longitude">
    /// The longitude whose valid range is -180 to 180. Anything more than 6 decimal places will be truncated.
    /// </param>
    /// <param name="accuracy">
    /// Recorded accuracy level of the location information. World level is 1, Country is ~3, Region
    /// ~6, City ~11, Street ~16. Current range is 1-16. Defaults to 16 if not specified.
    /// </param>
    /// <param name="extras"></param>
    /// <param name="perPage">
    /// Number of photos to return per page. If this argument is omitted, it defaults to 100. The
    /// maximum allowed value is 500.
    /// </param>
    /// <param name="page">
    /// The page of results to return. If this argument is omitted, it defaults to 1.
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task<PhotoCollection> PhotosForLocationAsync(double latitude, double longitude, GeoAccuracy accuracy = GeoAccuracy.None, PhotoSearchExtras extras = PhotoSearchExtras.None, int perPage = 0, int page = 0, CancellationToken cancellationToken = default);

    /// <summary>
    /// Removes Location information.
    /// </summary>
    /// <param name="photoId">The photo ID of the photo to remove information from.</param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task RemoveLocationAsync(string photoId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Indicate the state of a photo's geotagginess beyond latitude and longitude.
    /// </summary>
    /// <remarks>
    /// Note : photos passed to this method must already be geotagged (using the
    /// flickr.photos.geo.setLocation method).
    /// </remarks>
    /// <param name="photoId">The id of the photo to set context data for.</param>
    /// <param name="context">
    /// Context is a numeric value representing the photo's geotagginess beyond latitude and
    /// longitude. For example, you may wish to indicate that a photo was taken "indoors" or "outdoors".
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task SetContextAsync(string photoId, GeoContext context, CancellationToken cancellationToken = default);

    /// <summary>
    /// Sets the geo location for a photo.
    /// </summary>
    /// <param name="photoId">The ID of the photo to set to location for.</param>
    /// <param name="latitude">
    /// The latitude of the geo location. A double number ranging from -180.00 to 180.00. Digits
    /// beyond 6 decimal places will be truncated.
    /// </param>
    /// <param name="longitude">
    /// The longitude of the geo location. A double number ranging from -180.00 to 180.00. Digits
    /// beyond 6 decimal places will be truncated.
    /// </param>
    /// <param name="accuracy">The accuracy of the photos geo location.</param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task SetLocationAsync(string photoId, double latitude, double longitude, GeoAccuracy accuracy = GeoAccuracy.None, CancellationToken cancellationToken = default);

    /// <summary>
    /// Set the permission for who can see geotagged photos on Flickr.
    /// </summary>
    /// <param name="photoId">The ID of the photo permissions to update.</param>
    /// <param name="isPublic"></param>
    /// <param name="isContact"></param>
    /// <param name="isFamily"></param>
    /// <param name="isFriend"></param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task SetPermsAsync(string photoId, bool isPublic, bool isContact, bool isFamily, bool isFriend, CancellationToken cancellationToken = default);
}