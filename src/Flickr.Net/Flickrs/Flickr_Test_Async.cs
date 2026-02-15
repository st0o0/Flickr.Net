using Flickr.Net.Internals;

namespace Flickr.Net;

/// <summary>
/// The flickr.
/// </summary>
public partial class Flickr : IFlickrTest
{
    async Task<User> IFlickrTest.LoginAsync(CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.test.login" }
        };

        return await GetResponseAsync<User>(parameters, cancellationToken);
    }

    async Task IFlickrTest.NullAsync(CancellationToken cancellationToken)
    {
        Dictionary<string, string> parameters = new()
        {
            { "method", "flickr.test.null" }
        };

        await GetResponseAsync(parameters, cancellationToken);
    }

    async Task<EchoResponseDictionary> IFlickrTest.EchoAsync(Dictionary<string, string> parameters, CancellationToken cancellationToken)
    {
        parameters.Add("method", "flickr.test.echo");

        return await GetResponseAsync<EchoResponseDictionary>(parameters, cancellationToken);
    }
}

/// <summary>
/// The flickr test.
/// </summary>
public interface IFlickrTest
{
    /// <summary>
    /// Test the logged in state of the current Filckr object.
    /// </summary>
    /// <param name="cancellationToken"></param>
    Task<User> LoginAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Null test.
    /// </summary>
    /// <param name="cancellationToken"></param>
    Task NullAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Echos back all parameters passed in.
    /// </summary>
    /// <param name="parameters">
    /// A dictionary of extra parameters to pass in. Note, the "method" and "api_key" parameters
    /// will always be passed in.
    /// </param>
    /// <param name="cancellationToken"></param>
    Task<EchoResponseDictionary> EchoAsync(Dictionary<string, string> parameters, CancellationToken cancellationToken = default);
}