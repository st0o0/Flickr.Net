namespace Flickr.Net.Core;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrStats
{
    async Task<StatDomainCollection> IFlickrStats.StatsGetCollectionDomainsAsync(DateTime date, string collectionId, int page, int perPage, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.stats.getCollectionDomains" },
            { "date", UtilityMethods.DateToUnixTimestamp(date) }
        };
        if (!string.IsNullOrEmpty(collectionId))
        {
            parameters.Add("collection_id", collectionId);
        }

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<StatDomainCollection>(parameters, cancellationToken);
    }

    async Task<StatReferrerCollection> IFlickrStats.StatsGetCollectionReferrersAsync(DateTime date, string domain, string collectionId, int page, int perPage, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.stats.getCollectionReferrers" },
            { "date", UtilityMethods.DateToUnixTimestamp(date) },
            { "domain", domain }
        };
        if (!string.IsNullOrEmpty(collectionId))
        {
            parameters.Add("collection_id", collectionId);
        }

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<StatReferrerCollection>(parameters, cancellationToken);
    }

    async Task<Stats> IFlickrStats.StatsGetCollectionStatsAsync(DateTime date, string collectionId, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.stats.getCollectionStats" },
            { "date", UtilityMethods.DateToUnixTimestamp(date) },
            { "collection_id", UtilityMethods.CleanCollectionId(collectionId) }
        };

        return await GetResponseAsync<Stats>(parameters, cancellationToken);
    }

    async Task<CsvFileCollection> IFlickrStats.StatsGetCsvFilesAsync(CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.stats.getCSVFiles" }
        };

        return await GetResponseAsync<CsvFileCollection>(parameters, cancellationToken);
    }

    async Task<StatDomainCollection> IFlickrStats.StatsGetPhotoDomainsAsync(DateTime date, string photoId, int page, int perPage, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.stats.getPhotoDomains" },
            { "date", UtilityMethods.DateToUnixTimestamp(date) }
        };
        if (!string.IsNullOrEmpty(photoId))
        {
            parameters.Add("photo_id", photoId);
        }

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<StatDomainCollection>(parameters, cancellationToken);
    }

    async Task<StatReferrerCollection> IFlickrStats.StatsGetPhotoReferrersAsync(DateTime date, string domain, string photoId, int page, int perPage, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.stats.getPhotoReferrers" },
            { "date", UtilityMethods.DateToUnixTimestamp(date) },
            { "domain", domain }
        };
        if (!string.IsNullOrEmpty(photoId))
        {
            parameters.Add("photo_id", photoId);
        }

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<StatReferrerCollection>(parameters, cancellationToken);
    }

    async Task<StatDomainCollection> IFlickrStats.StatsGetPhotosetDomainsAsync(DateTime date, string photosetId, int page, int perPage, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.stats.getPhotosetDomains" },
            { "date", UtilityMethods.DateToUnixTimestamp(date) }
        };
        if (!string.IsNullOrEmpty(photosetId))
        {
            parameters.Add("photoset_id", photosetId);
        }

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<StatDomainCollection>(parameters, cancellationToken);
    }

    async Task<StatReferrerCollection> IFlickrStats.StatsGetPhotosetReferrersAsync(DateTime date, string domain, string photosetId, int page, int perPage, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.stats.getPhotosetReferrers" },
            { "date", UtilityMethods.DateToUnixTimestamp(date) },
            { "domain", domain }
        };
        if (!string.IsNullOrEmpty(photosetId))
        {
            parameters.Add("photoset_id", photosetId);
        }

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<StatReferrerCollection>(parameters, cancellationToken);
    }

    async Task<Stats> IFlickrStats.StatsGetPhotosetStatsAsync(DateTime date, string photosetId, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.stats.getPhotosetStats" },
            { "date", UtilityMethods.DateToUnixTimestamp(date) },
            { "photoset_id", photosetId }
        };

        return await GetResponseAsync<Stats>(parameters, cancellationToken);
    }

    async Task<Stats> IFlickrStats.StatsGetPhotoStatsAsync(DateTime date, string photoId, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.stats.getPhotoStats" },
            { "date", UtilityMethods.DateToUnixTimestamp(date) },
            { "photo_id", photoId }
        };

        return await GetResponseAsync<Stats>(parameters, cancellationToken);
    }

    async Task<StatDomainCollection> IFlickrStats.StatsGetPhotostreamDomainsAsync(DateTime date, int page, int perPage, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.stats.getPhotostreamDomains" },
            { "date", UtilityMethods.DateToUnixTimestamp(date) }
        };

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<StatDomainCollection>(parameters, cancellationToken);
    }

    async Task<StatReferrerCollection> IFlickrStats.StatsGetPhotostreamReferrersAsync(DateTime date, string domain, int page, int perPage, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.stats.getPhotostreamReferrers" },
            { "date", UtilityMethods.DateToUnixTimestamp(date) },
            { "domain", domain }
        };
        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<StatReferrerCollection>(parameters, cancellationToken);
    }

    async Task<Stats> IFlickrStats.StatsGetPhotostreamStatsAsync(DateTime date, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.stats.getPhotostreamStats" },
            { "date", UtilityMethods.DateToUnixTimestamp(date) }
        };

        return await GetResponseAsync<Stats>(parameters, cancellationToken);
    }

    async Task<PopularPhotoCollection> IFlickrStats.StatsGetPopularPhotosAsync(DateTime date, PopularitySort sort, int page, int perPage, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.stats.getPopularPhotos" }
        };
        if (date != DateTime.MinValue)
        {
            parameters.Add("date", UtilityMethods.DateToUnixTimestamp(date));
        }

        if (sort != PopularitySort.None)
        {
            parameters.Add("sort", UtilityMethods.SortOrderToString(sort));
        }

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<PopularPhotoCollection>(parameters, cancellationToken);
    }

    async Task<StatViews> IFlickrStats.StatsGetTotalViewsAsync(DateTime date, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.stats.getTotalViews" }
        };
        if (date != DateTime.MinValue)
        {
            parameters.Add("date", UtilityMethods.DateToUnixTimestamp(date));
        }

        return await GetResponseAsync<StatViews>(parameters, cancellationToken);
    }
}

/// <summary>
/// The flickr stats.
/// </summary>
public interface IFlickrStats
{
    /// <summary>
    /// Get a list of referring domains for a collection.
    /// </summary>
    /// <param name="date">
    /// Stats will be returned for this date. A day according to Flickr Stats starts at midnight GMT
    /// for all users, and timestamps will automatically be rounded down to the start of the day.
    /// </param>
    /// <param name="collectionId">
    /// The id of the collection to get stats for. If not provided, stats for all collections will
    /// be returned.
    /// </param>
    /// <param name="page">
    /// The page of results to return. If this argument is omitted, it defaults to 1.
    /// </param>
    /// <param name="perPage">
    /// Number of domains to return per page. If this argument is omitted, it defaults to 25. The
    /// maximum allowed value is 100.
    /// </param>
    /// <param name="cancellationToken"></param>
    Task<StatDomainCollection> StatsGetCollectionDomainsAsync(DateTime date, string collectionId = null, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a list of referrers from a given domain to a collection.
    /// </summary>
    /// <param name="date">The date to return stats for.</param>
    /// <param name="domain">
    /// The domain to return referrers for. This should be a hostname (eg: "flickr.com") with no
    /// protocol or pathname.
    /// </param>
    /// <param name="collectionId">
    /// The collection to return referrers for. If missing then referrers for all photosets will be returned.
    /// </param>
    /// <param name="page">The page of the results to return. Default is 1.</param>
    /// <param name="perPage">
    /// The number of referrers to return per page. The default is 25 and the maximum is 100.
    /// </param>
    /// <param name="cancellationToken"></param>
    Task<StatReferrerCollection> StatsGetCollectionReferrersAsync(DateTime date, string domain, string collectionId = null, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the number of views on the given date for the given collection. Only <see
    /// cref="Stats.Views"/> will be populated.
    /// </summary>
    /// <param name="date">The date to return stats for.</param>
    /// <param name="collectionId">The collection to return stats for.</param>
    /// <param name="cancellationToken"></param>
    Task<Stats> StatsGetCollectionStatsAsync(DateTime date, string collectionId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the collection of CSV files of archived stats from Flickr.
    /// </summary>
    /// <remarks>Archived files only available till the 1st June 2010.</remarks>
    Task<CsvFileCollection> StatsGetCsvFilesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a list of referring domains for a photo.
    /// </summary>
    /// <param name="date">
    /// Stats will be returned for this date. A day according to Flickr Stats starts at midnight GMT
    /// for all users, and timestamps will automatically be rounded down to the start of the day.
    /// </param>
    /// <param name="photoId">
    /// The id of the photo to get stats for. If not provided, stats for all photos will be returned.
    /// </param>
    /// <param name="page">
    /// The page of results to return. If this argument is omitted, it defaults to 1.
    /// </param>
    /// <param name="perPage">
    /// Number of domains to return per page. If this argument is omitted, it defaults to 25. The
    /// maximum allowed value is 100.
    /// </param>
    /// <param name="cancellationToken"></param>
    Task<StatDomainCollection> StatsGetPhotoDomainsAsync(DateTime date, string photoId = null, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a list of referrers from a given domain to a photo.
    /// </summary>
    /// <param name="date">The date to return stats for.</param>
    /// <param name="domain">
    /// The domain to return referrers for. This should be a hostname (eg: "flickr.com") with no
    /// protocol or pathname.
    /// </param>
    /// <param name="photoId">
    /// The photo to return referrers for. If missing then referrers for all photos will be returned.
    /// </param>
    /// <param name="page">The page of the results to return. Default is 1.</param>
    /// <param name="perPage">
    /// The number of referrers to return per page. The default is 25 and the maximum is 100.
    /// </param>
    /// <param name="cancellationToken"></param>
    Task<StatReferrerCollection> StatsGetPhotoReferrersAsync(DateTime date, string domain, string photoId = null, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a list of referring domains for a photoset.
    /// </summary>
    /// <param name="date">
    /// Stats will be returned for this date. A day according to Flickr Stats starts at midnight GMT
    /// for all users, and timestamps will automatically be rounded down to the start of the day.
    /// </param>
    /// <param name="photosetId">
    /// The id of the photoset to get stats for. If not provided, stats for all sets will be returned.
    /// </param>
    /// <param name="page">
    /// The page of results to return. If this argument is omitted, it defaults to 1.
    /// </param>
    /// <param name="perPage">
    /// Number of domains to return per page. If this argument is omitted, it defaults to 25. The
    /// maximum allowed value is 100.
    /// </param>
    /// <param name="cancellationToken"></param>
    Task<StatDomainCollection> StatsGetPhotosetDomainsAsync(DateTime date, string photosetId = null, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a list of referrers from a given domain to a photoset.
    /// </summary>
    /// <param name="date">The date to return stats for.</param>
    /// <param name="domain">
    /// The domain to return referrers for. This should be a hostname (eg: "flickr.com") with no
    /// protocol or pathname.
    /// </param>
    /// <param name="photosetId">
    /// The photoset to return referrers for. If missing then referrers for all photosets will be returned.
    /// </param>
    /// <param name="page">The page of the results to return. Default is 1.</param>
    /// <param name="perPage">
    /// The number of referrers to return per page. The default is 25 and the maximum is 100.
    /// </param>
    /// <param name="cancellationToken"></param>
    Task<StatReferrerCollection> StatsGetPhotosetReferrersAsync(DateTime date, string domain, string photosetId = null, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the number of views and comments on the given date for the given photoset. Only <see
    /// cref="Stats.Views"/> and <see cref="Stats.Comments"/> will be populated.
    /// </summary>
    /// <param name="date">The date to return stats for.</param>
    /// <param name="photosetId">The photoset to return stats for.</param>
    /// <param name="cancellationToken"></param>
    Task<Stats> StatsGetPhotosetStatsAsync(DateTime date, string photosetId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the number of views, comments and favorites on the given date for the given photo.
    /// </summary>
    /// <param name="date">The date to return stats for.</param>
    /// <param name="photoId">The photo to return stats for.</param>
    /// <param name="cancellationToken"></param>
    Task<Stats> StatsGetPhotoStatsAsync(DateTime date, string photoId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a list of referring domains for a photostream.
    /// </summary>
    /// <param name="date">
    /// Stats will be returned for this date. A day according to Flickr Stats starts at midnight GMT
    /// for all users, and timestamps will automatically be rounded down to the start of the day.
    /// </param>
    /// <param name="page">
    /// The page of results to return. If this argument is omitted, it defaults to 1.
    /// </param>
    /// <param name="perPage">
    /// Number of domains to return per page. If this argument is omitted, it defaults to 25. The
    /// maximum allowed value is 100.
    /// </param>
    /// <param name="cancellationToken"></param>
    Task<StatDomainCollection> StatsGetPhotostreamDomainsAsync(DateTime date, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a list of referrers from a given domain to a photostream.
    /// </summary>
    /// <param name="date">The date to return stats for.</param>
    /// <param name="domain">
    /// The domain to return referrers for. This should be a hostname (eg: "flickr.com") with no
    /// protocol or pathname.
    /// </param>
    /// <param name="page">The page of the results to return. Default is 1.</param>
    /// <param name="perPage">
    /// The number of referrers to return per page. The default is 25 and the maximum is 100.
    /// </param>
    /// <param name="cancellationToken"></param>
    Task<StatReferrerCollection> StatsGetPhotostreamReferrersAsync(DateTime date, string domain, int page, int perPage, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the number of views on the given date for the users photostream. Only <see
    /// cref="Stats.Views"/> will be populated.
    /// </summary>
    /// <param name="date">The date to return stats for.</param>
    /// <param name="cancellationToken"></param>
    Task<Stats> StatsGetPhotostreamStatsAsync(DateTime date, CancellationToken cancellationToken = default);

    /// <summary>
    /// List the photos with the most views, comments or favorites.
    /// </summary>
    /// <param name="date">
    /// Stats will be returned for this date. A day according to Flickr Stats starts at midnight GMT
    /// for all users, and timestamps will automatically be rounded down to the start of the day. If
    /// no date is provided, all time view counts will be returned.
    /// </param>
    /// <param name="sort">
    /// The order in which to sort returned photos. Defaults to views. The possible values are
    /// views, comments and favorites.
    /// </param>
    /// <param name="page">
    /// The page of results to return. If this argument is omitted, it defaults to 1.
    /// </param>
    /// <param name="perPage">
    /// Number of photos to return per page. If this argument is omitted, it defaults to 25. The
    /// maximum allowed value is 100.
    /// </param>
    /// <param name="cancellationToken"></param>
    Task<PopularPhotoCollection> StatsGetPopularPhotosAsync(DateTime date, PopularitySort sort, int page, int perPage, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get the overall view counts for an account on a given date.
    /// </summary>
    /// <param name="date">The date to return the overall view count for.</param>
    /// <param name="cancellationToken"></param>
    Task<StatViews> StatsGetTotalViewsAsync(DateTime date, CancellationToken cancellationToken = default);
}
