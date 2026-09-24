using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class PhotosMiscTests(WireMockFixture fixture) : IClassFixture<WireMockFixture>
{
    [Fact]
    public async Task RotateAsync_Succeeds()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photos.transform.rotate",
            """{"stat":"ok"}""");

        using var client = fixture.CreateClient();
        await client.PhotosMisc.RotateAsync("photo1", 90, cancellationToken: TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task CheckTicketsAsync_ReturnsTickets()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photos.upload.checkTickets",
            """{"stat":"ok","uploader":{"ticket":[{"id":"ticket1","complete":"1","photoid":"photo1"}]}}""");

        using var client = fixture.CreateClient();
        var result = await client.PhotosMisc.CheckTicketsAsync(["ticket1"], cancellationToken: TestContext.Current.CancellationToken);

        Assert.NotNull(result);
        Assert.Single(result.Values);
    }
}
