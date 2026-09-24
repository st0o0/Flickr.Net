using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class FavoritesTests : IClassFixture<WireMockFixture>
{
    private readonly WireMockFixture _fixture;

    private const string PagedPhotosJson =
        """{"stat":"ok","photos":{"page":1,"pages":1,"perpage":10,"total":1,"photo":[{"id":"photo1","secret":"abc","server":"1","farm":1,"title":"Test"}]}}""";

    public FavoritesTests(WireMockFixture fixture)
    {
        _fixture = fixture;
        _fixture.Reset();
    }

    [Fact]
    public async Task AddAsync_Succeeds()
    {
        _fixture.StubFlickrMethod("flickr.favorites.add", """{"stat":"ok"}""");

        using var client = _fixture.CreateClient();
        await client.Favorites.AddAsync("photo1");
    }

    [Fact]
    public async Task GetContextAsync_ReturnsContext()
    {
        _fixture.StubFlickrMethod("flickr.favorites.getContext",
            """{"stat":"ok","count":{"_content":"5"},"nextphoto":{"id":"next1"},"prevphoto":{"id":"prev1"}}""");

        using var client = _fixture.CreateClient();
        var result = await client.Favorites.GetContextAsync("photo1", "user1");

        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetListAsync_ReturnsPagedPhotos()
    {
        _fixture.StubFlickrMethod("flickr.favorites.getList", PagedPhotosJson);

        using var client = _fixture.CreateAuthenticatedClient();
        var result = await client.Favorites.GetListAsync("user1");

        Assert.NotNull(result);
        Assert.Single(result.Values);
        Assert.Equal(1, result.Page);
    }

    [Fact]
    public async Task GetPublicListAsync_ReturnsPagedPhotos()
    {
        _fixture.StubFlickrMethod("flickr.favorites.getPublicList", PagedPhotosJson);

        using var client = _fixture.CreateClient();
        var result = await client.Favorites.GetPublicListAsync("user1");

        Assert.NotNull(result);
        Assert.Single(result.Values);
    }

    [Fact]
    public async Task RemoveAsync_Succeeds()
    {
        _fixture.StubFlickrMethod("flickr.favorites.remove", """{"stat":"ok"}""");

        using var client = _fixture.CreateClient();
        await client.Favorites.RemoveAsync("photo1");
    }
}
