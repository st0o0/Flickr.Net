using FlickrNet.Core.Exceptions;
using FlickrNet.Core.SearchOptions;

namespace FlickrNet.Core;

public partial class Flickr
{
    /// <summary>
    /// Add a selection of tags to a photo.
    /// </summary>
    /// <param name="photoId">The photo id of the photo.</param>
    /// <param name="tags">An array of strings containing the tags.</param>
    public async Task PhotosAddTagsAsync(string photoId, string[] tags, CancellationToken cancellationToken = default)
    {
        string s = string.Join(",", tags);
        await PhotosAddTagAsync(photoId, s, cancellationToken);
    }

    /// <summary>
    /// Add a selection of tags to a photo.
    /// </summary>
    /// <param name="photoId">The photo id of the photo.</param>
    /// <param name="tags">An string of comma delimited tags.</param>
    public async Task PhotosAddTagAsync(string photoId, string tags, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.addTags" },
            { "photo_id", photoId },
            { "tags", tags }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Delete a photo from Flickr.
    /// </summary>
    /// <remarks>
    /// Requires Delete permissions. Also note, photos cannot be recovered once deleted.</remarks>
    /// <param name="photoId">The ID of the photo to delete.</param>
    public async Task PhotoDeleteAsync(string photoId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.delete" },
            { "photo_id", photoId }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Get all the contexts (group, set and photostream 'next' and 'previous'
    /// pictures) for a photo.
    /// </summary>
    /// <param name="photoId">The photo id of the photo to get the contexts for.</param>
    public async Task<AllContexts> PhotosGetAllContextsAsync(string photoId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.getAllContexts" },
            { "photo_id", photoId }
        };

        return await GetResponseAsync<AllContexts>(parameters, cancellationToken);
    }

    /// <summary>
    /// Gets the most recent 10 photos from your contacts.
    /// </summary>
    public async Task<PhotoCollection> PhotosGetContactsPhotosAsync(CancellationToken cancellationToken = default)
    {
        return await PhotosGetContactsPhotosAsync(0, false, false, false, PhotoSearchExtras.None, cancellationToken);
    }

    /// <summary>
    /// Gets the most recent photos from your contacts.
    /// </summary>
    /// <remarks>Returns the most recent photos from all your contact, excluding yourself.</remarks>
    /// <param name="count">The number of photos to return, from between 10 and 50.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Throws a <see cref="ArgumentOutOfRangeException"/> exception if the cound
    /// is not between 10 and 50, or 0.</exception>
    public async Task<PhotoCollection> PhotosGetContactsPhotosAsync(int count, CancellationToken cancellationToken = default)
    {
        return await PhotosGetContactsPhotosAsync(count, false, false, false, PhotoSearchExtras.None, cancellationToken);
    }

    /// <summary>
    /// Gets your contacts most recent photos.
    /// </summary>
    /// <param name="count">The number of photos to return, from between 10 and 50.</param>
    /// <param name="justFriends">If true only returns photos from contacts marked as
    /// 'friends'.</param>
    /// <param name="singlePhoto">If true only returns a single photo for each of your contacts.
    /// Ignores the count if this is true.</param>
    /// <param name="includeSelf">If true includes yourself in the group of people to
    /// return photos for.</param>
    /// <param name="extras">Optional extras that can be returned by this call.</param>
    /// <exception cref="ArgumentOutOfRangeException">
    /// Throws a <see cref="ArgumentOutOfRangeException"/> exception if the cound
    /// is not between 10 and 50, or 0.</exception>
    public async Task<PhotoCollection> PhotosGetContactsPhotosAsync(int count, bool justFriends, bool singlePhoto, bool includeSelf, PhotoSearchExtras extras, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        if (count != 0 && (count < 10 || count > 50) && !singlePhoto)
        {
            throw new ArgumentOutOfRangeException(nameof(count), string.Format(System.Globalization.CultureInfo.InvariantCulture, "Count must be between 10 and 50. ({0})", count));
        }
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.getContactsPhotos" }
        };
        if (count > 0 && !singlePhoto)
        {
            parameters.Add("count", count.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (justFriends)
        {
            parameters.Add("just_friends", "1");
        }

        if (singlePhoto)
        {
            parameters.Add("single_photo", "1");
        }

        if (includeSelf)
        {
            parameters.Add("include_self", "1");
        }

        if (extras != PhotoSearchExtras.None)
        {
            parameters.Add("extras", UtilityMethods.ExtrasToString(extras));
        }

        return await GetResponseAsync<PhotoCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Gets the public photos for given users ID's contacts.
    /// </summary>
    /// <param name="userId">The user ID whose contacts you wish to get photos for.</param>
    public async Task<PhotoCollection> PhotosGetContactsPublicPhotosAsync(string userId, CancellationToken cancellationToken = default)
    {
        return await PhotosGetContactsPublicPhotosAsync(userId, 0, false, false, false, PhotoSearchExtras.None, cancellationToken);
    }

    /// <summary>
    /// Gets the public photos for given users ID's contacts.
    /// </summary>
    /// <param name="userId">The user ID whose contacts you wish to get photos for.</param>
    /// <param name="extras">A list of extra details to return for each photo.</param>
    public async Task<PhotoCollection> PhotosGetContactsPublicPhotosAsync(string userId, PhotoSearchExtras extras, CancellationToken cancellationToken = default)
    {
        return await PhotosGetContactsPublicPhotosAsync(userId, 0, false, false, false, extras, cancellationToken);
    }

    /// <summary>
    /// Gets the public photos for given users ID's contacts.
    /// </summary>
    /// <param name="userId">The user ID whose contacts you wish to get photos for.</param>
    /// <param name="count">The number of photos to return. Defaults to 10, maximum is 50.</param>
    public async Task<PhotoCollection> PhotosGetContactsPublicPhotosAsync(string userId, int count, CancellationToken cancellationToken = default)
    {
        return await PhotosGetContactsPublicPhotosAsync(userId, count, false, false, false, PhotoSearchExtras.None, cancellationToken);
    }

    /// <summary>
    /// Gets the public photos for given users ID's contacts.
    /// </summary>
    /// <param name="userId">The user ID whose contacts you wish to get photos for.</param>
    /// <param name="count">The number of photos to return. Defaults to 10, maximum is 50.</param>
    /// <param name="extras">A list of extra details to return for each photo.</param>
    public async Task<PhotoCollection> PhotosGetContactsPublicPhotosAsync(string userId, int count, PhotoSearchExtras extras, CancellationToken cancellationToken = default)
    {
        return await PhotosGetContactsPublicPhotosAsync(userId, count, false, false, false, extras, cancellationToken);
    }

    /// <summary>
    /// Gets the public photos for given users ID's contacts.
    /// </summary>
    /// <param name="userId">The user ID whose contacts you wish to get photos for.</param>
    /// <param name="count">The number of photos to return. Defaults to 10, maximum is 50.</param>
    /// <param name="justFriends">True to just return photos from friends and family (excluding regular contacts).</param>
    /// <param name="singlePhoto">True to return just a single photo for each contact.</param>
    /// <param name="includeSelf">True to include photos from the user ID specified as well.</param>
    public async Task<PhotoCollection> PhotosGetContactsPublicPhotosAsync(string userId, int count, bool justFriends, bool singlePhoto, bool includeSelf, CancellationToken cancellationToken = default)
    {
        return await PhotosGetContactsPublicPhotosAsync(userId, count, justFriends, singlePhoto, includeSelf, PhotoSearchExtras.None, cancellationToken);
    }

    /// <summary>
    /// Gets the public photos for given users ID's contacts.
    /// </summary>
    /// <param name="userId">The user ID whose contacts you wish to get photos for.</param>
    /// <param name="count">The number of photos to return. Defaults to 10, maximum is 50.</param>
    /// <param name="justFriends">True to just return photos from friends and family (excluding regular contacts).</param>
    /// <param name="singlePhoto">True to return just a single photo for each contact.</param>
    /// <param name="includeSelf">True to include photos from the user ID specified as well.</param>
    /// <param name="extras">A list of extra details to return for each photo.</param>
    public async Task<PhotoCollection> PhotosGetContactsPublicPhotosAsync(string userId, int count, bool justFriends, bool singlePhoto, bool includeSelf, PhotoSearchExtras extras, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.getContactsPublicPhotos" },
            { "api_key", ApiKey },
            { "user_id", userId }
        };
        if (count > 0)
        {
            parameters.Add("count", count.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (justFriends)
        {
            parameters.Add("just_friends", "1");
        }

        if (singlePhoto)
        {
            parameters.Add("single_photo", "1");
        }

        if (includeSelf)
        {
            parameters.Add("include_self", "1");
        }

        if (extras != PhotoSearchExtras.None)
        {
            parameters.Add("extras", UtilityMethods.ExtrasToString(extras));
        }

        return await GetResponseAsync<PhotoCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Gets the context of the photo in the users photostream.
    /// </summary>
    /// <param name="photoId">The ID of the photo to return the context for.</param>
    public async Task<Context> PhotosGetContextAsync(string photoId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.getContext" },
            { "photo_id", photoId }
        };

        return await GetResponseAsync<Context>(parameters, cancellationToken);
    }

    /// <summary>
    /// Returns count of photos between each pair of dates in the list.
    /// </summary>
    /// <remarks>If you pass in DateA, DateB and DateC it returns
    /// a list of the number of photos between DateA and DateB,
    /// followed by the number between DateB and DateC.
    /// More parameters means more sets.</remarks>
    /// <param name="dates">Array of <see cref="DateTime"/> objects representing upload dates.</param>
    public async Task<PhotoCountCollection> PhotosGetCountsAsync(DateTime[] dates, CancellationToken cancellationToken = default)
    {
        return await PhotosGetCountsAsync(dates, false, cancellationToken);
    }

    /// <summary>
    /// Returns count of photos between each pair of dates in the list.
    /// </summary>
    /// <remarks>If you pass in DateA, DateB and DateC it returns
    /// a list of the number of photos between DateA and DateB,
    /// followed by the number between DateB and DateC.
    /// More parameters means more sets.</remarks>
    /// <param name="dates">Array of <see cref="DateTime"/> objects.</param>
    /// <param name="taken">Boolean parameter to specify if the dates are the taken date, or uploaded date.</param>
    public async Task<PhotoCountCollection> PhotosGetCountsAsync(DateTime[] dates, bool taken, CancellationToken cancellationToken = default)
    {
        if (taken)
        {
            return await PhotosGetCountsAsync(null, dates, cancellationToken);
        }
        else
        {
            return await PhotosGetCountsAsync(dates, null, cancellationToken);
        }
    }

    /// <summary>
    /// Returns count of photos between each pair of dates in the list.
    /// </summary>
    /// <remarks>If you pass in DateA, DateB and DateC it returns
    /// a list of the number of photos between DateA and DateB,
    /// followed by the number between DateB and DateC.
    /// More parameters means more sets.</remarks>
    /// <param name="dates">Comma-delimited list of dates in unix timestamp format. Optional.</param>
    /// <param name="takenDates">Comma-delimited list of dates in unix timestamp format. Optional.</param>
    public async Task<PhotoCountCollection> PhotosGetCountsAsync(DateTime[] dates, DateTime[] takenDates, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        string dateString = null;
        string takenDateString = null;

        if (dates != null && dates.Length > 0)
        {
            Array.Sort<DateTime>(dates);

            dateString = string.Join(",", new List<DateTime>(dates).ConvertAll<string>(new Converter<DateTime, string>(delegate (DateTime d)
            {
                return UtilityMethods.DateToUnixTimestamp(d).ToString();
            })).ToArray());
        }

        if (takenDates != null && takenDates.Length > 0)
        {
            Array.Sort<DateTime>(takenDates);
            takenDateString = string.Join(",", new List<DateTime>(takenDates).ConvertAll<string>(new Converter<DateTime, string>(delegate (DateTime d)
                {
                    return UtilityMethods.DateToUnixTimestamp(d).ToString();
                })).ToArray());
        }

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.getCounts" }
        };
        if (dateString != null && dateString.Length > 0)
        {
            parameters.Add("dates", dateString);
        }

        if (takenDateString != null && takenDateString.Length > 0)
        {
            parameters.Add("taken_dates", takenDateString);
        }

        return await GetResponseAsync<PhotoCountCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Gets the EXIF data for a given Photo ID.
    /// </summary>
    /// <param name="photoId">The Photo ID of the photo to return the EXIF data for.</param>
    public async Task<ExifTagCollection> PhotosGetExifAsync(string photoId, CancellationToken cancellationToken = default)
    {
        return await PhotosGetExifAsync(photoId, null, cancellationToken);
    }

    /// <summary>
    /// Gets the EXIF data for a given Photo ID.
    /// </summary>
    /// <param name="photoId">The Photo ID of the photo to return the EXIF data for.</param>
    /// <param name="secret">The secret of the photo. If the secret is specified then
    /// authentication checks are bypassed.</param>
    public async Task<ExifTagCollection> PhotosGetExifAsync(string photoId, string secret, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.getExif" },
            { "photo_id", photoId }
        };
        if (secret != null)
        {
            parameters.Add("secret", secret);
        }

        return await GetResponseAsync<ExifTagCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Get information about a photo. The calling user must have permission to view the photo.
    /// </summary>
    /// <param name="photoId">The id of the photo to fetch information for.</param>
    public async Task<PhotoInfo> PhotosGetInfoAsync(string photoId, CancellationToken cancellationToken = default)
    {
        return await PhotosGetInfoAsync(photoId, null, cancellationToken);
    }

    /// <summary>
    /// Get information about a photo. The calling user must have permission to view the photo.
    /// </summary>
    /// <param name="photoId">The id of the photo to fetch information for.</param>
    /// <param name="secret">The secret for the photo. If the correct secret is passed then permissions checking is skipped.
    /// This enables the 'sharing' of individual photos by passing around the id and secret.</param>
    public async Task<PhotoInfo> PhotosGetInfoAsync(string photoId, string secret, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.getInfo" },
            { "photo_id", photoId }
        };
        if (secret != null)
        {
            parameters.Add("secret", secret);
        }

        return await GetResponseAsync<PhotoInfo>(parameters, cancellationToken);
    }

    /// <summary>
    /// Get permissions for a photo.
    /// </summary>
    /// <param name="photoId">The id of the photo to get permissions for.</param>
    public async Task<PhotoPermissions> PhotosGetPermsAsync(string photoId, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.getPerms" },
            { "photo_id", photoId }
        };

        return await GetResponseAsync<PhotoPermissions>(parameters, cancellationToken);
    }

    /// <summary>
    /// Get a users popular photos
    /// </summary>
    /// <param name="userId">The user id - if null then it is the authenticated user.</param>
    /// <param name="extras"></param>
    /// <param name="sort"></param>
    /// <param name="perPage"></param>
    /// <param name="page"></param>
    /// <returns></returns>
    public async Task<PhotoCollection> PhotosGetPopularAsync(string userId, PhotoSearchExtras extras = PhotoSearchExtras.None, string sort = "interesting", int perPage = 100, int page = 1, CancellationToken cancellationToken = default)
    {
        if (userId == null)
        {
            CheckRequiresAuthentication();
        }

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.getPopular" }
        };
        if (userId != null)
        {
            parameters.Add("user_id", userId);
        }
        parameters.Add("sort", sort);
        parameters.Add("extras", UtilityMethods.ExtrasToString(extras));
        parameters.Add("per_page", perPage.ToString("0"));
        parameters.Add("page", page.ToString("0"));

        return await GetResponseAsync<PhotoCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Returns a list of the latest public photos uploaded to flickr.
    /// </summary>
    public async Task<PhotoCollection> PhotosGetRecentAsync(CancellationToken cancellationToken = default)
    {
        return await PhotosGetRecentAsync(0, 0, PhotoSearchExtras.None, cancellationToken);
    }

    /// <summary>
    /// Returns a list of the latest public photos uploaded to flickr.
    /// </summary>
    /// <param name="extras">A comma-delimited list of extra information to fetch for each returned record.</param>
    public async Task<PhotoCollection> PhotosGetRecentAsync(PhotoSearchExtras extras, CancellationToken cancellationToken = default)
    {
        return await PhotosGetRecentAsync(0, 0, extras, cancellationToken);
    }

    /// <summary>
    /// Returns a list of the latest public photos uploaded to flickr.
    /// </summary>
    /// <param name="page">The page of results to return. If this argument is omitted, it defaults to 1.</param>
    /// <param name="perPage">Number of photos to return per page. If this argument is omitted, it defaults to 100. The maximum allowed value is 500.</param>
    public async Task<PhotoCollection> PhotosGetRecentAsync(int page, int perPage, CancellationToken cancellationToken = default)
    {
        return await PhotosGetRecentAsync(page, perPage, PhotoSearchExtras.None, cancellationToken);
    }

    /// <summary>
    /// Returns a list of the latest public photos uploaded to flickr.
    /// </summary>
    /// <param name="extras">A comma-delimited list of extra information to fetch for each returned record.</param>
    /// <param name="page">The page of results to return. If this argument is omitted, it defaults to 1.</param>
    /// <param name="perPage">Number of photos to return per page. If this argument is omitted, it defaults to 100. The maximum allowed value is 500.</param>
    public async Task<PhotoCollection> PhotosGetRecentAsync(int page, int perPage, PhotoSearchExtras extras, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.getRecent" },
            { "api_key", ApiKey }
        };
        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (extras != PhotoSearchExtras.None)
        {
            parameters.Add("extras", UtilityMethods.ExtrasToString(extras));
        }

        return await GetResponseAsync<PhotoCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Returns the available sizes for a photo. The calling user must have permission to view the photo.
    /// </summary>
    /// <param name="photoId">The id of the photo to fetch size information for.</param>
    public async Task<SizeCollection> PhotosGetSizesAsync(string photoId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.getSizes" },
            { "photo_id", photoId }
        };

        return await GetResponseAsync<SizeCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Returns a list of your photos with no tags.
    /// </summary>
    public async Task<PhotoCollection> PhotosGetUntaggedAsync(CancellationToken cancellationToken = default)
    {
        return await PhotosGetUntaggedAsync(0, 0, PhotoSearchExtras.None, cancellationToken);
    }

    /// <summary>
    /// Returns a list of your photos with no tags.
    /// </summary>
    /// <param name="extras">A comma-delimited list of extra information to fetch for each returned record.</param>
    public async Task<PhotoCollection> PhotosGetUntaggedAsync(PhotoSearchExtras extras, CancellationToken cancellationToken = default)
    {
        return await PhotosGetUntaggedAsync(0, 0, extras, cancellationToken);
    }

    /// <summary>
    /// Returns a list of your photos with no tags.
    /// </summary>
    /// <param name="page">The page of results to return. If this argument is omitted, it defaults to 1.</param>
    /// <param name="perPage">Number of photos to return per page. If this argument is omitted, it defaults to 100. The maximum allowed value is 500.</param>
    public async Task<PhotoCollection> PhotosGetUntaggedAsync(int page, int perPage, CancellationToken cancellationToken = default)
    {
        return await PhotosGetUntaggedAsync(page, perPage, PhotoSearchExtras.None, cancellationToken);
    }

    /// <summary>
    /// Returns a list of your photos with no tags.
    /// </summary>
    /// <param name="extras">A comma-delimited list of extra information to fetch for each returned record.</param>
    /// <param name="page">The page of results to return. If this argument is omitted, it defaults to 1.</param>
    /// <param name="perPage">Number of photos to return per page. If this argument is omitted, it defaults to 100. The maximum allowed value is 500.</param>
    public async Task<PhotoCollection> PhotosGetUntaggedAsync(int page, int perPage, PhotoSearchExtras extras, CancellationToken cancellationToken = default)
    {
        PartialSearchOptions o = new();
        o.Page = page;
        o.PerPage = perPage;
        o.Extras = extras;

        return await PhotosGetUntaggedAsync(o, cancellationToken);
    }

    /// <summary>
    /// Returns a list of your photos with no tags.
    /// </summary>
    /// <param name="options">The <see cref="PartialSearchOptions"/> containing the list of options supported by this method.</param>
    public async Task<PhotoCollection> PhotosGetUntaggedAsync(PartialSearchOptions options, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.getUntagged" }
        };

        UtilityMethods.PartialOptionsIntoArray(options, parameters);
        return await GetResponseAsync<PhotoCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Gets a list of photos not in sets. Defaults to include all extra fields.
    /// </summary>
    public async Task<PhotoCollection> PhotosGetNotInSetAsync(CancellationToken cancellationToken = default)
    {
        return await PhotosGetNotInSetAsync(new PartialSearchOptions(), cancellationToken);
    }

    /// <summary>
    /// Gets a specific page of the list of photos which are not in sets.
    /// Defaults to include all extra fields.
    /// </summary>
    /// <param name="page">The page number to return.</param>
    public async Task<PhotoCollection> PhotosGetNotInSetAsync(int page, CancellationToken cancellationToken = default)
    {
        return await PhotosGetNotInSetAsync(page, 0, PhotoSearchExtras.None, cancellationToken);
    }

    /// <summary>
    /// Gets a specific page of the list of photos which are not in sets.
    /// Defaults to include all extra fields.
    /// </summary>
    /// <param name="perPage">Number of photos per page.</param>
    /// <param name="page">The page number to return.</param>
    public async Task<PhotoCollection> PhotosGetNotInSetAsync(int page, int perPage, CancellationToken cancellationToken = default)
    {
        return await PhotosGetNotInSetAsync(page, perPage, PhotoSearchExtras.None, cancellationToken);
    }

    /// <summary>
    /// Gets a list of a users photos which are not in a set.
    /// </summary>
    /// <param name="perPage">Number of photos per page.</param>
    /// <param name="page">The page number to return.</param>
    /// <param name="extras"><see cref="PhotoSearchExtras"/> enumeration.</param>
    public async Task<PhotoCollection> PhotosGetNotInSetAsync(int page, int perPage, PhotoSearchExtras extras, CancellationToken cancellationToken = default)
    {
        PartialSearchOptions options = new();
        options.PerPage = perPage;
        options.Page = page;
        options.Extras = extras;

        return await PhotosGetNotInSetAsync(options, cancellationToken);
    }

    /// <summary>
    /// Gets a list of the authenticated users photos which are not in a set.
    /// </summary>
    /// <param name="options">A selection of options to filter/sort by.</param>
    public async Task<PhotoCollection> PhotosGetNotInSetAsync(PartialSearchOptions options, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.getNotInSet" }
        };
        UtilityMethods.PartialOptionsIntoArray(options, parameters);

        return await GetResponseAsync<PhotoCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Gets a list of all current licenses.
    /// </summary>
    public async Task<LicenseCollection> PhotosLicensesGetInfoAsync(CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.licenses.getInfo" },
            { "api_key", ApiKey }
        };

        return await GetResponseAsync<LicenseCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Sets the license for a photo.
    /// </summary>
    /// <param name="photoId">The photo to update the license for.</param>
    /// <param name="license">The license to apply, or <see cref="LicenseType.AllRightsReserved"/> (0) to remove the current license.
    /// Note : as of this writing the <see cref="LicenseType.NoKnownCopyrightRestrictions"/> license (7) is not a valid argument.</param>
    public async Task PhotosLicensesSetLicenseAsync(string photoId, LicenseType license, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.licenses.setLicense" },
            { "photo_id", photoId },
            { "license_id", license.ToString("d") }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Remove an existing tag.
    /// </summary>
    /// <param name="tagId">The id of the tag, as returned by <see cref="Flickr.PhotosGetInfo(string)"/> or similar method.</param>
    public async Task PhotosRemoveTagAsync(string tagId, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.removeTag" },
            { "tag_id", tagId }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Return a list of your photos that have been recently created or which have been recently modified.
    /// Recently modified may mean that the photo's metadata (title, description, tags)
    /// may have been changed or a comment has been added (or just modified somehow :-)
    /// </summary>
    /// <param name="minDate">The date from which modifications should be compared.</param>
    /// <param name="extras">A list of extra information to fetch for each returned record.</param>
    public async Task<PhotoCollection> PhotosRecentlyUpdatedAsync(DateTime minDate, PhotoSearchExtras extras, CancellationToken cancellationToken = default)
    {
        return await PhotosRecentlyUpdatedAsync(minDate, extras, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Return a list of your photos that have been recently created or which have been recently modified.
    /// Recently modified may mean that the photo's metadata (title, description, tags)
    /// may have been changed or a comment has been added (or just modified somehow :-)
    /// </summary>
    /// <param name="minDate">The date from which modifications should be compared.</param>
    /// <param name="perPage">Number of photos to return per page. If this argument is omitted, it defaults to 100. The maximum allowed value is 500.</param>
    /// <param name="page">The page of results to return. If this argument is omitted, it defaults to 1.</param>
    public async Task<PhotoCollection> PhotosRecentlyUpdatedAsync(DateTime minDate, int page, int perPage, CancellationToken cancellationToken = default)
    {
        return await PhotosRecentlyUpdatedAsync(minDate, PhotoSearchExtras.None, page, perPage, cancellationToken);
    }

    /// <summary>
    /// Return a list of your photos that have been recently created or which have been recently modified.
    /// Recently modified may mean that the photo's metadata (title, description, tags)
    /// may have been changed or a comment has been added (or just modified somehow :-)
    /// </summary>
    /// <param name="minDate">The date from which modifications should be compared.</param>
    public async Task<PhotoCollection> PhotosRecentlyUpdatedAsync(DateTime minDate, CancellationToken cancellationToken = default)
    {
        return await PhotosRecentlyUpdatedAsync(minDate, PhotoSearchExtras.None, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Return a list of your photos that have been recently created or which have been recently modified.
    /// Recently modified may mean that the photo's metadata (title, description, tags)
    /// may have been changed or a comment has been added (or just modified somehow :-)
    /// </summary>
    /// <param name="minDate">The date from which modifications should be compared.</param>
    /// <param name="extras">A list of extra information to fetch for each returned record.</param>
    /// <param name="perPage">Number of photos to return per page. If this argument is omitted, it defaults to 100. The maximum allowed value is 500.</param>
    /// <param name="page">The page of results to return. If this argument is omitted, it defaults to 1.</param>
    public async Task<PhotoCollection> PhotosRecentlyUpdatedAsync(DateTime minDate, PhotoSearchExtras extras, int page, int perPage, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.recentlyUpdated" },
            { "min_date", UtilityMethods.DateToUnixTimestamp(minDate) }
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

        return await GetResponseAsync<PhotoCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Search for a set of photos, based on the value of the <see cref="PhotoSearchOptions"/> parameters.
    /// </summary>
    /// <param name="options">The parameters to search for.</param>
    public async Task<PhotoCollection> PhotosSearchAsync(PhotoSearchOptions options, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.search" }
        };

        options.AddToDictionary(ref parameters);

        return await GetResponseAsync<PhotoCollection>(parameters, cancellationToken);
    }

    /// <summary>
    /// Set the date taken for a photo.
    /// </summary>
    /// <remarks>
    /// All dates are assumed to be GMT. It is the developers responsibility to change dates to the local users
    /// timezone.
    /// </remarks>
    /// <param name="photoId">The id of the photo to set the date taken for.</param>
    /// <param name="dateTaken">The date taken.</param>
    /// <param name="granularity">The granularity of the date taken.</param>
    public async Task PhotosSetDatesAsync(string photoId, DateTime dateTaken, DateGranularity granularity, CancellationToken cancellationToken = default)
    {
        await PhotosSetDatesAsync(photoId, DateTime.MinValue, dateTaken, granularity, cancellationToken);
    }

    /// <summary>
    /// Set the date the photo was posted (uploaded). This will affect the order in which photos
    /// are seen in your photostream.
    /// </summary>
    /// <remarks>
    /// All dates are assumed to be GMT. It is the developers responsibility to change dates to the local users
    /// timezone.
    /// </remarks>
    /// <param name="photoId">The id of the photo to set the date posted.</param>
    /// <param name="datePosted">The new date to set the date posted too.</param>
    public async Task PhotosSetDatesAsync(string photoId, DateTime datePosted, CancellationToken cancellationToken = default)
    {
        await PhotosSetDatesAsync(photoId, datePosted, DateTime.MinValue, DateGranularity.FullDate, cancellationToken);
    }

    /// <summary>
    /// Set the date the photo was posted (uploaded) and the date the photo was taken.
    /// Changing the date posted will affect the order in which photos are seen in your photostream.
    /// </summary>
    /// <remarks>
    /// All dates are assumed to be GMT. It is the developers responsibility to change dates to the local users
    /// timezone.
    /// </remarks>
    /// <param name="photoId">The id of the photo to set the dates.</param>
    /// <param name="datePosted">The new date to set the date posted too.</param>
    /// <param name="dateTaken">The new date to set the date taken too.</param>
    /// <param name="granularity">The granularity of the date taken.</param>
    /// <param name="callback">Callback method to call upon return of the response from Flickr.</param>
    public async Task PhotosSetDatesAsync(string photoId, DateTime datePosted, DateTime dateTaken, DateGranularity granularity, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.setDates" },
            { "photo_id", photoId }
        };
        if (datePosted != DateTime.MinValue)
        {
            parameters.Add("date_posted", UtilityMethods.DateToUnixTimestamp(datePosted).ToString());
        }

        if (dateTaken != DateTime.MinValue)
        {
            parameters.Add("date_taken", dateTaken.ToString("yyyy-MM-dd HH:mm:ss", System.Globalization.DateTimeFormatInfo.InvariantInfo));
            parameters.Add("date_taken_granularity", granularity.ToString("d"));
        }

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Sets the title and description of the photograph.
    /// </summary>
    /// <param name="photoId">The numerical photoId of the photograph.</param>
    /// <param name="title">The new title of the photograph.</param>
    /// <param name="description">The new description of the photograph.</param>
    /// <exception cref="FlickrApiException">Thrown when the photo id cannot be found.</exception>
    public async Task PhotosSetMetaAsync(string photoId, string title, string description, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.setMeta" },
            { "photo_id", photoId },
            { "title", title },
            { "description", description }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Set the permissions on a photo.
    /// </summary>
    /// <param name="photoId">The id of the photo to update.</param>
    /// <param name="isPublic">1 if the photo is public, 0 if it is not.</param>
    /// <param name="isFriend">1 if the photo is viewable by friends, 0 if it is not.</param>
    /// <param name="isFamily">1 if the photo is viewable by family, 0 if it is not.</param>
    /// <param name="permComment">Who can add comments. See <see cref="PermissionComment"/> for more details.</param>
    /// <param name="permAddMeta">Who can add metadata (notes and tags). See <see cref="PermissionAddMeta"/> for more details.</param>
    public async Task PhotosSetPermsAsync(string photoId, int isPublic, int isFriend, int isFamily, PermissionComment permComment, PermissionAddMeta permAddMeta, CancellationToken cancellationToken = default)
    {
        await PhotosSetPermsAsync(photoId, (isPublic == 1), (isFriend == 1), (isFamily == 1), permComment, permAddMeta, cancellationToken);
    }

    /// <summary>
    /// Set the permissions on a photo.
    /// </summary>
    /// <param name="photoId">The id of the photo to update.</param>
    /// <param name="isPublic">True if the photo is public, False if it is not.</param>
    /// <param name="isFriend">True if the photo is viewable by friends, False if it is not.</param>
    /// <param name="isFamily">True if the photo is viewable by family, False if it is not.</param>
    /// <param name="permComment">Who can add comments. See <see cref="PermissionComment"/> for more details.</param>
    /// <param name="permAddMeta">Who can add metadata (notes and tags). See <see cref="PermissionAddMeta"/> for more details.</param>
    public async Task PhotosSetPermsAsync(string photoId, bool isPublic, bool isFriend, bool isFamily, PermissionComment permComment, PermissionAddMeta permAddMeta, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.setPerms" },
            { "photo_id", photoId },
            { "is_public", (isPublic ? "1" : "0") },
            { "is_friend", (isFriend ? "1" : "0") },
            { "is_family", (isFamily ? "1" : "0") },
            { "perm_comment", permComment.ToString("d") },
            { "perm_addmeta", permAddMeta.ToString("d") }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Set the tags for a photo.
    /// </summary>
    /// <remarks>
    /// This will remove all old tags and add these new ones specified. See <see cref="PhotosAddTags(string, string)"/>
    /// to just add new tags without deleting old ones.
    /// </remarks>
    /// <param name="photoId">The id of the photo to update.</param>
    /// <param name="tags">An array of tags.</param>
    public async Task PhotosSetTagsAsync(string photoId, string[] tags, CancellationToken cancellationToken = default)
    {
        string s = string.Join(",", tags);
        await PhotosSetTagsAsync(photoId, s, cancellationToken);
    }

    /// <summary>
    /// Set the tags for a photo.
    /// </summary>
    /// <remarks>
    /// This will remove all old tags and add these new ones specified. See <see cref="PhotosAddTags(string, string)"/>
    /// to just add new tags without deleting old ones.
    /// </remarks>
    /// <param name="photoId">The id of the photo to update.</param>
    /// <param name="tags">An comma-seperated list of tags.</param>
    public async Task PhotosSetTagsAsync(string photoId, string tags, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.setTags" },
            { "photo_id", photoId },
            { "tags", tags }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Sets the content type for a photo.
    /// </summary>
    /// <param name="photoId">The ID of the photos to set.</param>
    /// <param name="contentType">The new content type.</param>
    public async Task PhotosSetContentTypeAsync(string photoId, ContentType contentType, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.setContentType" },
            { "photo_id", photoId },
            { "content_type", contentType.ToString("D") }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Set the safety level for a photo, but only set the hidden aspect.
    /// </summary>
    /// <param name="photoId">The ID of the photo to set the hidden property for.</param>
    /// <param name="hidden">The new value of the hidden value.</param>
    public async Task PhotosSetSafetyLevelAsync(string photoId, HiddenFromSearch hidden, CancellationToken cancellationToken = default)
    {
        await PhotosSetSafetyLevelAsync(photoId, SafetyLevel.None, hidden, cancellationToken);
    }

    /// <summary>
    /// Set the safety level for a photo.
    /// </summary>
    /// <param name="photoId">The ID of the photo to set the safety level property for.</param>
    /// <param name="safetyLevel">The new value of the safety level value.</param>
    public async Task PhotosSetSafetyLevelAsync(string photoId, SafetyLevel safetyLevel, CancellationToken cancellationToken = default)
    {
        await PhotosSetSafetyLevelAsync(photoId, safetyLevel, HiddenFromSearch.None, cancellationToken);
    }

    /// <summary>
    /// Sets the safety level and hidden property of a photo.
    /// </summary>
    /// <param name="photoId">The ID of the photos to set.</param>
    /// <param name="safetyLevel">The new content type.</param>
    /// <param name="hidden">The new hidden value.</param>
    public async Task PhotosSetSafetyLevelAsync(string photoId, SafetyLevel safetyLevel, HiddenFromSearch hidden, CancellationToken cancellationToken = default)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.setSafetyLevel" },
            { "photo_id", photoId }
        };
        if (safetyLevel != SafetyLevel.None)
        {
            parameters.Add("safety_level", safetyLevel.ToString("D"));
        }

        switch (hidden)
        {
            case HiddenFromSearch.Visible:
                parameters.Add("hidden", "0");
                break;

            case HiddenFromSearch.Hidden:
                parameters.Add("hidden", "1");
                break;
        }

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Gets the first page of favourites for the given photo id.
    /// </summary>
    /// <param name="photoId">The ID of the photo to return the favourites for.</param>
    public async Task<PhotoFavoriteCollection> PhotosGetFavoritesAsync(string photoId, CancellationToken cancellationToken = default)
    {
        return await PhotosGetFavoritesAsync(photoId, 0, 0, cancellationToken);
    }

    /// <summary>
    /// Get the list of favourites for a photo.
    /// </summary>
    /// <param name="photoId">The photo ID of the photo.</param>
    /// <param name="perPage">How many favourites to return per page. Default is 10.</param>
    /// <param name="page">The page to return. Default is 1.</param>
    public async Task<PhotoFavoriteCollection> PhotosGetFavoritesAsync(string photoId, int perPage, int page, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.getFavorites" },
            { "photo_id", photoId }
        };
        if (page > 0)
        {
            parameters.Add("page", page.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        if (perPage > 0)
        {
            parameters.Add("per_page", perPage.ToString(System.Globalization.NumberFormatInfo.InvariantInfo));
        }

        return await GetResponseAsync<PhotoFavoriteCollection>(parameters, cancellationToken);
    }
}