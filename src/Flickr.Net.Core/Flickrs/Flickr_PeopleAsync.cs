using FlickrNet.Core.Exceptions;

namespace FlickrNet.Core;

public partial class Flickr
{
    /// <summary>
    /// Used to fid a flickr users details by specifying their email address.
    /// </summary>
    /// <param name="emailAddress">The email address to search on.</param>
    /// <exception cref="FlickrApiException">A FlickrApiException is raised if the email address is not found.</exception>
    public async Task<FoundUser> PeopleFindByEmailAsync(string emailAddress, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.people.findByEmail" },
            { "api_key", ApiKey },
            { "find_email", emailAddress }
        };

        return await GetResponseAsync<FoundUser>(parameters, cancellationToken);
    }

    /// <summary>
    /// Returns a <see cref="FoundUser"/> object matching the screen name.
    /// </summary>
    /// <param name="userName">The screen name or username of the user.</param>
    /// <exception cref="FlickrApiException">A FlickrApiException is raised if the email address is not found.</exception>
    public async Task<FoundUser> PeopleFindByUserNameAsync(string userName, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.people.findByUsername" },
            { "api_key", ApiKey },
            { "username", userName }
        };

        return await GetResponseAsync<FoundUser>(parameters, cancellationToken);
    }

    /// <summary>
    /// Gets a list of groups the user is a member of.
    /// </summary>
    /// <param name="userId">The user whose groups you wish to return.</param>
    public async Task<GroupInfoCollection> PeopleGetGroupsAsync(string userId, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.people.getGroups" },
            { "user_id", userId }
        };

        return await GetResponseAsync<GroupInfoCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Gets the <see cref="Person"/> object for the given user id.
    /// </summary>
    /// <param name="userId">The user id to find.</param>
    public async Task<Person> PeopleGetInfoAsync(string userId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.people.getInfo" },
            { "api_key", ApiKey },
            { "user_id", userId }
        };

        return await GetResponseAsync<Person>(parameters, cancellationToken);
    }

    /// <summary>
    /// Returns the limits for a person. See <see cref="PersonLimits"/> for more details.
    /// </summary>
    /// <returns></returns>
    public async Task<PersonLimits> PeopleGetLimitsAsync(CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.people.getLimits" }
        };

        return await GetResponseAsync<PersonLimits>(parameters, cancellationToken);
    }

    /// <summary>
    /// Gets the upload status of the authenticated user.
    /// </summary>
    public async Task<UserStatus> PeopleGetUploadStatusAsync(CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.people.getUploadStatus" }
        };

        return await GetResponseAsync<UserStatus>(parameters, cancellationToken);
    }

    /// <summary>
    /// Get a list of public groups for a user.
    /// </summary>
    /// <param name="userId">The user id to get groups for.</param>
    public async Task<GroupInfoCollection> PeopleGetPublicGroupsAsync(string userId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.people.getPublicGroups" },
            { "api_key", ApiKey },
            { "user_id", userId }
        };

        return await GetResponseAsync<GroupInfoCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Gets a users public photos. Excludes private photos.
    /// </summary>
    /// <param name="userId">The user id of the user.</param>
    public async Task<PhotoCollection> PeopleGetPublicPhotosAsync(string userId, CancellationToken cancellationToken = default)
    {
        return await PeopleGetPublicPhotosAsync(userId, 0, 0, SafetyLevel.None, PhotoSearchExtras.None, cancellationToken);
    }

    /// <summary>
    /// Gets a users public photos. Excludes private photos.
    /// </summary>
    /// <param name="userId">The user id of the user.</param>
    /// <param name="page">The page to return. Defaults to page 1.</param>
    /// <param name="perPage">The number of photos to return per page. Default is 100.</param>
    public async Task<PhotoCollection> PeopleGetPublicPhotosAsync(string userId, int page, int perPage, CancellationToken cancellationToken = default)
    {
        return await PeopleGetPublicPhotosAsync(userId, page, perPage, SafetyLevel.None, PhotoSearchExtras.None, cancellationToken);
    }

    /// <summary>
    /// Gets a users public photos. Excludes private photos.
    /// </summary>
    /// <param name="userId">The user id of the user.</param>
    /// <param name="page">The page to return. Defaults to page 1.</param>
    /// <param name="perPage">The number of photos to return per page. Default is 100.</param>
    /// <param name="extras">Which (if any) extra information to return. The default is none.</param>
    /// <param name="safetyLevel">The safety level of the returned photos.
    /// Unauthenticated calls can only return Safe photos.</param>
    public async Task<PhotoCollection> PeopleGetPublicPhotosAsync(string userId, int page, int perPage, SafetyLevel safetyLevel, PhotoSearchExtras extras, CancellationToken cancellationToken = default)
    {
        if (!IsAuthenticated && safetyLevel > SafetyLevel.Safe)
        {
            throw new ArgumentException("Safety level may only be 'Safe' for unauthenticated calls", nameof(safetyLevel));
        }

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.people.getPublicPhotos" },
            { "api_key", ApiKey },
            { "user_id", userId }
        };
        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (safetyLevel != SafetyLevel.None)
        {
            parameters.Add("safety_level", safetyLevel.ToString("D"));
        }

        if (extras != PhotoSearchExtras.None)
        {
            parameters.Add("extras", UtilityMethods.ExtrasToString(extras));
        }

        return await GetResponseAsync<PhotoCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Return photos from the calling user's photostream. This method must be authenticated;
    /// </summary>
    public async Task<PhotoCollection> PeopleGetPhotosAsync(CancellationToken cancellationToken = default)
    {
        return await PeopleGetPhotosAsync(null, SafetyLevel.None, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue,
                             DateTime.MinValue, ContentTypeSearch.None, PrivacyFilter.None, PhotoSearchExtras.None,
                             0, 0, cancellationToken);
    }

    /// <summary>
    /// Return photos from the calling user's photostream. This method must be authenticated;
    /// </summary>
    /// <param name="page">The page of results to return. If this argument is omitted, it defaults to 1.</param>
    /// <param name="perPage">Number of photos to return per page. If this argument is omitted, it defaults to 100. The maximum allowed value is 500.</param>
    public async Task<PhotoCollection> PeopleGetPhotosAsync(int page, int perPage, CancellationToken cancellationToken = default)
    {
        return await PeopleGetPhotosAsync(null, SafetyLevel.None, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue,
                             DateTime.MinValue, ContentTypeSearch.None, PrivacyFilter.None, PhotoSearchExtras.None,
                             page, perPage, cancellationToken);
    }

    /// <summary>
    /// Return photos from the calling user's photostream. This method must be authenticated;
    /// </summary>
    /// <param name="extras">A list of extra information to fetch for each returned record.</param>
    public async Task<PhotoCollection> PeopleGetPhotosAsync(PhotoSearchExtras extras, CancellationToken cancellationToken = default)
    {
        return await PeopleGetPhotosAsync(null, SafetyLevel.None, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue,
                             DateTime.MinValue, ContentTypeSearch.None, PrivacyFilter.None, extras, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Return photos from the calling user's photostream. This method must be authenticated;
    /// </summary>
    /// <param name="extras">A list of extra information to fetch for each returned record.</param>
    /// <param name="page">The page of results to return. If this argument is omitted, it defaults to 1.</param>
    /// <param name="perPage">Number of photos to return per page. If this argument is omitted, it defaults to 100. The maximum allowed value is 500.</param>
    public async Task<PhotoCollection> PeopleGetPhotosAsync(PhotoSearchExtras extras, int page, int perPage,
                                     CancellationToken cancellationToken = default)
    {
        return await PeopleGetPhotosAsync(null, SafetyLevel.None, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue,
                             DateTime.MinValue, ContentTypeSearch.None, PrivacyFilter.None, extras, page, perPage,
                             cancellationToken);
    }

    /// <summary>
    /// Return photos from the given user's photostream. Only photos visible to the calling user will be returned. This method must be authenticated;
    /// </summary>
    /// <param name="userId">The NSID of the user who's photos to return. A value of "me" will return the calling user's photos.</param>
    public async Task<PhotoCollection> PeopleGetPhotosAsync(string userId, CancellationToken cancellationToken = default)
    {
        return await PeopleGetPhotosAsync(userId, SafetyLevel.None, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue,
                             DateTime.MinValue, ContentTypeSearch.None, PrivacyFilter.None, PhotoSearchExtras.None,
                             0, 0, cancellationToken);
    }

    /// <summary>
    /// Return photos from the given user's photostream. Only photos visible to the calling user will be returned. This method must be authenticated;
    /// </summary>
    /// <param name="userId">The NSID of the user who's photos to return. A value of "me" will return the calling user's photos.</param>
    /// <param name="page">The page of results to return. If this argument is omitted, it defaults to 1.</param>
    /// <param name="perPage">Number of photos to return per page. If this argument is omitted, it defaults to 100. The maximum allowed value is 500.</param>
    public async Task<PhotoCollection> PeopleGetPhotosAsync(string userId, int page, int perPage,
                                     CancellationToken cancellationToken = default)
    {
        return await PeopleGetPhotosAsync(userId, SafetyLevel.None, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue,
                             DateTime.MinValue, ContentTypeSearch.None, PrivacyFilter.None, PhotoSearchExtras.None,
                             page, perPage, cancellationToken);
    }

    /// <summary>
    /// Return photos from the given user's photostream. Only photos visible to the calling user will be returned. This method must be authenticated;
    /// </summary>
    /// <param name="userId">The NSID of the user who's photos to return. A value of "me" will return the calling user's photos.</param>
    /// <param name="extras">A list of extra information to fetch for each returned record.</param>
    public async Task<PhotoCollection> PeopleGetPhotosAsync(string userId, PhotoSearchExtras extras,
                                     CancellationToken cancellationToken = default)
    {
        return await PeopleGetPhotosAsync(userId, SafetyLevel.None, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue,
                             DateTime.MinValue, ContentTypeSearch.None, PrivacyFilter.None, extras, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Return photos from the given user's photostream. Only photos visible to the calling user will be returned. This method must be authenticated;
    /// </summary>
    /// <param name="userId">The NSID of the user who's photos to return. A value of "me" will return the calling user's photos.</param>
    /// <param name="extras">A list of extra information to fetch for each returned record.</param>
    /// <param name="page">The page of results to return. If this argument is omitted, it defaults to 1.</param>
    /// <param name="perPage">Number of photos to return per page. If this argument is omitted, it defaults to 100. The maximum allowed value is 500.</param>
    public async Task<PhotoCollection> PeopleGetPhotosAsync(string userId, PhotoSearchExtras extras, int page, int perPage,
                                     CancellationToken cancellationToken = default)
    {
        return await PeopleGetPhotosAsync(userId, SafetyLevel.None, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue,
                             DateTime.MinValue, ContentTypeSearch.None, PrivacyFilter.None, extras, page, perPage,
                             cancellationToken);
    }

    /// <summary>
    /// Return photos from the given user's photostream. Only photos visible to the calling user will be returned. This method must be authenticated;
    /// </summary>
    /// <param name="userId">The NSID of the user who's photos to return. A value of "me" will return the calling user's photos.</param>
    /// <param name="safeSearch">Safe search setting</param>
    /// <param name="minUploadDate">Minimum upload date. Photos with an upload date greater than or equal to this value will be returned.</param>
    /// <param name="maxUploadDate">Maximum upload date. Photos with an upload date less than or equal to this value will be returned.</param>
    /// <param name="minTakenDate">Minimum taken date. Photos with an taken date greater than or equal to this value will be returned. </param>
    /// <param name="maxTakenDate">Maximum taken date. Photos with an taken date less than or equal to this value will be returned. </param>
    /// <param name="contentType">Content Type setting</param>
    /// <param name="privacyFilter">Return photos only matching a certain privacy level.</param>
    /// <param name="extras">A list of extra information to fetch for each returned record.</param>
    /// <param name="page">The page of results to return. If this argument is omitted, it defaults to 1.</param>
    /// <param name="perPage">Number of photos to return per page. If this argument is omitted, it defaults to 100. The maximum allowed value is 500.</param>
    public async Task<PhotoCollection> PeopleGetPhotosAsync(string userId, SafetyLevel safeSearch, DateTime minUploadDate, DateTime maxUploadDate, DateTime minTakenDate, DateTime maxTakenDate, ContentTypeSearch contentType, PrivacyFilter privacyFilter, PhotoSearchExtras extras, int page, int perPage, CancellationToken cancellationToken = default)
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

        if (minUploadDate != DateTime.MinValue)
        {
            parameters.Add("min_upload_date", UtilityMethods.DateToUnixTimestamp(minUploadDate));
        }

        if (maxUploadDate != DateTime.MinValue)
        {
            parameters.Add("max_upload_date", UtilityMethods.DateToUnixTimestamp(maxUploadDate));
        }

        if (minTakenDate != DateTime.MinValue)
        {
            parameters.Add("min_taken_date", UtilityMethods.DateToMySql(minTakenDate));
        }

        if (maxTakenDate != DateTime.MinValue)
        {
            parameters.Add("max_taken_date", UtilityMethods.DateToMySql(maxTakenDate));
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
            parameters.Add("extras", UtilityMethods.ExtrasToString(extras));
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

    /// <summary>
    /// Gets the photos containing the authenticated user. Requires that the AuthToken has been set.
    /// </summary>
    public async Task<PeoplePhotoCollection> PeopleGetPhotosOfAsync(CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        return await PeopleGetPhotosOfAsync("me", PhotoSearchExtras.None, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Gets the photos containing the specified user.
    /// </summary>
    /// <param name="userId">The user ID to get photos of.</param>
    public async Task<PeoplePhotoCollection> PeopleGetPhotosOfAsync(string userId, CancellationToken cancellationToken = default)
    {
        return await PeopleGetPhotosOfAsync(userId, PhotoSearchExtras.None, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Gets the photos containing the specified user.
    /// </summary>
    /// <param name="userId">The user ID to get photos of.</param>
    /// <param name="extras">A list of extras to return for each photo.</param>
    public async Task<PeoplePhotoCollection> PeopleGetPhotosOfAsync(string userId, PhotoSearchExtras extras, CancellationToken cancellationToken = default)
    {
        return await PeopleGetPhotosOfAsync(userId, extras, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Gets the photos containing the specified user.
    /// </summary>
    /// <param name="userId">The user ID to get photos of.</param>
    /// <param name="perPage">The number of photos to return per page.</param>
    /// <param name="page">The page of photos to return. Default is 1.</param>
    public async Task<PeoplePhotoCollection> PeopleGetPhotosOfAsync(string userId, int page, int perPage, CancellationToken cancellationToken = default)
    {
        return await PeopleGetPhotosOfAsync(userId, PhotoSearchExtras.None, page, perPage, cancellationToken);
    }

    /// <summary>
    /// Gets the photos containing the specified user.
    /// </summary>
    /// <param name="userId">The user ID to get photos of.</param>
    /// <param name="extras">A list of extras to return for each photo.</param>
    /// <param name="perPage">The number of photos to return per page.</param>
    /// <param name="page">The page of photos to return. Default is 1.</param>
    public async Task<PeoplePhotoCollection> PeopleGetPhotosOfAsync(string userId, PhotoSearchExtras extras, int page, int perPage, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.people.getPhotosOf" },
            { "user_id", userId }
        };
        if (extras != PhotoSearchExtras.None)
        {
            parameters.Add("extras", UtilityMethods.ExtrasToString(extras));
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
}