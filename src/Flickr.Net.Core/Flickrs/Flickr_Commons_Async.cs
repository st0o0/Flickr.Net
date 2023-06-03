﻿namespace Flickr.Net.Core;

public partial class Flickr : IFlickrCommons
{
    async Task<InstitutionCollection> IFlickrCommons.GetInstitutionsAsync(CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.commons.getInstitutions" }
        };

        return await GetResponseAsync<InstitutionCollection>(parameters, cancellationToken);
    }
}

public interface IFlickrCommons
{
    /// <summary>
    /// Gets a collection of Flickr Commons institutions.
    /// </summary>
    Task<InstitutionCollection> GetInstitutionsAsync(CancellationToken cancellationToken = default);
}