using Flickr.Net.Core.Entities.Collections;

namespace Flickr.Net.Core;

// TODO:
public partial class Flickr
{
    /// <summary>
    /// Gets a collection of Flickr Commons institutions.
    /// </summary>
    public async Task<InstitutionCollection> CommonsGetInstitutionsAsync(CancellationToken cancellationToken = default)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.commons.getInstitutions" }
        };

        return await GetResponseAsync<InstitutionCollection>(parameters, cancellationToken);
    }
}