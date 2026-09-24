using Flickr.Net.Enums;
using Flickr.Net.Internals.Extensions;

namespace Flickr.Net;

/// <summary>
/// The flickr.
/// </summary>
public sealed partial class FlickrClient : IFlickrPhotosLicenses
{
    async Task<Licenses> IFlickrPhotosLicenses.GetInfoAsync(CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.licenses.getInfo" },
        };

        return await GetResponseAsync<Licenses>(parameters, cancellationToken).ConfigureAwait(false);
    }

    async Task IFlickrPhotosLicenses.SetLicenseAsync(string photoId, LicenseType license, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.licenses.setLicense" },
            { "photo_id", photoId },
            { "license_id", license.ToString("d") }
        };

        await GetResponseAsync(parameters, cancellationToken).ConfigureAwait(false);
    }

    async Task<Licenses> IFlickrPhotosLicenses.GetAvailableAsync(string? photoId, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.licenses.getAvailable" }
        };

        parameters.AppendIf("photo_id", photoId, x => !string.IsNullOrEmpty(x), x => x);

        return await GetResponseAsync<Licenses>(parameters, cancellationToken).ConfigureAwait(false);
    }

    async Task<LicenseHistoryEntries> IFlickrPhotosLicenses.GetLicenseHistoryAsync(string photoId, CancellationToken cancellationToken)
    {
        CheckRequiresAuthentication();

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.licenses.getLicenseHistory" },
            { "photo_id", photoId }
        };

        return await GetResponseAsync<LicenseHistoryEntries>(parameters, cancellationToken).ConfigureAwait(false);
    }
}

/// <summary>
/// The flickr photos licenses.
/// </summary>
public interface IFlickrPhotosLicenses
{
    /// <summary>
    /// Gets a list of all current licenses.
    /// </summary>
    /// <param name="cancellationToken"></param>
    Task<Licenses> GetInfoAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Sets the license for a photo.
    /// </summary>
    /// <param name="photoId">The photo to update the license for.</param>
    /// <param name="license">
    /// The license to apply, or <see cref="LicenseType.AllRightsReserved"/> (0) to remove the
    /// current license. Note : as of this writing the <see
    /// cref="LicenseType.NoKnownCopyrightRestrictions"/> license (7) is not a valid argument.
    /// </param>
    /// <param name="cancellationToken"></param>
    Task SetLicenseAsync(string photoId, LicenseType license, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the available licenses for a given photo, or all licenses if no photo is specified.
    /// </summary>
    /// <param name="photoId">The photo to get available licenses for. If omitted, all licenses are returned.</param>
    /// <param name="cancellationToken"></param>
    Task<Licenses> GetAvailableAsync(string? photoId = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the license change history for a photo.
    /// </summary>
    /// <param name="photoId">The photo to get the license history for.</param>
    /// <param name="cancellationToken"></param>
    Task<LicenseHistoryEntries> GetLicenseHistoryAsync(string photoId, CancellationToken cancellationToken = default);
}