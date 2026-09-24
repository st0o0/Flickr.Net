using System.Net;
using Flickr.Net.Configuration;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace Flickr.Net.IntegrationTest.Fixtures;

public sealed class WireMockFixture : IAsyncLifetime
{
    private WireMockServer _server = null!;

    public string ServerUrl => _server.Url!;

    public ValueTask InitializeAsync()
    {
        _server = WireMockServer.Start();
        return ValueTask.CompletedTask;
    }

    public ValueTask DisposeAsync()
    {
        _server.Stop();
        _server.Dispose();
        return ValueTask.CompletedTask;
    }

    public FlickrClient CreateClient(string apiKey = "test-api-key", string? sharedSecret = null)
    {
        var config = new FlickrConfiguration
        {
            ApiKey = apiKey,
            SharedSecret = sharedSecret!
        };

        return new FlickrClient(config)
        {
            BaseUri = new Uri(ServerUrl + "/services/rest/"),
            UploadUrl = ServerUrl + "/services/upload/",
            ReplaceUrl = ServerUrl + "/services/replace/",
            AuthUrl = ServerUrl + "/services/auth/"
        };
    }

    public FlickrClient CreateAuthenticatedClient(
        string apiKey = "test-api-key",
        string sharedSecret = "test-secret",
        string oauthToken = "test-oauth-token",
        string oauthTokenSecret = "test-oauth-token-secret")
    {
        var client = CreateClient(apiKey, sharedSecret);
        client.FlickrSettings.OAuthAccessToken = oauthToken;
        client.FlickrSettings.OAuthAccessTokenSecret = oauthTokenSecret;
        return client;
    }

    public void StubFlickrMethod(string methodName, string responseJson)
    {
        _server
            .Given(Request.Create()
                .WithPath("/services/rest/")
                .UsingPost()
                .WithBody(body => body?.Contains($"method={Uri.EscapeDataString(methodName)}") == true
                               || body?.Contains($"method={methodName}") == true))
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "application/json")
                .WithBody(responseJson));
    }

    public void StubFlickrError(string methodName, int code, string message)
    {
        var errorJson = $$"""{"stat":"fail","code":{{code}},"message":"{{message}}"}""";
        StubFlickrMethod(methodName, errorJson);
    }

    public void StubUpload(string responseXml)
    {
        _server
            .Given(Request.Create()
                .WithPath("/services/upload/")
                .UsingPost())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "text/xml")
                .WithBody(responseXml));
    }

    public void StubReplace(string responseXml)
    {
        _server
            .Given(Request.Create()
                .WithPath("/services/replace/")
                .UsingPost())
            .RespondWith(Response.Create()
                .WithStatusCode(HttpStatusCode.OK)
                .WithHeader("Content-Type", "text/xml")
                .WithBody(responseXml));
    }

    public void StubHttpError(int statusCode)
    {
        _server
            .Given(Request.Create()
                .WithPath("/services/rest/")
                .UsingPost())
            .RespondWith(Response.Create()
                .WithStatusCode(statusCode)
                .WithBody("Server Error"));
    }

    public void Reset() => _server.Reset();

    public IReadOnlyList<WireMock.Logging.ILogEntry> LogEntries => _server.LogEntries.ToList();
}
