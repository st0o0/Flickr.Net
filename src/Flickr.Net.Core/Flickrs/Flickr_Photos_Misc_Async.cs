using Flickr.Net.Core.Entities;
using Flickr.Net.Core.Entities.Collections;

namespace Flickr.Net.Core;

public partial class Flickr
{
    /// <summary>
    /// Rotates a photo on Flickr.
    /// </summary>
    /// <remarks>
    /// Does not rotate the original photo.
    /// </remarks>
    /// <param name="photoId">The ID of the photo.</param>
    /// <param name="degrees">The number of degrees to rotate by. Valid values are 90, 180 and 270.</param>
    public async Task PhotosTransformRotateAsync(string photoId, int degrees, CancellationToken cancellationToken = default)
    {
        if (photoId == null)
        {
            throw new ArgumentNullException(nameof(photoId));
        }

        if (degrees != 90 && degrees != 180 && degrees != 270)
        {
            throw new ArgumentException("Must be 90, 180 or 270", nameof(degrees));
        }

        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.transform.rotate" },
            { "photo_id", photoId },
            { "degrees", degrees.ToString(System.Globalization.NumberFormatInfo.InvariantInfo) }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Checks the status of one or more asynchronous photo upload tickets.
    /// </summary>
    /// <param name="tickets">A list of ticket ids</param>
    public async Task<TicketCollection> PhotosUploadCheckTicketsAsync(string[] tickets, CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.upload.checkTickets" },
            { "tickets", string.Join(",", tickets) }
        };

        return await GetResponseAsync<TicketCollection>(parameters, cancellationToken);
    }
}