using Flickr.Net.Core.Exceptions;
using Flickr.Net.Core.NewEntities.Flickr_OAuth;

namespace Flickr.Net.Core;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrPeople
{
    async Task<User> IFlickrPeople.FindByEmailAsync(string emailAddress, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.people.findByEmail" },
            { "find_email", emailAddress }
        };

        return await GetResponseAsync<User>(parameters, cancellationToken);
    }

    async Task<User> IFlickrPeople.FindByUserNameAsync(string userName, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.people.findByUsername" },
            { "username", userName }
        };

        return await GetResponseAsync<User>(parameters, cancellationToken);
    }

    async Task<Groups> IFlickrPeople.GetGroupsAsync(string userId, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.people.getGroups" },
            { "user_id", userId }
        };

        return await GetResponseAsync<Groups>(parameters, cancellationToken);
    }

    async Task<Person> IFlickrPeople.GetInfoAsync(string userId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.people.getInfo" },
            { "user_id", userId }
        };

        return await GetResponseAsync<Person>(parameters, cancellationToken);
    }

    async Task<PersonLimits> IFlickrPeople.GetLimitsAsync(CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.people.getLimits" }
        };

        return await GetResponseAsync<PersonLimits>(parameters, cancellationToken);
    }

    async Task<PhotoCollection> IFlickrPeople.GetPhotosAsync(string userId, SafetyLevel safeSearch, DateTime? minUploadDate, DateTime? maxUploadDate, DateTime? minTakenDate, DateTime? maxTakenDate, ContentTypeSearch contentType, PrivacyFilter privacyFilter, PhotoSearchExtras extras, int page, int perPage, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.people.getPhotos" },
            { "user_id", userId ?? "me" }
        };

        if (safeSearch != SafetyLevel.None)
        {
            parameters.Add("safe_search", safeSearch.ToString("d"));
        }

        if (minUploadDate.HasValue && minUploadDate > DateTime.MinValue)
        {
            parameters.Add("min_upload_date", UtilityMethods.DateToUnixTimestamp(minUploadDate.Value));
        }

        if (maxUploadDate.HasValue && maxUploadDate > DateTime.MinValue)
        {
            parameters.Add("max_upload_date", UtilityMethods.DateToUnixTimestamp(maxUploadDate.Value));
        }

        if (minTakenDate.HasValue && minTakenDate > DateTime.MinValue)
        {
            parameters.Add("min_taken_date", UtilityMethods.DateToMySql(minTakenDate.Value));
        }

        if (maxTakenDate.HasValue && maxTakenDate > DateTime.MinValue)
        {
            parameters.Add("max_taken_date", UtilityMethods.DateToMySql(maxTakenDate.Value));
        }

        if (contentType != ContentTypeSearch.None)
        {
            parameters.Add("content_type", contentType.ToString("d"));
        }

        if (privacyFilter != PrivacyFilter.None)
        {
            parameters.Add("privacy_filter", privacyFilter.ToString("d"));
        }

        if (extras != PhotoSearchExtras.None)
        {
            parameters.Add("extras", extras.ToFlickrString());
        }

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<PhotoCollection>(parameters, cancellationToken);
    }

    async Task<PeoplePhotoCollection> IFlickrPeople.GetPhotosOfAsync(string userId, PhotoSearchExtras extras, int page, int perPage, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.people.getPhotosOf" },
            { "user_id", userId ?? "me" }
        };

        if (extras != PhotoSearchExtras.None)
        {
            parameters.Add("extras", extras.ToFlickrString());
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<PeoplePhotoCollection>(parameters, cancellationToken);
    }

    async Task<UserStatus> IFlickrPeople.GetUploadStatusAsync(CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.people.getUploadStatus" }
        };

        return await GetResponseAsync<UserStatus>(parameters, cancellationToken);
    }

    async Task<Groups> IFlickrPeople.GetPublicGroupsAsync(string userId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.people.getPublicGroups" },
            { "user_id", userId }
        };

        return await GetResponseAsync<Groups>(parameters, cancellationToken);
    }
}

/// <summary>
/// The flickr people.
/// </summary>
public interface IFlickrPeople
{
    /// <summary>
    /// Used to fid a flickr users details by specifying their email address.
    /// </summary>
    /// <param name="emailAddress">The email address to search on.</param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="FlickrApiException">
    /// A FlickrApiException is raised if the email address is not found.
    /// </exception>
    Task<User> FindByEmailAsync(string emailAddress, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns a <see cref="User"/> object matching the screen name.
    /// </summary>
    /// <param name="userName">The screen name or username of the user.</param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="FlickrApiException">
    /// A FlickrApiException is raised if the email address is not found.
    /// </exception>
    Task<User> FindByUserNameAsync(string userName, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets a list of groups the user is a member of.
    /// </summary>
    /// <param name="userId">The user whose groups you wish to return.</param>
    /// <param name="cancellationToken"></param>
    Task<Groups> GetGroupsAsync(string userId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the <see cref="Person"/> object for the given user id.
    /// </summary>
    /// <param name="userId">The user id to find.</param>
    /// <param name="cancellationToken"></param>
    Task<Person> GetInfoAsync(string userId, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the limits for a person. See <see cref="PersonLimits"/> for more details.
    /// </summary>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<PersonLimits> GetLimitsAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Return photos from the given user's photostream. Only photos visible to the calling user
    /// will be returned. This method must be authenticated;
    /// </summary>
    /// <param name="userId">
    /// The NSID of the user who's photos to return. A value of "me" will return the calling user's photos.
    /// </param>
    /// <param name="safeSearch">Safe search setting</param>
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
    /// <param name="contentType">Content Type setting</param>
    /// <param name="privacyFilter">Return photos only matching a certain privacy level.</param>
    /// <param name="extras">A list of extra information to fetch for each returned record.</param>
    /// <param name="page">
    /// The page of results to return. If this argument is omitted, it defaults to 1.
    /// </param>
    /// <param name="perPage">
    /// Number of photos to return per page. If this argument is omitted, it defaults to 100. The
    /// maximum allowed value is 500.
    /// </param>
    /// <param name="cancellationToken"></param>
    Task<PhotoCollection> GetPhotosAsync(string userId, SafetyLevel safeSearch = SafetyLevel.None, DateTime? minUploadDate = null, DateTime? maxUploadDate = null, DateTime? minTakenDate = null, DateTime? maxTakenDate = null, ContentTypeSearch contentType = ContentTypeSearch.None, PrivacyFilter privacyFilter = PrivacyFilter.None, PhotoSearchExtras extras = PhotoSearchExtras.None, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the photos containing the specified user.
    /// </summary>
    /// <param name="userId">The user ID to get photos of.</param>
    /// <param name="extras">A list of extras to return for each photo.</param>
    /// <param name="page">The page of photos to return. Default is 1.</param>
    /// <param name="perPage">The number of photos to return per page.</param>
    /// <param name="cancellationToken"></param>
    Task<PeoplePhotoCollection> GetPhotosOfAsync(string userId, PhotoSearchExtras extras = PhotoSearchExtras.None, int page = 0, int perPage = 0, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the upload status of the authenticated user.
    /// </summary>
    /// <param name="cancellationToken"></param>
    Task<UserStatus> GetUploadStatusAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Get a list of public groups for a user.
    /// </summary>
    /// <param name="userId">The user id to get groups for.</param>
    /// <param name="cancellationToken"></param>
    Task<Groups> GetPublicGroupsAsync(string userId, CancellationToken cancellationToken = default);
}