namespace Flickr.Net.Core;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrPhotosMisc
{
    async Task IFlickrPhotosMisc.RotateAsync(string photoId, int degrees, CancellationToken cancellationToken)
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

    async Task<TicketCollection> IFlickrPhotosMisc.CheckTicketsAsync(string[] tickets, CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.photos.upload.checkTickets" },
            { "tickets", string.Join(",", tickets) }
        };

        return await GetResponseAsync<TicketCollection>(parameters, cancellationToken);
    }
}

/// <summary>
/// The flickr photos misc.
/// </summary>
public interface IFlickrPhotosMisc
{
    /// <summary>
    /// Rotates a photo on Flickr.
    /// </summary>
    /// <remarks>Does not rotate the original photo.</remarks>
    /// <param name="photoId">The ID of the photo.</param>
    /// <param name="degrees">
    /// The number of degrees to rotate by. Valid values are 90, 180 and 270.
    /// </param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task RotateAsync(string photoId, int degrees, CancellationToken cancellationToken = default);

    /// <summary>
    /// Checks the status of one or more asynchronous photo upload tickets.
    /// </summary>
    /// <param name="tickets">A list of ticket ids</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<TicketCollection> CheckTicketsAsync(string[] tickets, CancellationToken cancellationToken = default);
}