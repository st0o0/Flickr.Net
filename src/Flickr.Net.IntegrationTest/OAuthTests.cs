using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class OAuthTests(WireMockFixture fixture) : IClassFixture<WireMockFixture>
{
    [Fact]
    public async Task CheckTokenAsync_Returns_OAuth()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.auth.oauth.checkToken", """
            {
              "stat": "ok",
              "oauth": {
                "token": "test-token",
                "perms": "write",
                "user": {
                  "nsid": "user1",
                  "username": "testuser",
                  "fullname": "Test User"
                }
              }
            }
            """);

        using var client = fixture.CreateAuthenticatedClient();
        var result = await client.OAuth.CheckTokenAsync();

        Assert.NotNull(result);
    }
}
