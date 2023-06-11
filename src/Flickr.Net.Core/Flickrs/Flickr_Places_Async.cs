using Flickr.Net.Core.Exceptions;
using Flickr.Net.Core.Internals.Extensions;

namespace Flickr.Net.Core;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrPlaces
{
    async Task<PlaceCollection> IFlickrPlaces.FindAsync(string query, CancellationToken cancellationToken)
    {
        if (query == null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.places.find" },
            { "query", query }
        };

        return await GetResponseAsync<PlaceCollection>(parameters, cancellationToken);
    }

    async Task<Place> IFlickrPlaces.FindByLatLonAsync(double latitude, double longitude, GeoAccuracy accuracy, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.places.findByLatLon" },
            { "lat", latitude.ToString(System.Globalization.NumberFormatInfo.InvariantInfo) },
            { "lon", longitude.ToString(System.Globalization.NumberFormatInfo.InvariantInfo) }
        };

        if (accuracy != GeoAccuracy.None)
        {
            parameters.Add("accuracy", ((int)accuracy).ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        PlaceCollection result = await GetResponseAsync<PlaceCollection>(parameters, cancellationToken);
        return result[0];
    }

    async Task<PlaceCollection> IFlickrPlaces.GetChildrenWithPhotosPublicAsync(string placeId, string woeId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.places.getChildrenWithPhotosPublic" }
        };

        if ((placeId == null || placeId.Length == 0) && (woeId == null || woeId.Length == 0))
        {
            throw new FlickrException("Both placeId and woeId cannot be null or empty.");
        }

        if (!string.IsNullOrEmpty(placeId))
        {
            parameters.Add("place_id", placeId);
        }

        if (!string.IsNullOrEmpty(woeId))
        {
            parameters.Add("woe_id", woeId);
        }

        return await GetResponseAsync<PlaceCollection>(parameters, cancellationToken);
    }

    async Task<PlaceInfo> IFlickrPlaces.GetInfoAsync(string placeId, string woeId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.places.getInfo" }
        };

        if (string.IsNullOrEmpty(placeId) && string.IsNullOrEmpty(woeId))
        {
            throw new FlickrException("Both placeId and woeId cannot be null or empty.");
        }

        if (!string.IsNullOrEmpty(placeId))
        {
            parameters.Add("place_id", placeId);
        }

        if (!string.IsNullOrEmpty(woeId))
        {
            parameters.Add("woe_id", woeId);
        }

        return await GetResponseAsync<PlaceInfo>(parameters, cancellationToken);
    }

    async Task<PlaceInfo> IFlickrPlaces.GetInfoByUrlAsync(string url, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.places.getInfoByUrl" },
            { "url", url }
        };

        return await GetResponseAsync<PlaceInfo>(parameters, cancellationToken);
    }

    async Task<PlaceTypeInfoCollection> IFlickrPlaces.GetPlaceTypesAsync(CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.places.getPlaceTypes" }
        };

        return await GetResponseAsync<PlaceTypeInfoCollection>(parameters, cancellationToken);
    }

    async Task<ShapeDataCollection> IFlickrPlaces.GetShapeHistoryAsync(string placeId, string woeId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.places.getShapeHistory" }
        };

        if (string.IsNullOrEmpty(placeId) && string.IsNullOrEmpty(woeId))
        {
            throw new FlickrException("Both placeId and woeId cannot be null or empty.");
        }

        if (!string.IsNullOrEmpty(placeId))
        {
            parameters.Add("place_id", placeId);
        }

        if (!string.IsNullOrEmpty(woeId))
        {
            parameters.Add("woe_id", woeId);
        }

        return await GetResponseAsync<ShapeDataCollection>(parameters, cancellationToken);
    }

    async Task<PlaceCollection> IFlickrPlaces.GetTopPlacesListAsync(PlaceType placeType, DateTime? date, string placeId, string woeId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.places.getTopPlacesList" },
            { "place_type_id", placeType.ToString("D") }
        };

        if (date.HasValue && date != DateTime.MinValue)
        {
            parameters.Add("date",
                           date.Value.ToString("yyyy-MM-dd", System.Globalization.DateTimeFormatInfo.InvariantInfo));
        }

        if (!string.IsNullOrEmpty(placeId))
        {
            parameters.Add("place_id", placeId);
        }

        if (!string.IsNullOrEmpty(woeId))
        {
            parameters.Add("woe_id", woeId);
        }

        return await GetResponseAsync<PlaceCollection>(parameters, cancellationToken);
    }

    async Task<PlaceCollection> IFlickrPlaces.PlacesForBoundingBoxAsync(BoundaryBox boundaryBox, PlaceType placeType, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.places.placesForBoundingBox" },
            { "place_type_id", placeType.ToString("D") },
            { "bbox", boundaryBox.ToString() }
        };

        return await GetResponseAsync<PlaceCollection>(parameters, cancellationToken);
    }

    async Task<PlaceCollection> IFlickrPlaces.PlacesForContactsAsync(PlaceType placeType, string woeId, string placeId, int threshold,
                                            ContactSearch contactType, DateTime? minUploadDate,
                                            DateTime? maxUploadDate, DateTime? minTakenDate, DateTime? maxTakenDate,
                                            CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.places.placesForContacts" },

            { "place_type_id", placeType.ToString("D") }
        };

        if (!string.IsNullOrEmpty(woeId))
        {
            parameters.Add("woe_id", woeId);
        }

        if (!string.IsNullOrEmpty(placeId))
        {
            parameters.Add("place_id", placeId);
        }

        if (threshold > 0)
        {
            parameters.Add("threshold", threshold.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (contactType != ContactSearch.None)
        {
            parameters.Add("contacts", (contactType == ContactSearch.AllContacts ? "all" : "ff"));
        }

        if (minUploadDate.HasValue && minUploadDate != DateTime.MinValue)
        {
            parameters.Add("min_upload_date", UtilityMethods.DateToUnixTimestamp(minUploadDate.Value));
        }

        if (maxUploadDate.HasValue && maxUploadDate != DateTime.MinValue)
        {
            parameters.Add("max_upload_date", UtilityMethods.DateToUnixTimestamp(maxUploadDate.Value));
        }

        if (minTakenDate.HasValue && minTakenDate != DateTime.MinValue)
        {
            parameters.Add("min_taken_date", UtilityMethods.DateToMySql(minTakenDate.Value));
        }

        if (maxTakenDate.HasValue && maxTakenDate != DateTime.MinValue)
        {
            parameters.Add("max_taken_date", UtilityMethods.DateToMySql(maxTakenDate.Value));
        }

        return await GetResponseAsync<PlaceCollection>(parameters, cancellationToken);
    }

    async Task<PlaceCollection> IFlickrPlaces.PlacesForTagsAsync(PlaceType placeType, string woeId, string placeId, int threshold,
                                            IEnumerable<string> tags, TagMode tagMode, IEnumerable<string> machineTags,
                                            MachineTagMode machineTagMode, DateTime? minUploadDate,
                                            DateTime? maxUploadDate, DateTime? minTakenDate, DateTime? maxTakenDate,
                                            CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.places.placesForTags" },
            { "place_type_id", placeType.ToString("D") }
        };

        if (!string.IsNullOrEmpty(woeId))
        {
            parameters.Add("woe_id", woeId);
        }

        if (!string.IsNullOrEmpty(placeId))
        {
            parameters.Add("place_id", placeId);
        }

        if (threshold > 0)
        {
            parameters.Add("threshold", threshold.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (tags != null && tags.Any())
        {
            parameters.Add("tags", string.Join(",", tags.ToArray()));
        }

        if (tagMode != TagMode.None)
        {
            parameters.Add("tag_mode", tagMode.ToFlickrString());
        }

        if (machineTags != null && machineTags.Any())
        {
            parameters.Add("machine_tags", string.Join(",", machineTags.ToArray()));
        }

        if (machineTagMode != MachineTagMode.None)
        {
            parameters.Add("machine_tag_mode", machineTagMode.ToFlickrString());
        }

        if (minTakenDate.HasValue && minTakenDate != DateTime.MinValue)
        {
            parameters.Add("min_taken_date", UtilityMethods.DateToMySql(minTakenDate.Value));
        }

        if (maxTakenDate.HasValue && maxTakenDate != DateTime.MinValue)
        {
            parameters.Add("max_taken_date", UtilityMethods.DateToMySql(maxTakenDate.Value));
        }

        if (minUploadDate.HasValue && minUploadDate != DateTime.MinValue)
        {
            parameters.Add("min_upload_date", UtilityMethods.DateToUnixTimestamp(minUploadDate.Value));
        }

        if (maxUploadDate.HasValue && maxUploadDate != DateTime.MinValue)
        {
            parameters.Add("max_upload_date", UtilityMethods.DateToUnixTimestamp(maxUploadDate.Value));
        }

        return await GetResponseAsync<PlaceCollection>(parameters, cancellationToken);
    }

    async Task<PlaceCollection> IFlickrPlaces.PlacesForUserAsync(PlaceType placeType, string woeId, string placeId, int threshold,
                                            DateTime? minUploadDate, DateTime? maxUploadDate, DateTime? minTakenDate, DateTime? maxTakenDate,
                                            CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.places.placesForUser" },
            { "place_type_id", placeType.ToString("D") }
        };

        if (!string.IsNullOrEmpty(woeId))
        {
            parameters.Add("woe_id", woeId);
        }

        if (!string.IsNullOrEmpty(placeId))
        {
            parameters.Add("place_id", placeId);
        }

        if (threshold > 0)
        {
            parameters.Add("threshold", threshold.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (minTakenDate.HasValue && minTakenDate != DateTime.MinValue)
        {
            parameters.Add("min_taken_date", UtilityMethods.DateToMySql(minTakenDate.Value));
        }

        if (maxTakenDate.HasValue && maxTakenDate != DateTime.MinValue)
        {
            parameters.Add("max_taken_date", UtilityMethods.DateToMySql(maxTakenDate.Value));
        }

        if (minUploadDate.HasValue && minUploadDate != DateTime.MinValue)
        {
            parameters.Add("min_upload_date", UtilityMethods.DateToUnixTimestamp(minUploadDate.Value));
        }

        if (maxUploadDate.HasValue && maxUploadDate != DateTime.MinValue)
        {
            parameters.Add("max_upload_date", UtilityMethods.DateToUnixTimestamp(maxUploadDate.Value));
        }

        return await GetResponseAsync<PlaceCollection>(parameters, cancellationToken);
    }

    async Task<TagCollection> IFlickrPlaces.TagsForPlaceAsync(string placeId, string woeId, DateTime? minUploadDate, DateTime? maxUploadDate,
                                            DateTime? minTakenDate, DateTime? maxTakenDate,
                                            CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.places.tagsForPlace" }
        };

        if (string.IsNullOrEmpty(placeId) && string.IsNullOrEmpty(woeId))
        {
            throw new FlickrException("Both placeId and woeId cannot be null or empty.");
        }

        if (!string.IsNullOrEmpty(woeId))
        {
            parameters.Add("woe_id", woeId);
        }

        if (!string.IsNullOrEmpty(placeId))
        {
            parameters.Add("place_id", placeId);
        }

        if (minTakenDate.HasValue && minTakenDate != DateTime.MinValue)
        {
            parameters.Add("min_taken_date", UtilityMethods.DateToMySql(minTakenDate.Value));
        }

        if (maxTakenDate.HasValue && maxTakenDate != DateTime.MinValue)
        {
            parameters.Add("max_taken_date", UtilityMethods.DateToMySql(maxTakenDate.Value));
        }

        if (minUploadDate.HasValue && minUploadDate != DateTime.MinValue)
        {
            parameters.Add("min_upload_date", UtilityMethods.DateToUnixTimestamp(minUploadDate.Value));
        }

        if (maxUploadDate.HasValue && maxUploadDate != DateTime.MinValue)
        {
            parameters.Add("max_upload_date", UtilityMethods.DateToUnixTimestamp(maxUploadDate.Value));
        }

        return await GetResponseAsync<TagCollection>(parameters, cancellationToken);
    }
}

/// <summary>
/// The flickr places.
/// </summary>
public interface IFlickrPlaces
{
    /// <summary>
    /// Returns a list of places which contain the query string.
    /// </summary>
    /// <param name="query">The string to search for. Must not be null.</param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task<PlaceCollection> FindAsync(string query, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a place based on the input latitude and longitude.
    /// </summary>
    /// <param name="latitude">The latitude, between -180 and 180.</param>
    /// <param name="longitude">The longitude, between -90 and 90.</param>
    /// <param name="accuracy">The level the locality will be for.</param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task<Place> FindByLatLonAsync(double latitude, double longitude, GeoAccuracy accuracy = GeoAccuracy.None, CancellationToken cancellationToken = default);

    /// <summary>
    /// Return a list of locations with public photos that are parented by a Where on Earth (WOE) or
    /// Places ID.
    /// </summary>
    /// <param name="placeId">
    /// A Flickr Places ID. (While optional, you must pass either a valid Places ID or a WOE ID.)
    /// </param>
    /// <param name="woeId">
    /// A Where On Earth (WOE) ID. (While optional, you must pass either a valid Places ID or a WOE ID.)
    /// </param>
    /// <param name="cancellationToken"></param>
    Task<PlaceCollection> GetChildrenWithPhotosPublicAsync(string placeId, string woeId = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get informations about a place.
    /// </summary>
    /// <param name="placeId">
    /// A Flickr Places ID. (While optional, you must pass either a valid Places ID or a WOE ID.)
    /// </param>
    /// <param name="woeId">
    /// A Where On Earth (WOE) ID. (While optional, you must pass either a valid Places ID or a WOE ID.)
    /// </param>
    /// <param name="cancellationToken"></param>
    Task<PlaceInfo> GetInfoAsync(string placeId, string woeId = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Lookup information about a place, by its flickr.com/places URL.
    /// </summary>
    /// <param name="url">
    /// A flickr.com/places URL in the form of /country/region/city. For example: /Canada/Quebec/Montreal
    /// </param>
    /// <param name="cancellationToken"></param>
    Task<PlaceInfo> GetInfoByUrlAsync(string url, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a list of valid Place Type key/value pairs.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <remarks>
    /// All Flickr.Net methods use the <see cref="PlaceType"/> enumeration so this method doesn't
    /// serve much purpose.
    /// </remarks>
    Task<PlaceTypeInfoCollection> GetPlaceTypesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Return an historical list of all the shape data generated for a Places or Where on Earth
    /// (WOE) ID.
    /// </summary>
    /// <param name="placeId">
    /// A Flickr Places ID. (While optional, you must pass either a valid Places ID or a WOE ID.)
    /// </param>
    /// <param name="woeId">
    /// A Where On Earth (WOE) ID. (While optional, you must pass either a valid Places ID or a WOE ID.)
    /// </param>
    /// <param name="cancellationToken"></param>
    Task<ShapeDataCollection> GetShapeHistoryAsync(string placeId, string woeId = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Return the top 100 most geotagged places for a day.
    /// </summary>
    /// <param name="placeType">The type for a specific place type to cluster photos by.</param>
    /// <param name="date">A valid date. The default is yesterday.</param>
    /// <param name="placeId">
    /// Limit your query to only those top places belonging to a specific Flickr Places identifier.
    /// </param>
    /// <param name="woeId">
    /// Limit your query to only those top places belonging to a specific Where on Earth (WOE) identifier.
    /// </param>
    /// <param name="cancellationToken"></param>
    Task<PlaceCollection> GetTopPlacesListAsync(PlaceType placeType, DateTime? date = null, string placeId = null, string woeId = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Return a list of the top 100 unique places clustered by a given placetype for set of tags or
    /// machine tags.
    /// </summary>
    /// <param name="boundaryBox">The boundary box to search for places in.</param>
    /// <param name="placeType">The ID for a specific place type to cluster photos by.</param>
    /// <param name="cancellationToken"></param>
    Task<PlaceCollection> PlacesForBoundingBoxAsync(BoundaryBox boundaryBox, PlaceType placeType, CancellationToken cancellationToken = default);

    /// <summary>
    /// Return a list of the top 100 unique places clustered by a given placetype for set of tags or
    /// machine tags.
    /// </summary>
    /// <param name="placeType">The ID for a specific place type to cluster photos by.</param>
    /// <param name="woeId">A Where on Earth identifier to use to filter photo clusters.</param>
    /// <param name="placeId">A Flickr Places identifier to use to filter photo clusters.</param>
    /// <param name="threshold">
    /// The minimum number of photos that a place type must have to be included. If the number of
    /// photos is lowered then the parent place type for that place will be used.
    /// </param>
    /// <param name="contactType">
    /// The type of contacts to return places for. Either all, or friends and family only.
    /// </param>
    /// <param name="minUploadDate">Minimum upload date.</param>
    /// <param name="maxUploadDate">Maximum upload date.</param>
    /// <param name="minTakenDate">Minimum taken date.</param>
    /// <param name="maxTakenDate">Maximum taken date.</param>
    /// <param name="cancellationToken"></param>
    Task<PlaceCollection> PlacesForContactsAsync(PlaceType placeType = PlaceType.None, string woeId = null, string placeId = null, int threshold = 0,
        ContactSearch contactType = ContactSearch.None, DateTime? minUploadDate = null,
        DateTime? maxUploadDate = null, DateTime? minTakenDate = null, DateTime? maxTakenDate = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Return a list of the top 100 unique places clustered by a given placetype for set of tags or
    /// machine tags.
    /// </summary>
    /// <param name="placeType">The ID for a specific place type to cluster photos by.</param>
    /// <param name="woeId">A Where on Earth identifier to use to filter photo clusters.</param>
    /// <param name="placeId">A Flickr Places identifier to use to filter photo clusters.</param>
    /// <param name="threshold">
    /// The minimum number of photos that a place type must have to be included. If the number of
    /// photos is lowered then the parent place type for that place will be used.
    /// </param>
    /// <param name="tags">A list of tags. Photos with one or more of the tags listed will be returned.</param>
    /// <param name="tagMode">
    /// Either 'any' for an OR combination of tags, or 'all' for an AND combination. Defaults to
    /// 'any' if not specified.
    /// </param>
    /// <param name="machineTags"></param>
    /// <param name="machineTagMode"></param>
    /// <param name="minUploadDate">Minimum upload date.</param>
    /// <param name="maxUploadDate">Maximum upload date.</param>
    /// <param name="minTakenDate">Minimum taken date.</param>
    /// <param name="maxTakenDate">Maximum taken date.</param>
    /// <param name="cancellationToken"></param>
    Task<PlaceCollection> PlacesForTagsAsync(PlaceType placeType, string woeId = null, string placeId = null, int threshold = 0,
        IEnumerable<string> tags = null, TagMode tagMode = TagMode.None, IEnumerable<string> machineTags = null,
        MachineTagMode machineTagMode = MachineTagMode.None, DateTime? minUploadDate = null,
        DateTime? maxUploadDate = null, DateTime? minTakenDate = null, DateTime? maxTakenDate = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the places of a particular type that the authenticated user has geotagged photos.
    /// </summary>
    /// <param name="placeType">The type of places to return.</param>
    /// <param name="woeId">A Where on Earth identifier to use to filter photo clusters.</param>
    /// <param name="placeId">A Flickr Places identifier to use to filter photo clusters.</param>
    /// <param name="threshold">
    /// The minimum number of photos that a place type must have to be included. If the number of
    /// photos is lowered then the parent place type for that place will be used. For example if you
    /// only have 3 photos taken in the locality of Montreal (WOE ID 3534) but your threshold is set
    /// to 5 then those photos will be "rolled up" and included instead with a place record for the
    /// region of Quebec (WOE ID 2344924).
    /// </param>
    /// <param name="minUploadDate">
    /// Minimum upload date. Photos with an upload date greater than or equal to this value will be returned.
    /// </param>
    /// <param name="maxUploadDate">
    /// Maximum upload date. Photos with an upload date less than or equal to this value will be returned.
    /// </param>
    /// <param name="minTakenDate">
    /// Minimum taken date. Photos with an taken date greater than or equal to this value will be returned.
    /// </param>
    /// <param name="maxTakenDate">
    /// Maximum taken date. Photos with an taken date less than or equal to this value will be returned.
    /// </param>
    /// <param name="cancellationToken"></param>
    Task<PlaceCollection> PlacesForUserAsync(PlaceType placeType = PlaceType.None, string woeId = null, string placeId = null, int threshold = 0,
        DateTime? minUploadDate = null, DateTime? maxUploadDate = null, DateTime? minTakenDate = null, DateTime? maxTakenDate = null,
        CancellationToken cancellationToken = default);

    /// <summary>
    /// Return a list of the top 100 unique tags for a Flickr Places or Where on Earth (WOE) ID.
    /// </summary>
    /// <param name="placeId">
    /// A Flickr Places identifier to use to filter photo clusters. (While optional, you must pass
    /// either a valid Places ID or a WOE ID.)
    /// </param>
    /// <param name="woeId">
    /// A Where on Earth identifier to use to filter photo clusters. (While optional, you must pass
    /// either a valid Places ID or a WOE ID.)
    /// </param>
    /// <param name="minUploadDate">
    /// Minimum upload date. Photos with an upload date greater than or equal to this value will be returned.
    /// </param>
    /// <param name="maxUploadDate">
    /// Maximum upload date. Photos with an upload date less than or equal to this value will be returned.
    /// </param>
    /// <param name="minTakenDate">
    /// Minimum taken date. Photos with an taken date greater than or equal to this value will be returned.
    /// </param>
    /// <param name="maxTakenDate">
    /// Maximum taken date. Photos with an taken date less than or equal to this value will be returned.
    /// </param>
    /// <param name="cancellationToken"></param>
    Task<TagCollection> TagsForPlaceAsync(string placeId, string woeId = null, DateTime? minUploadDate = null, DateTime? maxUploadDate = null,
        DateTime? minTakenDate = null, DateTime? maxTakenDate = null,
        CancellationToken cancellationToken = default);
}