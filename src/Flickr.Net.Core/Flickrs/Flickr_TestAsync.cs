namespace FlickrNet.Core;

public partial class Flickr
{
    /// <summary>
    /// Can be used to call unsupported methods in the Flickr API.
    /// </summary>
    /// <remarks>
    /// Use of this method is not supported.
    /// The way the FlickrNet API Library works may mean that some methods do not return an expected result
    /// when using this method.
    /// </remarks>
    /// <param name="method">The method name, e.g. "flickr.test.null".</param>
    /// <param name="parameters">A list of parameters. Note, api_key is added by default and is not included. Can be null.</param>
    public async Task<UnknownResponse> TestGenericAsync(string method, Dictionary<string, string> parameters, CancellationToken cancellationToken = default)
    {
        if (parameters == null)
        {
            parameters = new Dictionary<string, string>();
        }

        parameters.Add("method", method);
        return await GetResponseAsync<UnknownResponse>(parameters, cancellationToken);
    }

    /// <summary>
    /// Test the logged in state of the current Filckr object.
    /// </summary>
    public async Task<FoundUser> TestLoginAsync(CancellationToken cancellationToken = default)
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
    public async Task TestNullAsync(CancellationToken cancellationToken = default)
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
    public async Task<EchoResponseDictionary> TestEchoAsync(Dictionary<string, string> parameters, CancellationToken cancellationToken = default)
    {
        parameters.Add("method", "flickr.test.echo");
        return await GetResponseAsync<EchoResponseDictionary>(parameters, cancellationToken);
    }
}