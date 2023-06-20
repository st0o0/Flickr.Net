namespace Flickr.Net.Core;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrMachineTags
{
    async Task<Namespaces> IFlickrMachineTags.GetNamespacesAsync(string predicate, int page, int perPage, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.machinetags.getNamespaces" }
        };

        if (!string.IsNullOrEmpty(predicate))
        {
            parameters.Add("predicate", predicate);
        }

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<Namespaces>(parameters, cancellationToken);
    }

    async Task<Pairs> IFlickrMachineTags.GetPairsAsync(string namespaceName, string predicate, int page, int perPage, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.machinetags.getPairs" }
        };

        if (!string.IsNullOrEmpty(namespaceName))
        {
            parameters.Add("namespace", namespaceName);
        }

        if (!string.IsNullOrEmpty(predicate))
        {
            parameters.Add("predicate", predicate);
        }

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<Pairs>(parameters, cancellationToken);
    }

    async Task<Predicates> IFlickrMachineTags.GetPredicatesAsync(string namespaceName, int page, int perPage, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.machinetags.getPredicates" }
        };

        if (!string.IsNullOrEmpty(namespaceName))
        {
            parameters.Add("namespace", namespaceName);
        }

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<Predicates>(parameters, cancellationToken);
    }

    async Task<Values> IFlickrMachineTags.GetRecentValuesAsync(string namespaceName, string predicate, DateTime? addedSince, CancellationToken cancellationToken)
    {
        if (string.IsNullOrEmpty(namespaceName) && string.IsNullOrEmpty(predicate) && addedSince == DateTime.MinValue)
        {
            throw new ArgumentException("Must supply one of namespaceName, predicate or addedSince");
        }

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.machinetags.getRecentValues" }
        };

        if (!string.IsNullOrEmpty(namespaceName))
        {
            parameters.Add("namespace", namespaceName);
        }

        if (!string.IsNullOrEmpty(predicate))
        {
            parameters.Add("predicate", predicate);
        }

        if (addedSince.HasValue && addedSince > DateTime.MinValue)
        {
            parameters.Add("added_since", UtilityMethods.DateToUnixTimestamp(addedSince.Value));
        }

        return await GetResponseAsync<Values>(parameters, cancellationToken);
    }

    async Task<Values> IFlickrMachineTags.GetValuesAsync(string namespaceName, string predicate, int page, int perPage, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.machinetags.getValues" },
            { "namespace", namespaceName },
            { "predicate", predicate }
        };

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<Values>(parameters, cancellationToken);
    }
}

/// <summary>
/// The flickr machine tags.
/// </summary>
public interface IFlickrMachineTags
{
    /// <summary>
    /// Return a list of unique namespaces, optionally limited by a given predicate, in alphabetical order.
    /// </summary>
    /// <param name="predicate">
    /// Limit the list of namespaces returned to those that have the following predicate.
    /// </param>
    /// <param name="page">
    /// The page of results to return. If this argument is omitted, it defaults to 1.
    /// </param>
    /// <param name="perPage">
    /// Number of photos to return per page. If this argument is omitted, it defaults to 100. The
    /// maximum allowed value is 500.
    /// </param>
    /// <param name="cancellationToken"></param>
    Task<Namespaces> GetNamespacesAsync(string predicate = null, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

    /// <summary>
    /// Return a list of unique namespace and predicate pairs, optionally limited by predicate or
    /// namespace, in alphabetical order.
    /// </summary>
    /// <param name="namespaceName">
    /// Limit the list of pairs returned to those that have the following namespace.
    /// </param>
    /// <param name="predicate">
    /// Limit the list of pairs returned to those that have the following predicate.
    /// </param>
    /// <param name="page">
    /// The page of results to return. If this argument is omitted, it defaults to 1.
    /// </param>
    /// <param name="perPage">
    /// Number of pairs to return per page. If this argument is omitted, it defaults to 100. The
    /// maximum allowed value is 500.
    /// </param>
    /// <param name="cancellationToken"></param>
    Task<Pairs> GetPairsAsync(string namespaceName = null, string predicate = null, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

    /// <summary>
    /// Return a list of unique predicates, optionally limited by a given namespace, in alphabetical order.
    /// </summary>
    /// <param name="namespaceName">
    /// Limit the list of predicates returned to those that have the following namespace.
    /// </param>
    /// <param name="page">
    /// The page of results to return. If this argument is omitted, it defaults to 1.
    /// </param>
    /// <param name="perPage">
    /// Number of namespaces to return per page. If this argument is omitted, it defaults to 100.
    /// The maximum allowed value is 500.
    /// </param>
    /// <param name="cancellationToken"></param>
    Task<Predicates> GetPredicatesAsync(string namespaceName = null, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

    /// <summary>
    /// Fetch recently used (or created) machine tags values.
    /// </summary>
    /// <param name="namespaceName">The namespace that all values should be restricted to.</param>
    /// <param name="predicate">The predicate that all values should be restricted to.</param>
    /// <param name="addedSince">
    /// Only return machine tags values that have been added since this timestamp.
    /// </param>
    /// <param name="cancellationToken"></param>
    Task<Values> GetRecentValuesAsync(string namespaceName = null, string predicate = null, DateTime? addedSince = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Return a list of unique values for a namespace and predicate.
    /// </summary>
    /// <param name="namespaceName">The namespace that all values should be restricted to.</param>
    /// <param name="predicate">The predicate that all values should be restricted to.</param>
    /// <param name="page">
    /// The page of results to return. If this argument is omitted, it defaults to 1.
    /// </param>
    /// <param name="perPage">
    /// Number of values to return per page. If this argument is omitted, it defaults to 100. The
    /// maximum allowed value is 500.
    /// </param>
    /// <param name="cancellationToken"></param>
    Task<Values> GetValuesAsync(string namespaceName, string predicate, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);
}