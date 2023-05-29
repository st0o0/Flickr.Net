namespace FlickrNet.Core;

public partial class Flickr
{
    /// <summary>
    /// Return a list of unique namespaces, in alphabetical order.
    /// </summary>
    public async Task<NamespaceCollection> MachineTagsGetNamespacesAsync(CancellationToken cancellationToken = default)
    {
        return await MachineTagsGetNamespacesAsync(null, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Return a list of unique namespaces, in alphabetical order.
    /// </summary>
    /// <param name="page">The page of results to return. If this argument is omitted, it defaults to 1.</param>
    /// <param name="perPage">Number of photos to return per page. If this argument is omitted, it defaults to 100. The maximum allowed value is 500.</param>
    public async Task<NamespaceCollection> MachineTagsGetNamespacesAsync(int page, int perPage, CancellationToken cancellationToken = default)
    {
        return await MachineTagsGetNamespacesAsync(null, page, perPage, cancellationToken);
    }

    /// <summary>
    /// Return a list of unique namespaces, optionally limited by a given predicate, in alphabetical order.
    /// </summary>
    /// <param name="predicate">Limit the list of namespaces returned to those that have the following predicate.</param>
    public async Task<NamespaceCollection> MachineTagsGetNamespacesAsync(string predicate, CancellationToken cancellationToken = default)
    {
        return await MachineTagsGetNamespacesAsync(predicate, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Return a list of unique namespaces, optionally limited by a given predicate, in alphabetical order.
    /// </summary>
    /// <param name="predicate">Limit the list of namespaces returned to those that have the following predicate.</param>
    /// <param name="page">The page of results to return. If this argument is omitted, it defaults to 1.</param>
    /// <param name="perPage">Number of photos to return per page. If this argument is omitted, it defaults to 100. The maximum allowed value is 500.</param>
    public async Task<NamespaceCollection> MachineTagsGetNamespacesAsync(string predicate, int page, int perPage, CancellationToken cancellationToken = default)
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

        return await GetResponseAsync<NamespaceCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Return a list of unique predicates, in alphabetical order.
    /// </summary>
    public async Task<PredicateCollection> MachineTagsGetPredicatesAsync(CancellationToken cancellationToken = default)
    {
        return await MachineTagsGetPredicatesAsync(null, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Return a list of unique predicates, in alphabetical order.
    /// </summary>
    /// <param name="page">The page of results to return. If this argument is omitted, it defaults to 1.</param>
    /// <param name="perPage">Number of namespaces to return per page. If this argument is omitted, it defaults to 100. The maximum allowed value is 500.</param>
    public async Task<PredicateCollection> MachineTagsGetPredicatesAsync(int page, int perPage, CancellationToken cancellationToken = default)
    {
        return await MachineTagsGetPredicatesAsync(null, page, perPage, cancellationToken);
    }

    /// <summary>
    /// Return a list of unique predicates, optionally limited by a given namespace, in alphabetical order.
    /// </summary>
    /// <param name="namespaceName">Limit the list of predicates returned to those that have the following namespace.</param>
    public async Task<PredicateCollection> MachineTagsGetPredicatesAsync(string namespaceName, CancellationToken cancellationToken = default)
    {
        return await MachineTagsGetPredicatesAsync(namespaceName, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Return a list of unique predicates, optionally limited by a given namespace, in alphabetical order.
    /// </summary>
    /// <param name="namespaceName">Limit the list of predicates returned to those that have the following namespace.</param>
    /// <param name="page">The page of results to return. If this argument is omitted, it defaults to 1.</param>
    /// <param name="perPage">Number of namespaces to return per page. If this argument is omitted, it defaults to 100. The maximum allowed value is 500.</param>
    public async Task<PredicateCollection> MachineTagsGetPredicatesAsync(string namespaceName, int page, int perPage, CancellationToken cancellationToken = default)
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

        return await GetResponseAsync<PredicateCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Return a list of unique namespace and predicate pairs, in alphabetical order.
    /// </summary>
    public async Task<PairCollection> MachineTagsGetPairsAsync(CancellationToken cancellationToken = default)
    {
        return await MachineTagsGetPairsAsync(null, null, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Return a list of unique namespace and predicate pairs, in alphabetical order.
    /// </summary>
    /// <param name="page">The page of results to return. If this argument is omitted, it defaults to 1.</param>
    /// <param name="perPage">Number of pairs to return per page. If this argument is omitted, it defaults to 100. The maximum allowed value is 500.</param>
    public async Task<PairCollection> MachineTagsGetPairsAsync(int page, int perPage, CancellationToken cancellationToken = default)
    {
        return await MachineTagsGetPairsAsync(null, null, page, perPage, cancellationToken);
    }

    /// <summary>
    /// Return a list of unique namespace and predicate pairs, optionally limited by predicate or namespace, in alphabetical order.
    /// </summary>
    /// <param name="namespaceName">Limit the list of pairs returned to those that have the following namespace.</param>
    /// <param name="predicate">Limit the list of pairs returned to those that have the following predicate.</param>
    public async Task<PairCollection> MachineTagsGetPairsAsync(string namespaceName, string predicate, CancellationToken cancellationToken = default)
    {
        return await MachineTagsGetPairsAsync(namespaceName, predicate, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Return a list of unique namespace and predicate pairs, optionally limited by predicate or namespace, in alphabetical order.
    /// </summary>
    /// <param name="namespaceName">Limit the list of pairs returned to those that have the following namespace.</param>
    /// <param name="predicate">Limit the list of pairs returned to those that have the following predicate.</param>
    /// <param name="page">The page of results to return. If this argument is omitted, it defaults to 1.</param>
    /// <param name="perPage">Number of pairs to return per page. If this argument is omitted, it defaults to 100. The maximum allowed value is 500.</param>
    public async Task<PairCollection> MachineTagsGetPairsAsync(string namespaceName, string predicate, int page, int perPage, CancellationToken cancellationToken = default)
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

        return await GetResponseAsync<PairCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Return a list of unique values for a namespace and predicate.
    /// </summary>
    /// <param name="namespaceName">The namespace that all values should be restricted to.</param>
    /// <param name="predicate">The predicate that all values should be restricted to.</param>
    public async Task<ValueCollection> MachineTagsGetValuesAsync(string namespaceName, string predicate, CancellationToken cancellationToken = default)
    {
        return await MachineTagsGetValuesAsync(namespaceName, predicate, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Return a list of unique values for a namespace and predicate.
    /// </summary>
    /// <param name="namespaceName">The namespace that all values should be restricted to.</param>
    /// <param name="predicate">The predicate that all values should be restricted to.</param>
    /// <param name="page">The page of results to return. If this argument is omitted, it defaults to 1.</param>
    /// <param name="perPage">Number of values to return per page. If this argument is omitted, it defaults to 100. The maximum allowed value is 500.</param>
    public async Task<ValueCollection> MachineTagsGetValuesAsync(string namespaceName, string predicate, int page, int perPage, CancellationToken cancellationToken = default)
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

        return await GetResponseAsync<ValueCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Fetch recently used (or created) machine tags values.
    /// </summary>
    /// <param name="addedSince">Only return machine tags values that have been added since this timestamp.</param>
    public async Task<ValueCollection> MachineTagsGetRecentValuesAsync(DateTime addedSince, CancellationToken cancellationToken = default)
    {
        return await MachineTagsGetRecentValuesAsync(null, null, addedSince, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Fetch recently used (or created) machine tags values.
    /// </summary>
    /// <param name="addedSince">Only return machine tags values that have been added since this timestamp.</param>
    /// <param name="page">The page of results to return. If this argument is omitted, it defaults to 1.</param>
    /// <param name="perPage">Number of values to return per page. If this argument is omitted, it defaults to 100. The maximum allowed value is 500.</param>
    public async Task<ValueCollection> MachineTagsGetRecentValuesAsync(DateTime addedSince, int page, int perPage, CancellationToken cancellationToken = default)
    {
        return await MachineTagsGetRecentValuesAsync(null, null, addedSince, page, perPage, cancellationToken);
    }

    /// <summary>
    /// Fetch recently used (or created) machine tags values.
    /// </summary>
    /// <param name="namespaceName">The namespace that all values should be restricted to.</param>
    /// <param name="predicate">The predicate that all values should be restricted to.</param>
    public async Task<ValueCollection> MachineTagsGetRecentValuesAsync(string namespaceName, string predicate, CancellationToken cancellationToken = default)
    {
        return await MachineTagsGetRecentValuesAsync(namespaceName, predicate, DateTime.MinValue, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Fetch recently used (or created) machine tags values.
    /// </summary>
    /// <param name="namespaceName">The namespace that all values should be restricted to.</param>
    /// <param name="predicate">The predicate that all values should be restricted to.</param>
    /// <param name="page">The page of results to return. If this argument is omitted, it defaults to 1.</param>
    /// <param name="perPage">Number of values to return per page. If this argument is omitted, it defaults to 100. The maximum allowed value is 500.</param>
    public async Task<ValueCollection> MachineTagsGetRecentValuesAsync(string namespaceName, string predicate, int page, int perPage, CancellationToken cancellationToken = default)
    {
        return await MachineTagsGetRecentValuesAsync(namespaceName, predicate, DateTime.MinValue, page, perPage, cancellationToken);
    }

    /// <summary>
    /// Fetch recently used (or created) machine tags values.
    /// </summary>
    /// <param name="namespaceName">The namespace that all values should be restricted to.</param>
    /// <param name="predicate">The predicate that all values should be restricted to.</param>
    /// <param name="addedSince">Only return machine tags values that have been added since this timestamp.</param>
    /// <param name="page">The page of results to return. If this argument is omitted, it defaults to 1.</param>
    /// <param name="perPage">Number of values to return per page. If this argument is omitted, it defaults to 100. The maximum allowed value is 500.</param>
    public async Task<ValueCollection> MachineTagsGetRecentValuesAsync(string namespaceName, string predicate, DateTime addedSince, int page, int perPage, CancellationToken cancellationToken = default)
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

        if (addedSince != DateTime.MinValue)
        {
            parameters.Add("added_since", UtilityMethods.DateToUnixTimestamp(addedSince));
        }

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<ValueCollection>(parameters, cancellationToken);
    }
}