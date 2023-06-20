namespace Flickr.Net.Core;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrCommons
{
    async Task<Institutions> IFlickrCommons.GetInstitutionsAsync(CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.commons.getInstitutions" }
        };

        return await GetResponseAsync<Institutions>(parameters, cancellationToken);
    }
}

/// <summary>
/// The flickr commons.
/// </summary>
public interface IFlickrCommons
{
    /// <summary>
    /// Gets a collection of Flickr Commons institutions.
    /// </summary>
    /// <param name="cancellationToken"></param>
    Task<Institutions> GetInstitutionsAsync(CancellationToken cancellationToken = default);
}