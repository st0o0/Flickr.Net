using Flickr.Net.Enums;
using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class ActivityTests : IClassFixture<WireMockFixture>
{
    private readonly WireMockFixture _fixture;

    public ActivityTests(WireMockFixture fixture)
    {
        _fixture = fixture;
        _fixture.Reset();
    }

    [Fact]
    public async Task UserCommentsAsync_ReturnsItems()
    {
        _fixture.StubFlickrMethod("flickr.activity.userComments",
            """{"stat":"ok","items":{"item":[{"type":"photoset","id":"123"}]}}""");

        using var client = _fixture.CreateAuthenticatedClient();
        var result = await client.Activity.UserCommentsAsync(cancellationToken: TestContext.Current.CancellationToken);

        Assert.NotNull(result);
        Assert.Single(result.Values);
    }

    [Fact]
    public async Task UserPhotosAsync_ReturnsItems()
    {
        _fixture.StubFlickrMethod("flickr.activity.userPhotos",
            """{"stat":"ok","items":{"item":[{"type":"photo","id":"456"}]}}""");

        using var client = _fixture.CreateAuthenticatedClient();
        var result = await client.Activity.UserPhotosAsync(1, TimeType.Days, cancellationToken: TestContext.Current.CancellationToken);

        Assert.NotNull(result);
        Assert.Single(result.Values);
    }
}
