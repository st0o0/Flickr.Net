using Flickr.Net.IntegrationTest.Fixtures;


namespace Flickr.Net.IntegrationTest;

public class PhotosTests(WireMockFixture fixture) : IClassFixture<WireMockFixture>
{
    [Fact]
    public async Task SearchAsync_ReturnsPagedPhotos()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photos.search", """
            {"stat":"ok","photos":{"page":1,"pages":1,"perpage":10,"total":1,"photo":[{"id":"p1","secret":"abc","server":"1","farm":1,"title":"Test"}]}}
            """);

        using var client = fixture.CreateClient();
        var options = new PhotoSearchOptions { Text = "test" };
        var result = await client.Photos.SearchAsync(options);

        Assert.NotNull(result);
        Assert.Equal(1, result.Values.Count);
    }

    [Fact]
    public async Task GetInfoAsync_ReturnsPhotoInfo()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photos.getInfo", """
            {"stat":"ok","photo":{"id":"p1","secret":"abc","server":"1","farm":1,"title":{"_content":"Test Photo"},"description":{"_content":"desc"},"owner":{"nsid":"user1","username":"testuser"}}}
            """);

        using var client = fixture.CreateClient();
        var result = await client.Photos.GetInfoAsync("p1");

        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetSizesAsync_ReturnsSizes()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photos.getSizes", """
            {"stat":"ok","sizes":{"canblog":1,"canprint":1,"candownload":1,"size":[{"label":"Square","width":"75","height":"75","source":"http://example.com/photo_sq.jpg","url":"http://example.com/photo_sq/"}]}}
            """);

        using var client = fixture.CreateClient();
        var result = await client.Photos.GetSizesAsync("p1");

        Assert.NotNull(result);
        Assert.Equal(1, result.Values.Count);
    }

    [Fact]
    public async Task DeleteAsync_Succeeds()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photos.delete", """{"stat":"ok"}""");

        using var client = fixture.CreateClient();
        await client.Photos.DeleteAsync("p1");
    }

    [Fact]
    public async Task AddTagAsync_Succeeds()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photos.addTags", """{"stat":"ok"}""");

        using var client = fixture.CreateClient();
        await client.Photos.AddTagAsync("p1", ["landscape", "sunset"]);
    }

    [Fact]
    public async Task SetMetaAsync_Succeeds()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photos.setMeta", """{"stat":"ok"}""");

        using var client = fixture.CreateClient();
        await client.Photos.SetMetaAsync("p1", "New Title", "New Description");
    }

    [Fact]
    public async Task GetExifAsync_ReturnsPhotoExif()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photos.getExif", """
            {"stat":"ok","photo":{"id":"p1","secret":"abc","exif":[{"tagspace":"EXIF","tag":"Make","raw":{"_content":"Canon"}}]}}
            """);

        using var client = fixture.CreateClient();
        var result = await client.Photos.GetExifAsync("p1");

        Assert.NotNull(result);
    }
}
