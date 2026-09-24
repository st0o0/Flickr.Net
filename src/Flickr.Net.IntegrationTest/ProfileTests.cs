using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class ProfileTests(WireMockFixture fixture) : IClassFixture<WireMockFixture>
{
    private readonly WireMockFixture _fixture = fixture;

    [Fact]
    public async Task GetProfileAsync_Returns_Profile()
    {
        _fixture.Reset();
        _fixture.StubFlickrMethod("flickr.profile.getProfile", """
            {
              "stat": "ok",
              "profile": {
                "id": "12345@N00",
                "nsid": "12345@N00",
                "join_date": "1616702870",
                "occupation": "Developer",
                "first_name": "Test",
                "last_name": "User"
              }
            }
            """);

        using var client = _fixture.CreateClient();
        var result = await client.Profile.GetProfileAsync("12345@N00", cancellationToken: TestContext.Current.CancellationToken);

        Assert.NotNull(result);
        Assert.Equal("12345@N00", result.Id);
        Assert.Equal("Developer", result.Occupation);

        var logEntry = Assert.Single(_fixture.LogEntries);
        var body = logEntry.RequestMessage!.Body!;
        Assert.Contains("user_id=12345%40N00", body);
    }
}
