﻿using Flickr.Net.Internals.Extensions;

namespace Flickr.Net;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrContacts
{
    async Task<Contacts> IFlickrContacts.GetListAsync(ContactType filter, int page, int perPage, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.contacts.getList" }
        };

        parameters.AppendIf("filter", filter, x => x != ContactType.None, x => x.ToString().ToLower());

        parameters.AppendIf("per_page", perPage, x => x > 0, x => x.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("page", page, x => x > 0, x => x.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        return await GetResponseAsync<Contacts>(parameters, cancellationToken);
    }

    async Task<Contacts> IFlickrContacts.GetListRecentlyUploadedAsync(ContactSearch filter, DateTime? dateLastUpdated, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.contacts.getListRecentlyUploaded" }
        };

        parameters.AppendIf("date_lastupload", dateLastUpdated, x => x.HasValue && x > DateTime.MinValue, x => x.Value.ToUnixTimestamp());

        parameters.AppendIf("filter", filter, x => x != ContactSearch.None, x => x == ContactSearch.AllContacts ? "all" : "ff");

        return await GetResponseAsync<Contacts>(parameters, cancellationToken);
    }

    async Task<Contacts> IFlickrContacts.GetPublicListAsync(string userId, int page, int perPage, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.contacts.getPublicList" },
            { "user_id", userId }
        };

        parameters.AppendIf("per_page", perPage, x => x > 0, x => x.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("page", page, x => x > 0, x => x.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        return await GetResponseAsync<Contacts>(parameters, cancellationToken);
    }

    async Task<Contacts> IFlickrContacts.GetTaggingSuggestionsAsync(int page, int perPage, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.contacts.getTaggingSuggestions" }
        };

        parameters.AppendIf("per_page", perPage, x => x > 0, x => x.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        parameters.AppendIf("page", page, x => x > 0, x => x.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));

        return await GetResponseAsync<Contacts>(parameters, cancellationToken);
    }
}

/// <summary>
/// The flickr contacts.
/// </summary>
public interface IFlickrContacts
{
    /// <summary>
    /// Gets a list of contacts for the logged in user. Requires authentication.
    /// </summary>
    /// <param name="filter">
    /// An optional filter of the results. The following values are valid: "friends", "family",
    /// "both", "neither".
    /// </param>
    /// <param name="page">
    /// The page of results to return. If this argument is omitted, it defaults to 1.
    /// </param>
    /// <param name="perPage">
    /// Number of contacts to return per page. If this argument is omitted, it defaults to 1000. The
    /// maximum allowed value is 1000.
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task<Contacts> GetListAsync(ContactType filter = ContactType.None, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

    /// <summary>
    /// Return a list of contacts for a user who have recently uploaded photos along with the total
    /// count of photos uploaded.
    /// </summary>
    /// <remarks>
    /// This method is still considered experimental. We don't plan for it to change or to go away
    /// but so long as this notice is present you should write your code accordingly.
    /// </remarks>
    /// <param name="dateLastUpdated">
    /// Limits the resultset to contacts that have uploaded photos since this date. The default
    /// offset is (1) hour and the maximum (24) hours.
    /// </param>
    /// <param name="filter">
    /// Limit the result set to all contacts or only those who are friends or family. Valid options
    /// are: "ff" friends and family, and "all" all your contacts. Default value is "all".
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task<Contacts> GetListRecentlyUploadedAsync(ContactSearch filter = ContactSearch.AllContacts, DateTime? dateLastUpdated = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a list of the given users contact, or those that are publically avaiable.
    /// </summary>
    /// <param name="userId">The Id of the user who's contacts you want to return.</param>
    /// <param name="page">
    /// The page of results to return. If this argument is omitted, it defaults to 1.
    /// </param>
    /// <param name="perPage">
    /// Number of contacts to return per page. If this argument is omitted, it defaults to 1000. The
    /// maximum allowed value is 1000.
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <return></return>
    Task<Contacts> GetPublicListAsync(string userId, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a list of contacts who Flickr suggests you might want to tag.
    /// </summary>
    /// <remarks>
    /// Not sure exactly what the purpose of this function is as it appears to just return a list of
    /// all my contacts.
    /// </remarks>
    /// <param name="page">The page of results to return. Default is 1.</param>
    /// <param name="perPage">The number of contacts to return per page.</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Contacts> GetTaggingSuggestionsAsync(int page = 0, int perPage = 0, CancellationToken cancellationToken = default);
}