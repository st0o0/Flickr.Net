using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class PhotosPeopleTests(WireMockFixture fixture) : IClassFixture<WireMockFixture>
{
    [Fact]
    public async Task AddAsync_Succeeds()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photos.people.add",
            """{"stat":"ok"}""");

        using var client = fixture.CreateAuthenticatedClient();
        await client.PhotosPeople.AddAsync("photo1", "user1", cancellationToken: TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task DeleteAsync_Succeeds()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photos.people.delete",
            """{"stat":"ok"}""");

        using var client = fixture.CreateAuthenticatedClient();
        await client.PhotosPeople.DeleteAsync("photo1", "user1", cancellationToken: TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task GetListAsync_ReturnsPeople()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photos.people.getList",
            """{"stat":"ok","people":{"total":"1","photo_width":"100","photo_height":"100","person":[{"nsid":"user1","username":"test"}]}}""");

        using var client = fixture.CreateClient();
        var result = await client.PhotosPeople.GetListAsync("photo1", cancellationToken: TestContext.Current.CancellationToken);

        Assert.NotNull(result);
        Assert.Single(result.Values);
    }
}
