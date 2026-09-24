using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class GalleriesTests(WireMockFixture fixture) : IClassFixture<WireMockFixture>
{
    [Fact]
    public async Task GetInfoAsync_ReturnsGalleryInfo()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.galleries.getInfo", """
            {"stat":"ok","gallery":{"id":"gallery1","url":"http://example.com","title":{"_content":"Test Gallery"},"description":{"_content":"desc"}}}
            """);

        using var client = fixture.CreateClient();
        var result = await client.Galleries.GetInfoAsync("gallery1");

        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetListAsync_ReturnsGalleries()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.galleries.getList", """
            {"stat":"ok","galleries":{"page":1,"pages":1,"perpage":10,"total":1,"user_id":"user1","gallery":[{"id":"g1","title":{"_content":"Gallery 1"}}]}}
            """);

        using var client = fixture.CreateClient();
        var result = await client.Galleries.GetListAsync("user1");

        Assert.NotNull(result);
        Assert.Equal(1, result.Values.Count);
    }

    [Fact]
    public async Task AddPhotoAsync_Succeeds()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.galleries.addPhoto", """{"stat":"ok"}""");

        using var client = fixture.CreateClient();
        await client.Galleries.AddPhotoAsync("gallery1", "p1", "Nice photo!");
    }

    [Fact]
    public async Task GetPhotosAsync_ReturnsGalleryPhotos()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.galleries.getPhotos", """
            {"stat":"ok","photos":{"page":1,"pages":1,"perpage":10,"total":1,"photo":[{"id":"p1"}]}}
            """);

        using var client = fixture.CreateClient();
        var result = await client.Galleries.GetPhotosAsync("gallery1");

        Assert.NotNull(result);
        Assert.Equal(1, result.Values.Count);
    }
}
