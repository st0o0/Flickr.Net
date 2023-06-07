namespace Flickr.Net.Core;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrPhotosLicenses
{
    async Task<LicenseCollection> IFlickrPhotosLicenses.GetInfoAsync(CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.licenses.getInfo" },
        };

        return await GetResponseAsync<LicenseCollection>(parameters, cancellationToken);
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

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
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
    Task<LicenseCollection> GetInfoAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Sets the license for a photo.
    /// </summary>
    /// <param name="photoId">The photo to update the license for.</param>
    /// <param name="license">
    /// The license to apply, or <see cref="LicenseType.AllRightsReserved"/> (0) to remove the
    /// current license. Note : as of this writing the 
    /// <see cref="LicenseType.NoKnownCopyrightRestrictions"/> license (7) is not a valid argument.
    /// </param>
    /// <param name="cancellationToken"></param>
    Task SetLicenseAsync(string photoId, LicenseType license, CancellationToken cancellationToken = default);
}