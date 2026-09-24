using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class PhotosetsTests(WireMockFixture fixture) : IClassFixture<WireMockFixture>
{
    [Fact]
    public async Task GetInfoAsync_ReturnsPhotoset()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photosets.getInfo", """
            {"stat":"ok","photoset":{"id":"set1","primary":"p1","photos":"10","title":{"_content":"Test Set"},"description":{"_content":"desc"}}}
            """);

        using var client = fixture.CreateClient();
        var result = await client.Photosets.GetInfoAsync("set1");

        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetListAsync_ReturnsPhotosets()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photosets.getList", """
            {"stat":"ok","photosets":{"page":1,"pages":1,"perpage":10,"total":1,"cancreate":1,"photoset":[{"id":"set1","primary":"p1","photos":"5","title":{"_content":"Set 1"}}]}}
            """);

        using var client = fixture.CreateClient();
        var result = await client.Photosets.GetListAsync("user1");

        Assert.NotNull(result);
        Assert.Equal(1, result.Values.Count);
    }

    [Fact]
    public async Task AddPhotoAsync_Succeeds()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photosets.addPhoto", """{"stat":"ok"}""");

        using var client = fixture.CreateAuthenticatedClient();
        await client.Photosets.AddPhotoAsync("set1", "p1");
    }

    [Fact]
    public async Task RemovePhotoAsync_Succeeds()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photosets.removePhoto", """{"stat":"ok"}""");

        using var client = fixture.CreateClient();
        await client.Photosets.RemovePhotoAsync("set1", "p1");
    }

    [Fact]
    public async Task GetPhotosAsync_ReturnsPhotosetPhotos()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photosets.getPhotos", """
            {"stat":"ok","photoset":{"id":"set1","primary":"p1","owner":"user1","page":1,"pages":1,"perpage":10,"total":1,"photo":[{"id":"p1","secret":"abc","title":"Photo 1"}]}}
            """);

        using var client = fixture.CreateClient();
        var result = await client.Photosets.GetPhotosAsync("set1");

        Assert.NotNull(result);
        Assert.Equal(1, result.Values.Count);
    }
}
