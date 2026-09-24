using System.Globalization;
using Flickr.Net.Internals.Extensions;

namespace Flickr.Net;

/// <summary>
/// Flickr Places API implementation.
/// </summary>
public sealed partial class FlickrClient : IFlickrPlaces
{
    async Task<Places> IFlickrPlaces.FindAsync(string query, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.places.find" },
            { "query", query }
        };

        return await GetResponseAsync<Places>(parameters, cancellationToken).ConfigureAwait(false);
    }

    async Task<Places> IFlickrPlaces.FindByLatLonAsync(double lat, double lon, int? accuracy, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.places.findByLatLon" },
            { "lat", lat.ToString(CultureInfo.InvariantCulture) },
            { "lon", lon.ToString(CultureInfo.InvariantCulture) }
        };

        parameters.AppendIf("accuracy", accuracy, x => x is > 0, x => x!.Value.ToString(NumberFormatInfo.InvariantInfo));

        return await GetResponseAsync<Places>(parameters, cancellationToken).ConfigureAwait(false);
    }

    async Task<Place> IFlickrPlaces.GetInfoAsync(string placeId, string? woeId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.places.getInfo" }
        };

        parameters.AppendIf("place_id", placeId, x => !string.IsNullOrEmpty(x), x => x);
        parameters.AppendIf("woe_id", woeId, x => !string.IsNullOrEmpty(x), x => x!);

        return await GetResponseAsync<Place>(parameters, cancellationToken).ConfigureAwait(false);
    }

    async Task<Place> IFlickrPlaces.GetInfoByUrlAsync(string url, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.places.getInfoByUrl" },
            { "url", url }
        };

        return await GetResponseAsync<Place>(parameters, cancellationToken).ConfigureAwait(false);
    }

    async Task<Place> IFlickrPlaces.ResolvePlaceIdAsync(string placeId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.places.resolvePlaceId" },
            { "place_id", placeId }
        };

        return await GetResponseAsync<Place>(parameters, cancellationToken).ConfigureAwait(false);
    }

    async Task<Place> IFlickrPlaces.ResolvePlaceUrlAsync(string url, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.places.resolvePlaceURL" },
            { "url", url }
        };

        return await GetResponseAsync<Place>(parameters, cancellationToken).ConfigureAwait(false);
    }

    async Task<Places> IFlickrPlaces.GetChildrenWithPhotosPublicAsync(string? placeId, string? woeId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.places.getChildrenWithPhotosPublic" }
        };

        parameters.AppendIf("place_id", placeId, x => !string.IsNullOrEmpty(x), x => x!);
        parameters.AppendIf("woe_id", woeId, x => !string.IsNullOrEmpty(x), x => x!);

        return await GetResponseAsync<Places>(parameters, cancellationToken).ConfigureAwait(false);
    }

    async Task<PlaceTypes> IFlickrPlaces.GetPlaceTypesAsync(CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.places.getPlaceTypes" }
        };

        return await GetResponseAsync<PlaceTypes>(parameters, cancellationToken).ConfigureAwait(false);
    }

    async Task<ShapeHistory> IFlickrPlaces.GetShapeHistoryAsync(string? placeId, string? woeId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.places.getShapeHistory" }
        };

        parameters.AppendIf("place_id", placeId, x => !string.IsNullOrEmpty(x), x => x!);
        parameters.AppendIf("woe_id", woeId, x => !string.IsNullOrEmpty(x), x => x!);

        return await GetResponseAsync<ShapeHistory>(parameters, cancellationToken).ConfigureAwait(false);
    }

    async Task<Places> IFlickrPlaces.GetTopPlacesListAsync(int placeTypeId, string? date, string? woeId, string? placeId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.places.getTopPlacesList" },
            { "place_type_id", placeTypeId.ToString(NumberFormatInfo.InvariantInfo) }
        };

        parameters.AppendIf("date", date, x => !string.IsNullOrEmpty(x), x => x!);
        parameters.AppendIf("woe_id", woeId, x => !string.IsNullOrEmpty(x), x => x!);
        parameters.AppendIf("place_id", placeId, x => !string.IsNullOrEmpty(x), x => x!);

        return await GetResponseAsync<Places>(parameters, cancellationToken).ConfigureAwait(false);
    }

    async Task<Places> IFlickrPlaces.PlacesForBoundingBoxAsync(double minLon, double minLat, double maxLon, double maxLat, int? placeTypeId, CancellationToken cancellationToken)
    {
        var bbox = string.Format(CultureInfo.InvariantCulture, "{0},{1},{2},{3}", minLon, minLat, maxLon, maxLat);

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.places.placesForBoundingBox" },
            { "bbox", bbox }
        };

        parameters.AppendIf("place_type_id", placeTypeId, x => x is > 0, x => x!.Value.ToString(NumberFormatInfo.InvariantInfo));

        return await GetResponseAsync<Places>(parameters, cancellationToken).ConfigureAwait(false);
    }

    async Task<Places> IFlickrPlaces.PlacesForContactsAsync(int? placeTypeId, string? woeId, string? placeId, int? threshold, string? minUploadDate, string? maxUploadDate, string? minTakenDate, string? maxTakenDate, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.places.placesForContacts" }
        };

        parameters.AppendIf("place_type_id", placeTypeId, x => x is > 0, x => x!.Value.ToString(NumberFormatInfo.InvariantInfo));
        parameters.AppendIf("woe_id", woeId, x => !string.IsNullOrEmpty(x), x => x!);
        parameters.AppendIf("place_id", placeId, x => !string.IsNullOrEmpty(x), x => x!);
        parameters.AppendIf("threshold", threshold, x => x is > 0, x => x!.Value.ToString(NumberFormatInfo.InvariantInfo));
        parameters.AppendIf("min_upload_date", minUploadDate, x => !string.IsNullOrEmpty(x), x => x!);
        parameters.AppendIf("max_upload_date", maxUploadDate, x => !string.IsNullOrEmpty(x), x => x!);
        parameters.AppendIf("min_taken_date", minTakenDate, x => !string.IsNullOrEmpty(x), x => x!);
        parameters.AppendIf("max_taken_date", maxTakenDate, x => !string.IsNullOrEmpty(x), x => x!);

        return await GetResponseAsync<Places>(parameters, cancellationToken).ConfigureAwait(false);
    }

    async Task<Places> IFlickrPlaces.PlacesForTagsAsync(int placeTypeId, string? woeId, string? placeId, int? threshold, string? tags, string? tagMode, string? machineTags, string? machineTagMode, string? minUploadDate, string? maxUploadDate, string? minTakenDate, string? maxTakenDate, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.places.placesForTags" },
            { "place_type_id", placeTypeId.ToString(NumberFormatInfo.InvariantInfo) }
        };

        parameters.AppendIf("woe_id", woeId, x => !string.IsNullOrEmpty(x), x => x!);
        parameters.AppendIf("place_id", placeId, x => !string.IsNullOrEmpty(x), x => x!);
        parameters.AppendIf("threshold", threshold, x => x is > 0, x => x!.Value.ToString(NumberFormatInfo.InvariantInfo));
        parameters.AppendIf("tags", tags, x => !string.IsNullOrEmpty(x), x => x!);
        parameters.AppendIf("tag_mode", tagMode, x => !string.IsNullOrEmpty(x), x => x!);
        parameters.AppendIf("machine_tags", machineTags, x => !string.IsNullOrEmpty(x), x => x!);
        parameters.AppendIf("machine_tag_mode", machineTagMode, x => !string.IsNullOrEmpty(x), x => x!);
        parameters.AppendIf("min_upload_date", minUploadDate, x => !string.IsNullOrEmpty(x), x => x!);
        parameters.AppendIf("max_upload_date", maxUploadDate, x => !string.IsNullOrEmpty(x), x => x!);
        parameters.AppendIf("min_taken_date", minTakenDate, x => !string.IsNullOrEmpty(x), x => x!);
        parameters.AppendIf("max_taken_date", maxTakenDate, x => !string.IsNullOrEmpty(x), x => x!);

        return await GetResponseAsync<Places>(parameters, cancellationToken).ConfigureAwait(false);
    }

    async Task<Places> IFlickrPlaces.PlacesForUserAsync(int? placeTypeId, string? woeId, string? placeId, int? threshold, string? minUploadDate, string? maxUploadDate, string? minTakenDate, string? maxTakenDate, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.places.placesForUser" }
        };

        parameters.AppendIf("place_type_id", placeTypeId, x => x is > 0, x => x!.Value.ToString(NumberFormatInfo.InvariantInfo));
        parameters.AppendIf("woe_id", woeId, x => !string.IsNullOrEmpty(x), x => x!);
        parameters.AppendIf("place_id", placeId, x => !string.IsNullOrEmpty(x), x => x!);
        parameters.AppendIf("threshold", threshold, x => x is > 0, x => x!.Value.ToString(NumberFormatInfo.InvariantInfo));
        parameters.AppendIf("min_upload_date", minUploadDate, x => !string.IsNullOrEmpty(x), x => x!);
        parameters.AppendIf("max_upload_date", maxUploadDate, x => !string.IsNullOrEmpty(x), x => x!);
        parameters.AppendIf("min_taken_date", minTakenDate, x => !string.IsNullOrEmpty(x), x => x!);
        parameters.AppendIf("max_taken_date", maxTakenDate, x => !string.IsNullOrEmpty(x), x => x!);

        return await GetResponseAsync<Places>(parameters, cancellationToken).ConfigureAwait(false);
    }

    async Task<PlaceTags> IFlickrPlaces.TagsForPlaceAsync(string? woeId, string? placeId, string? minUploadDate, string? maxUploadDate, string? minTakenDate, string? maxTakenDate, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.places.tagsForPlace" }
        };

        parameters.AppendIf("woe_id", woeId, x => !string.IsNullOrEmpty(x), x => x!);
        parameters.AppendIf("place_id", placeId, x => !string.IsNullOrEmpty(x), x => x!);
        parameters.AppendIf("min_upload_date", minUploadDate, x => !string.IsNullOrEmpty(x), x => x!);
        parameters.AppendIf("max_upload_date", maxUploadDate, x => !string.IsNullOrEmpty(x), x => x!);
        parameters.AppendIf("min_taken_date", minTakenDate, x => !string.IsNullOrEmpty(x), x => x!);
        parameters.AppendIf("max_taken_date", maxTakenDate, x => !string.IsNullOrEmpty(x), x => x!);

        return await GetResponseAsync<PlaceTags>(parameters, cancellationToken).ConfigureAwait(false);
    }
}

/// <summary>
/// Interface for Flickr Places API methods for geographic place lookups and searches.
/// </summary>
public interface IFlickrPlaces
{
    /// <summary>
    /// Return a list of places matching a given text query.
    /// </summary>
    /// <param name="query">The text query to search for.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A collection of matching places.</returns>
    Task<Places> FindAsync(string query, CancellationToken cancellationToken = default);

    /// <summary>
    /// Return a list of places near the given latitude and longitude.
    /// </summary>
    /// <param name="lat">The latitude.</param>
    /// <param name="lon">The longitude.</param>
    /// <param name="accuracy">The accuracy level (1-16, default 16 = street level).</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A collection of nearby places.</returns>
    Task<Places> FindByLatLonAsync(double lat, double lon, int? accuracy = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get information about a place.
    /// </summary>
    /// <param name="placeId">The Flickr place ID.</param>
    /// <param name="woeId">The Where On Earth ID (alternative to placeId).</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Detailed place information.</returns>
    Task<Place> GetInfoAsync(string placeId, string? woeId = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Lookup information about a place by its Flickr Places URL.
    /// </summary>
    /// <param name="url">The Flickr Places URL.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Detailed place information.</returns>
    Task<Place> GetInfoByUrlAsync(string url, CancellationToken cancellationToken = default);

    /// <summary>
    /// Find Flickr places information by place ID.
    /// </summary>
    /// <param name="placeId">The Flickr place ID to resolve.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The resolved place location.</returns>
    Task<Place> ResolvePlaceIdAsync(string placeId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Find Flickr places information by place URL.
    /// </summary>
    /// <param name="url">The Flickr Places URL to resolve.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The resolved place location.</returns>
    Task<Place> ResolvePlaceUrlAsync(string url, CancellationToken cancellationToken = default);

    /// <summary>
    /// Return a list of children places that have public photos.
    /// </summary>
    /// <param name="placeId">The Flickr place ID (provide placeId or woeId).</param>
    /// <param name="woeId">The WOE ID (provide placeId or woeId).</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A collection of child places with public photos.</returns>
    Task<Places> GetChildrenWithPhotosPublicAsync(string? placeId = null, string? woeId = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetches a list of available place types.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A collection of available place types.</returns>
    Task<PlaceTypes> GetPlaceTypesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Return the historical shape data for a place.
    /// </summary>
    /// <param name="placeId">The Flickr place ID (provide placeId or woeId).</param>
    /// <param name="woeId">The WOE ID (provide placeId or woeId).</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A collection of shape data entries.</returns>
    Task<ShapeHistory> GetShapeHistoryAsync(string? placeId = null, string? woeId = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Return the top places for a given place type.
    /// </summary>
    /// <param name="placeTypeId">The numeric place type ID (e.g. 7=locality, 8=region, 12=country).</param>
    /// <param name="date">The date to restrict results to (format YYYY-MM-DD).</param>
    /// <param name="woeId">Limit results to places within this WOE ID.</param>
    /// <param name="placeId">Limit results to places within this Flickr place ID.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A collection of top places.</returns>
    Task<Places> GetTopPlacesListAsync(int placeTypeId, string? date = null, string? woeId = null, string? placeId = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Return places within a bounding box.
    /// </summary>
    /// <param name="minLon">Minimum longitude (west).</param>
    /// <param name="minLat">Minimum latitude (south).</param>
    /// <param name="maxLon">Maximum longitude (east).</param>
    /// <param name="maxLat">Maximum latitude (north).</param>
    /// <param name="placeTypeId">The place type ID to filter by.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A collection of places within the bounding box.</returns>
    Task<Places> PlacesForBoundingBoxAsync(double minLon, double minLat, double maxLon, double maxLat, int? placeTypeId = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Return a list of the top places where contacts' photos were taken. Requires authentication.
    /// </summary>
    /// <param name="placeTypeId">The place type ID.</param>
    /// <param name="woeId">Limit to places within this WOE ID.</param>
    /// <param name="placeId">Limit to places within this Flickr place ID.</param>
    /// <param name="threshold">Minimum number of photos a place must have.</param>
    /// <param name="minUploadDate">Minimum upload date (Unix timestamp or MySQL datetime).</param>
    /// <param name="maxUploadDate">Maximum upload date.</param>
    /// <param name="minTakenDate">Minimum taken date (MySQL datetime).</param>
    /// <param name="maxTakenDate">Maximum taken date.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A collection of places.</returns>
    Task<Places> PlacesForContactsAsync(int? placeTypeId = null, string? woeId = null, string? placeId = null, int? threshold = null, string? minUploadDate = null, string? maxUploadDate = null, string? minTakenDate = null, string? maxTakenDate = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Return a list of places where photos with the given tags were taken.
    /// </summary>
    /// <param name="placeTypeId">The place type ID (required).</param>
    /// <param name="woeId">Limit to places within this WOE ID.</param>
    /// <param name="placeId">Limit to places within this Flickr place ID.</param>
    /// <param name="threshold">Minimum number of photos a place must have.</param>
    /// <param name="tags">Comma-delimited list of tags.</param>
    /// <param name="tagMode">Tag matching mode: 'any' or 'all'.</param>
    /// <param name="machineTags">Comma-delimited list of machine tags.</param>
    /// <param name="machineTagMode">Machine tag matching mode: 'any' or 'all'.</param>
    /// <param name="minUploadDate">Minimum upload date.</param>
    /// <param name="maxUploadDate">Maximum upload date.</param>
    /// <param name="minTakenDate">Minimum taken date.</param>
    /// <param name="maxTakenDate">Maximum taken date.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A collection of places.</returns>
    Task<Places> PlacesForTagsAsync(int placeTypeId, string? woeId = null, string? placeId = null, int? threshold = null, string? tags = null, string? tagMode = null, string? machineTags = null, string? machineTagMode = null, string? minUploadDate = null, string? maxUploadDate = null, string? minTakenDate = null, string? maxTakenDate = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Return a list of the top places where the authenticated user's photos were taken. Requires authentication.
    /// </summary>
    /// <param name="placeTypeId">The place type ID.</param>
    /// <param name="woeId">Limit to places within this WOE ID.</param>
    /// <param name="placeId">Limit to places within this Flickr place ID.</param>
    /// <param name="threshold">Minimum number of photos a place must have.</param>
    /// <param name="minUploadDate">Minimum upload date.</param>
    /// <param name="maxUploadDate">Maximum upload date.</param>
    /// <param name="minTakenDate">Minimum taken date.</param>
    /// <param name="maxTakenDate">Maximum taken date.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A collection of places.</returns>
    Task<Places> PlacesForUserAsync(int? placeTypeId = null, string? woeId = null, string? placeId = null, int? threshold = null, string? minUploadDate = null, string? maxUploadDate = null, string? minTakenDate = null, string? maxTakenDate = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Return a list of the most frequently used tags for a place.
    /// </summary>
    /// <param name="woeId">The WOE ID (provide woeId or placeId).</param>
    /// <param name="placeId">The Flickr place ID (provide woeId or placeId).</param>
    /// <param name="minUploadDate">Minimum upload date.</param>
    /// <param name="maxUploadDate">Maximum upload date.</param>
    /// <param name="minTakenDate">Minimum taken date.</param>
    /// <param name="maxTakenDate">Maximum taken date.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A collection of tags for the place.</returns>
    Task<PlaceTags> TagsForPlaceAsync(string? woeId = null, string? placeId = null, string? minUploadDate = null, string? maxUploadDate = null, string? minTakenDate = null, string? maxTakenDate = null, CancellationToken cancellationToken = default);
}
