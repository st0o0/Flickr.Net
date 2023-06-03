namespace Flickr.Net.Core;

public partial class Flickr : IFlickrContacts
{
    async Task<ContactCollection> IFlickrContacts.GetListAsync(ContactType filter, int page, int perPage, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.contacts.getList" }
        };

        if (filter != ContactType.None)
        {
            parameters.Add("filter", filter.ToString().ToLower());
        }

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<ContactCollection>(parameters, cancellationToken);
    }

    async Task<ContactCollection> IFlickrContacts.GetListRecentlyUploadedAsync(ContactSearch filter, DateTime? dateLastUpdated, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.contacts.getListRecentlyUploaded" }
        };

        if (dateLastUpdated.HasValue && dateLastUpdated > DateTime.MinValue)
        {
            parameters.Add("date_lastupload", UtilityMethods.DateToUnixTimestamp(dateLastUpdated.Value));
        }

        if (filter != ContactSearch.None)
        {
            var filterString = filter == ContactSearch.AllContacts ? "all" : "ff";
            parameters.Add("filter", filterString);
        }

        return await GetResponseAsync<ContactCollection>(parameters, cancellationToken);
    }

    async Task<ContactCollection> IFlickrContacts.GetPublicListAsync(string userId, int page, int perPage, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.contacts.getPublicList" },
            { "user_id", userId }
        };

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<ContactCollection>(parameters, cancellationToken);
    }

    async Task<ContactCollection> IFlickrContacts.GetTaggingSuggestionsAsync(int page, int perPage, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.contacts.getTaggingSuggestions" }
        };

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<ContactCollection>(parameters, cancellationToken);
    }
}

public interface IFlickrContacts
{
    /// <summary>
    /// Gets a list of contacts for the logged in user.
    /// Requires authentication.
    /// </summary>
    /// <param name="filter">An optional filter of the results. The following values are valid: "friends", "family", "both", "neither".</param>
    /// <param name="page">The page of results to return. If this argument is omitted, it defaults to 1.</param>
    /// <param name="perPage">Number of contacts to return per page. If this argument is omitted, it defaults to 1000. The maximum allowed value is 1000.</param>
    Task<ContactCollection> GetListAsync(ContactType filter = ContactType.None, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

    /// <summary>
    /// Return a list of contacts for a user who have recently uploaded photos along with the total count of photos uploaded.
    /// </summary>
    /// <remarks>
    /// This method is still considered experimental. We don't plan for it to change or to go away but so long as this notice is present you should write your code accordingly.
    /// </remarks>
    /// <param name="dateLastUpdated">Limits the resultset to contacts that have uploaded photos since this date. The default offset is (1) hour and the maximum (24) hours.</param>
    /// <param name="filter">Limit the result set to all contacts or only those who are friends or family. Valid options are:
    /// "ff" friends and family, and "all" all your contacts.
    /// Default value is "all".</param>
    Task<ContactCollection> GetListRecentlyUploadedAsync(ContactSearch filter = ContactSearch.AllContacts, DateTime? dateLastUpdated = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a list of the given users contact, or those that are publically avaiable.
    /// </summary>
    /// <param name="userId">The Id of the user who's contacts you want to return.</param>
    /// <param name="page">The page of results to return. If this argument is omitted, it defaults to 1.</param>
    /// <param name="perPage">Number of contacts to return per page. If this argument is omitted, it defaults to 1000. The maximum allowed value is 1000.</param>
    Task<ContactCollection> GetPublicListAsync(string userId, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a list of contacts who Flickr suggests you might want to tag.
    /// </summary>
    /// <remarks>
    /// Not sure exactly what the purpose of this function is as it appears to just return a list of all my contacts.
    /// </remarks>
    /// <param name="page">The page of results to return. Default is 1.</param>
    /// <param name="perPage">The number of contacts to return per page.</param>
    /// <returns></returns>
    Task<ContactCollection> GetTaggingSuggestionsAsync(int page = 0, int perPage = 0, CancellationToken cancellationToken = default);
}