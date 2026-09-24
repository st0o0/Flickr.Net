using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class TagsTests(WireMockFixture fixture) : IClassFixture<WireMockFixture>
{
    [Fact]
    public async Task GetClustersAsync_ReturnsClusters()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.tags.getClusters", """
            {"stat":"ok","clusters":{"source":"cat","total":"2","cluster":[{"total":"5","tag":[{"_content":"kitten"},{"_content":"pet"}]}]}}
            """);

        using var client = fixture.CreateClient();
        var result = await client.Tags.GetClustersAsync("cat");

        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetHotListAsync_ReturnsHottags()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.tags.getHotList", """
            {"stat":"ok","hottags":{"period":"day","count":"2","tag":[{"score":"100","_content":"sunset"},{"score":"90","_content":"nature"}]}}
            """);

        using var client = fixture.CreateClient();
        var result = await client.Tags.GetHotListAsync();

        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetRelatedAsync_ReturnsTags()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.tags.getRelated", """
            {"stat":"ok","tags":{"source":"cat","tag":[{"_content":"kitten"},{"_content":"pet"}]}}
            """);

        using var client = fixture.CreateClient();
        var result = await client.Tags.GetRelatedAsync("cat");

        Assert.NotNull(result);
        Assert.Equal(2, result.Values.Count);
    }

    [Fact]
    public async Task GetListUserRawAsync_ReturnsRawTags()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.tags.getListUserRaw", """
            {"stat":"ok","tags":{"tag":[{"clean":"landscape","raw":[{"_content":"Landscape"}]}]}}
            """);

        using var client = fixture.CreateAuthenticatedClient();
        var result = await client.Tags.GetListUserRawAsync();

        Assert.NotNull(result);
    }
}
