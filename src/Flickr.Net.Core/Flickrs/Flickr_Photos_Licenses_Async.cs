using Flickr.Net.Core.Entities;
using Flickr.Net.Core.Entities.Collections;
using Flickr.Net.Core.Enums;

namespace Flickr.Net.Core;

// TODO:
public partial class Flickr
{
    /// <summary>
    /// Gets a list of all current licenses.
    /// </summary>
    public async Task<LicenseCollection> PhotosLicensesGetInfoAsync(CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.licenses.getInfo" },
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
}
