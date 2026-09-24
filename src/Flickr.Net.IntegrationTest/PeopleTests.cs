using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class PeopleTests(WireMockFixture fixture) : IClassFixture<WireMockFixture>
{
    [Fact]
    public async Task FindByEmailAsync_ReturnsUser()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.people.findByEmail", """
            {"stat":"ok","user":{"id":"user1","nsid":"user1","username":"testuser"}}
            """);

        using var client = fixture.CreateClient();
        var result = await client.People.FindByEmailAsync("test@example.com", cancellationToken: TestContext.Current.CancellationToken);

        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetInfoAsync_ReturnsPerson()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.people.getInfo", """
            {"stat":"ok","person":{"id":"user1","nsid":"user1","ispro":"1","username":{"_content":"testuser"},"realname":{"_content":"Test User"}}}
            """);

        using var client = fixture.CreateClient();
        var result = await client.People.GetInfoAsync("user1", cancellationToken: TestContext.Current.CancellationToken);

        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetPublicPhotosAsync_ReturnsPagedPhotos()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.people.getPublicPhotos", """
            {"stat":"ok","photos":{"page":1,"pages":1,"perpage":10,"total":1,"photo":[{"id":"p1","secret":"abc","server":"1","farm":1,"title":"Test"}]}}
            """);

        using var client = fixture.CreateClient();
        var result = await client.People.GetPublicPhotosAsync("user1", cancellationToken: TestContext.Current.CancellationToken);

        Assert.NotNull(result);
        Assert.Single(result.Values);
    }

    [Fact]
    public async Task GetPhotosOfAsync_ReturnsPagedPhotos()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.people.getPhotosOf", """
            {"stat":"ok","photos":{"page":1,"pages":1,"perpage":10,"total":1,"photo":[{"id":"p1","secret":"abc","server":"1","farm":1,"title":"Test"}]}}
            """);

        using var client = fixture.CreateClient();
        var result = await client.People.GetPhotosOfAsync("user1", cancellationToken: TestContext.Current.CancellationToken);

        Assert.NotNull(result);
        Assert.Single(result.Values);
    }
}
