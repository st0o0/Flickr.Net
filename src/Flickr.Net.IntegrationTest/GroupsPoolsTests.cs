using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class GroupsPoolsTests : IClassFixture<WireMockFixture>
{
    private readonly WireMockFixture _fixture;

    private const string PagedPhotosJson =
        """{"stat":"ok","photos":{"page":1,"pages":1,"perpage":10,"total":1,"photo":[{"id":"photo1","secret":"abc","server":"1","farm":1,"title":"Test"}]}}""";

    public GroupsPoolsTests(WireMockFixture fixture)
    {
        _fixture = fixture;
        _fixture.Reset();
    }

    [Fact]
    public async Task AddAsync_Succeeds()
    {
        _fixture.StubFlickrMethod("flickr.groups.pools.add", """{"stat":"ok"}""");

        using var client = _fixture.CreateAuthenticatedClient();
        await client.GroupsPools.AddAsync("photo1", "group1", cancellationToken: TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task GetContextAsync_ReturnsContext()
    {
        _fixture.StubFlickrMethod("flickr.groups.pools.getContext",
            """{"stat":"ok","count":{"_content":"5"},"nextphoto":{"id":"next1"},"prevphoto":{"id":"prev1"}}""");

        using var client = _fixture.CreateClient();
        var result = await client.GroupsPools.GetContextAsync("photo1", "group1", cancellationToken: TestContext.Current.CancellationToken);

        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetGroupsAsync_ReturnsGroups()
    {
        _fixture.StubFlickrMethod("flickr.groups.pools.getGroups",
            """{"stat":"ok","groups":{"page":1,"pages":1,"perpage":10,"total":1,"group":[{"nsid":"group1","name":"Test Group"}]}}""");

        using var client = _fixture.CreateClient();
        var result = await client.GroupsPools.GetGroupsAsync(cancellationToken: TestContext.Current.CancellationToken);

        Assert.NotNull(result);
        Assert.Single(result.Values);
    }

    [Fact]
    public async Task GetPhotosAsync_ReturnsPagedPhotos()
    {
        _fixture.StubFlickrMethod("flickr.groups.pools.getPhotos", PagedPhotosJson);

        using var client = _fixture.CreateClient();
        var result = await client.GroupsPools.GetPhotosAsync("group1", cancellationToken: TestContext.Current.CancellationToken);

        Assert.NotNull(result);
        Assert.Single(result.Values);
    }

    [Fact]
    public async Task RemoveAsync_Succeeds()
    {
        _fixture.StubFlickrMethod("flickr.groups.pools.remove", """{"stat":"ok"}""");

        using var client = _fixture.CreateClient();
        await client.GroupsPools.RemoveAsync("photo1", "group1", cancellationToken: TestContext.Current.CancellationToken);
    }
}
