using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class TestTests(WireMockFixture fixture) : IClassFixture<WireMockFixture>
{
    private readonly WireMockFixture _fixture = fixture;

    [Fact]
    public async Task LoginAsync_Returns_User()
    {
        _fixture.Reset();
        _fixture.StubFlickrMethod("flickr.test.login", """
            {
              "stat": "ok",
              "user": {
                "nsid": "12345@N00",
                "username": "testuser"
              }
            }
            """);

        using var client = _fixture.CreateClient();
        var result = await client.Test.LoginAsync();

        Assert.NotNull(result);
        Assert.Equal("12345@N00", result.Id);
        Assert.Equal("testuser", result.UserName);
    }

    [Fact]
    public async Task NullAsync_Completes_Without_Exception()
    {
        _fixture.Reset();
        _fixture.StubFlickrMethod("flickr.test.null", """{"stat":"ok"}""");

        using var client = _fixture.CreateClient();
        await client.Test.NullAsync();

        Assert.Single(_fixture.LogEntries);
    }

    [Fact]
    public async Task EchoAsync_Sends_Parameters()
    {
        _fixture.Reset();
        _fixture.StubFlickrMethod("flickr.test.echo", """
            {
              "stat": "ok",
              "echoresponsedictionary": {
                "method": "flickr.test.echo",
                "foo": "bar"
              }
            }
            """);

        using var client = _fixture.CreateClient();
        var parameters = new Dictionary<string, string> { { "foo", "bar" } };
        var result = await client.Test.EchoAsync(parameters);

        Assert.NotNull(result);

        var logEntry = Assert.Single(_fixture.LogEntries);
        var body = logEntry.RequestMessage.Body;
        Assert.Contains("foo=bar", body);
    }
}
