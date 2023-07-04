using Flickr.Net.Core.Internals.Extensions;

namespace Flickr.Net.Core;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrStats
{
    async Task<Domains> IFlickrStats.GetCollectionDomainsAsync(DateTime date, string collectionId, int page, int perPage, CancellationToken cancellationToken)
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

        return await GetResponseAsync<Domains>(parameters, cancellationToken);
    }

    async Task<Referrers> IFlickrStats.GetCollectionReferrersAsync(DateTime date, string domain, string collectionId, int page, int perPage, CancellationToken cancellationToken)
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

        return await GetResponseAsync<Referrers>(parameters, cancellationToken);
    }

    async Task<Stats> IFlickrStats.GetCollectionStatsAsync(DateTime date, string collectionId, CancellationToken cancellationToken)
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

    async Task<CSVFiles> IFlickrStats.GetCsvFilesAsync(CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.stats.getCSVFiles" }
        };

        return await GetResponseAsync<CSVFiles>(parameters, cancellationToken);
    }

    async Task<Domains> IFlickrStats.GetPhotoDomainsAsync(DateTime date, string photoId, int page, int perPage, CancellationToken cancellationToken)
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

        return await GetResponseAsync<Domains>(parameters, cancellationToken);
    }

    async Task<Referrers> IFlickrStats.GetPhotoReferrersAsync(DateTime date, string domain, string photoId, int page, int perPage, CancellationToken cancellationToken)
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

        return await GetResponseAsync<Referrers>(parameters, cancellationToken);
    }

    async Task<Domains> IFlickrStats.GetPhotosetDomainsAsync(DateTime date, string photosetId, int page, int perPage, CancellationToken cancellationToken)
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

        return await GetResponseAsync<Domains>(parameters, cancellationToken);
    }

    async Task<Referrers> IFlickrStats.GetPhotosetReferrersAsync(DateTime date, string domain, string photosetId, int page, int perPage, CancellationToken cancellationToken)
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

        return await GetResponseAsync<Referrers>(parameters, cancellationToken);
    }

    async Task<Stats> IFlickrStats.GetPhotosetStatsAsync(DateTime date, string photosetId, CancellationToken cancellationToken)
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

    async Task<Stats> IFlickrStats.GetPhotoStatsAsync(DateTime date, string photoId, CancellationToken cancellationToken)
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

    async Task<Domains> IFlickrStats.GetPhotostreamDomainsAsync(DateTime date, int page, int perPage, CancellationToken cancellationToken)
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

        return await GetResponseAsync<Domains>(parameters, cancellationToken);
    }

    async Task<Referrers> IFlickrStats.GetPhotostreamReferrersAsync(DateTime date, string domain, int page, int perPage, CancellationToken cancellationToken)
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

        return await GetResponseAsync<Referrers>(parameters, cancellationToken);
    }

    async Task<Stats> IFlickrStats.GetPhotostreamStatsAsync(DateTime date, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.stats.getPhotostreamStats" },
            { "date", UtilityMethods.DateToUnixTimestamp(date) }
        };

        return await GetResponseAsync<Stats>(parameters, cancellationToken);
    }

    async Task<StatsPhotos> IFlickrStats.GetPopularPhotosAsync(DateTime date, PopularitySort sort, int page, int perPage, CancellationToken cancellationToken)
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
            parameters.Add("sort", sort.ToFlickrString());
        }

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<StatsPhotos>(parameters, cancellationToken);
    }

    async Task<Views> IFlickrStats.GetTotalViewsAsync(DateTime date, CancellationToken cancellationToken)
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

        return await GetResponseAsync<Views>(parameters, cancellationToken);
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
    Task<Domains> GetCollectionDomainsAsync(DateTime date, string collectionId = null, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

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
    Task<Referrers> GetCollectionReferrersAsync(DateTime date, string domain, string collectionId = null, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the number of views on the given date for the given collection. Only <see
    /// cref="Stats.Views"/> will be populated.
    /// </summary>
    /// <param name="date">The date to return stats for.</param>
    /// <param name="collectionId">The collection to return stats for.</param>
    /// <param name="cancellationToken"></param>
    Task<Stats> GetCollectionStatsAsync(DateTime date, string collectionId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the collection of CSV files of archived stats from Flickr.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <remarks>Archived files only available till the 1st June 2010.</remarks>
    Task<CSVFiles> GetCsvFilesAsync(CancellationToken cancellationToken = default);

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
    Task<Domains> GetPhotoDomainsAsync(DateTime date, string photoId = null, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

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
    Task<Referrers> GetPhotoReferrersAsync(DateTime date, string domain, string photoId = null, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

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
    Task<Domains> GetPhotosetDomainsAsync(DateTime date, string photosetId = null, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

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
    Task<Referrers> GetPhotosetReferrersAsync(DateTime date, string domain, string photosetId = null, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the number of views and comments on the given date for the given photoset. Only <see
    /// cref="Stats.Views"/> and <see cref="Stats.Comments"/> will be populated.
    /// </summary>
    /// <param name="date">The date to return stats for.</param>
    /// <param name="photosetId">The photoset to return stats for.</param>
    /// <param name="cancellationToken"></param>
    Task<Stats> GetPhotosetStatsAsync(DateTime date, string photosetId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the number of views, comments and favorites on the given date for the given photo.
    /// </summary>
    /// <param name="date">The date to return stats for.</param>
    /// <param name="photoId">The photo to return stats for.</param>
    /// <param name="cancellationToken"></param>
    Task<Stats> GetPhotoStatsAsync(DateTime date, string photoId, CancellationToken cancellationToken = default);

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
    Task<Domains> GetPhotostreamDomainsAsync(DateTime date, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

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
    Task<Referrers> GetPhotostreamReferrersAsync(DateTime date, string domain, int page, int perPage, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the number of views on the given date for the users photostream. Only <see
    /// cref="Stats.Views"/> will be populated.
    /// </summary>
    /// <param name="date">The date to return stats for.</param>
    /// <param name="cancellationToken"></param>
    Task<Stats> GetPhotostreamStatsAsync(DateTime date, CancellationToken cancellationToken = default);

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
    Task<StatsPhotos> GetPopularPhotosAsync(DateTime date, PopularitySort sort, int page, int perPage, CancellationToken cancellationToken = default);

    /// <summary>
    /// Get the overall view counts for an account on a given date.
    /// </summary>
    /// <param name="date">The date to return the overall view count for.</param>
    /// <param name="cancellationToken"></param>
    Task<Views> GetTotalViewsAsync(DateTime date, CancellationToken cancellationToken = default);
}