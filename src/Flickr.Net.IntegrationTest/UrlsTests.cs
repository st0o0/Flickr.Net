using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class UrlsTests(WireMockFixture fixture) : IClassFixture<WireMockFixture>
{
    [Fact]
    public async Task GetGroupAsync_ReturnsUrl()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.urls.getGroup",
            """{"stat":"ok","group":{"nsid":"group1","url":"https://www.flickr.com/groups/test/"}}""");

        using var client = fixture.CreateClient();
        var result = await client.Urls.GetGroupAsync("group1");

        Assert.NotNull(result);
        Assert.Contains("flickr.com", result);
    }

    [Fact]
    public async Task GetUserPhotosAsync_ReturnsUrl()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.urls.getUserPhotos",
            """{"stat":"ok","unknownresponse":{"nsid":"user1","url":"https://www.flickr.com/photos/test/"}}""");

        using var client = fixture.CreateClient();
        var result = await client.Urls.GetUserPhotosAsync("user1");

        Assert.NotNull(result);
        Assert.Contains("flickr.com", result);
    }

    [Fact]
    public async Task GetUserProfileAsync_ReturnsUrl()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.urls.getUserProfile",
            """{"stat":"ok","unknownresponse":{"nsid":"user1","url":"https://www.flickr.com/people/test/"}}""");

        using var client = fixture.CreateClient();
        var result = await client.Urls.GetUserProfileAsync("user1");

        Assert.NotNull(result);
        Assert.Contains("flickr.com", result);
    }

    [Fact]
    public async Task LookupGroupAsync_ReturnsGroupId()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.urls.lookupGroup",
            """{"stat":"ok","group":{"id":"group1","groupname":"Test Group"}}""");

        using var client = fixture.CreateClient();
        var result = await client.Urls.LookupGroupAsync("https://www.flickr.com/groups/test/");

        Assert.NotNull(result);
        Assert.Equal("group1", result);
    }

    [Fact]
    public async Task LookupUserAsync_ReturnsUserId()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.urls.lookupUser",
            """{"stat":"ok","user":{"id":"user1","username":"testuser"}}""");

        using var client = fixture.CreateClient();
        var result = await client.Urls.LookupUserAsync("https://www.flickr.com/photos/test/");

        Assert.NotNull(result);
        Assert.Equal("user1", result);
    }
}
