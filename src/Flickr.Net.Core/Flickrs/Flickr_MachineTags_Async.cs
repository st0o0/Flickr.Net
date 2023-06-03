using Flickr.Net.Core.Entities.Collections;
using Flickr.Net.Core.Internals;

namespace Flickr.Net.Core;

// TODO:
public partial class Flickr
{
    /// <summary>
    /// Return a list of unique namespaces, optionally limited by a given predicate, in alphabetical order.
    /// </summary>
    /// <param name="predicate">Limit the list of namespaces returned to those that have the following predicate.</param>
    /// <param name="page">The page of results to return. If this argument is omitted, it defaults to 1.</param>
    /// <param name="perPage">Number of photos to return per page. If this argument is omitted, it defaults to 100. The maximum allowed value is 500.</param>
    public async Task<NamespaceCollection> MachineTagsGetNamespacesAsync(string predicate = null, int page = 0, int perPage = 0, CancellationToken cancellationToken = default)
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
    /// Return a list of unique namespace and predicate pairs, optionally limited by predicate or namespace, in alphabetical order.
    /// </summary>
    /// <param name="namespaceName">Limit the list of pairs returned to those that have the following namespace.</param>
    /// <param name="predicate">Limit the list of pairs returned to those that have the following predicate.</param>
    /// <param name="page">The page of results to return. If this argument is omitted, it defaults to 1.</param>
    /// <param name="perPage">Number of pairs to return per page. If this argument is omitted, it defaults to 100. The maximum allowed value is 500.</param>
    public async Task<PairCollection> MachineTagsGetPairsAsync(string namespaceName = null, string predicate = null, int page = 0, int perPage = 0, CancellationToken cancellationToken = default)
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
    /// Return a list of unique predicates, optionally limited by a given namespace, in alphabetical order.
    /// </summary>
    /// <param name="namespaceName">Limit the list of predicates returned to those that have the following namespace.</param>
    /// <param name="page">The page of results to return. If this argument is omitted, it defaults to 1.</param>
    /// <param name="perPage">Number of namespaces to return per page. If this argument is omitted, it defaults to 100. The maximum allowed value is 500.</param>
    public async Task<PredicateCollection> MachineTagsGetPredicatesAsync(string namespaceName = null, int page = 0, int perPage = 0, CancellationToken cancellationToken = default)
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
    /// Fetch recently used (or created) machine tags values.
    /// </summary>
    /// <param name="namespaceName">The namespace that all values should be restricted to.</param>
    /// <param name="predicate">The predicate that all values should be restricted to.</param>
    /// <param name="addedSince">Only return machine tags values that have been added since this timestamp.</param>
    /// <param name="page">The page of results to return. If this argument is omitted, it defaults to 1.</param>
    /// <param name="perPage">Number of values to return per page. If this argument is omitted, it defaults to 100. The maximum allowed value is 500.</param>
    public async Task<ValueCollection> MachineTagsGetRecentValuesAsync(string namespaceName = null, string predicate = null, DateTime? addedSince = null, CancellationToken cancellationToken = default)
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

        return await GetResponseAsync<ValueCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Return a list of unique values for a namespace and predicate.
    /// </summary>
    /// <param name="namespaceName">The namespace that all values should be restricted to.</param>
    /// <param name="predicate">The predicate that all values should be restricted to.</param>
    /// <param name="page">The page of results to return. If this argument is omitted, it defaults to 1.</param>
    /// <param name="perPage">Number of values to return per page. If this argument is omitted, it defaults to 100. The maximum allowed value is 500.</param>
    public async Task<ValueCollection> MachineTagsGetValuesAsync(string namespaceName, string predicate, int page = 0, int perPage = 0, CancellationToken cancellationToken = default)
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
}