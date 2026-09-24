using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class StatsTests(WireMockFixture fixture) : IClassFixture<WireMockFixture>
{
    [Fact]
    public async Task GetPhotoStatsAsync_ReturnsStats()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.stats.getPhotoStats", """
            {"stat":"ok","stats":{"views":"100","comments":"5","favorites":"10"}}
            """);

        using var client = fixture.CreateAuthenticatedClient();
        var result = await client.Stats.GetPhotoStatsAsync(DateTime.UtcNow, "p1");

        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetTotalViewsAsync_ReturnsViews()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.stats.getTotalViews", """
            {"stat":"ok","stats":{"views":{"total":{"_content":"1000"},"photos":{"_content":"500"},"photostream":{"_content":"300"},"sets":{"_content":"100"},"collections":{"_content":"100"}}}}
            """);

        using var client = fixture.CreateAuthenticatedClient();
        var result = await client.Stats.GetTotalViewsAsync(DateTime.UtcNow);

        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetCsvFilesAsync_ReturnsCSVFiles()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.stats.getCSVFiles", """
            {"stat":"ok","stats":{"csvfile":[{"href":"http://example.com/stats.csv","type":"daily","date":"2024-01-01"}]}}
            """);

        using var client = fixture.CreateAuthenticatedClient();
        var result = await client.Stats.GetCsvFilesAsync();

        Assert.NotNull(result);
    }
}
