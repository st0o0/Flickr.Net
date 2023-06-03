using Flickr.Net.Core.Entities;
using Flickr.Net.Core.Internals;

namespace Flickr.Net.Core;

// TODO:
public partial class Flickr : IFlickrTest
{
    /// <summary>
    /// Test the logged in state of the current Filckr object.
    /// </summary>
    async Task<FoundUser> IFlickrTest.LoginAsync(CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.test.login" }
        };

        return await GetResponseAsync<FoundUser>(parameters, cancellationToken);
    }

    /// <summary>
    /// Null test.
    /// </summary>
    async Task IFlickrTest.NullAsync(CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.test.null" }
        };

        await GetResponseAsync<NoResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Echos back all parameters passed in.
    /// </summary>
    /// <param name="parameters">A dictionary of extra parameters to pass in. Note, the "method" and "api_key" parameters will always be passed in.</param>
    async Task<EchoResponseDictionary> IFlickrTest.EchoAsync(Dictionary<string, string> parameters, CancellationToken cancellationToken)
    {
        parameters.Add("method", "flickr.test.echo");
        return await GetResponseAsync<EchoResponseDictionary>(parameters, cancellationToken);
    }
}

public interface IFlickrTest
{
    Task<FoundUser> LoginAsync(CancellationToken cancellationToken = default);

    Task NullAsync(CancellationToken cancellationToken = default);

    Task<EchoResponseDictionary> EchoAsync(Dictionary<string, string> parameters, CancellationToken cancellationToken = default);
}
