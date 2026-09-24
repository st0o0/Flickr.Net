using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class ReflectionTests(WireMockFixture fixture) : IClassFixture<WireMockFixture>
{
    private readonly WireMockFixture _fixture = fixture;

    [Fact]
    public async Task GetMethodsAsync_Returns_Methods()
    {
        _fixture.Reset();
        _fixture.StubFlickrMethod("flickr.reflection.getMethods", """
            {
              "stat": "ok",
              "methods": {
                "method": [
                  { "_content": "flickr.test.echo" },
                  { "_content": "flickr.test.login" }
                ]
              }
            }
            """);

        using var client = _fixture.CreateClient();
        var result = await client.Reflection.GetMethodsAsync();

        Assert.NotNull(result);
        Assert.Equal(2, result.Values.Count);
        Assert.Equal("flickr.test.echo", result.Values[0].Content);
    }

    [Fact]
    public async Task GetMethodInfoAsync_Sends_MethodName_Parameter()
    {
        _fixture.Reset();
        _fixture.StubFlickrMethod("flickr.reflection.getMethodInfo", """
            {
              "stat": "ok",
              "method": {
                "_content": "flickr.test.echo"
              }
            }
            """);

        using var client = _fixture.CreateClient();
        var result = await client.Reflection.GetMethodInfoAsync("flickr.test.echo");

        Assert.NotNull(result);
        Assert.Equal("flickr.test.echo", result.Content);

        var logEntry = Assert.Single(_fixture.LogEntries);
        var body = logEntry.RequestMessage.Body;
        Assert.Contains("method_name=flickr.test.echo", body);
    }
}
