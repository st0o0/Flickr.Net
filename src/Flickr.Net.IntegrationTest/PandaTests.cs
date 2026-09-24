using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class PandaTests(WireMockFixture fixture) : IClassFixture<WireMockFixture>
{
    private readonly WireMockFixture _fixture = fixture;

    [Fact]
    public async Task GetListAsync_Returns_Pandas()
    {
        _fixture.Reset();
        _fixture.StubFlickrMethod("flickr.panda.getList", """
            {
              "stat": "ok",
              "pandas": {
                "panda": [
                  { "_content": "ling ling" },
                  { "_content": "hsing hsing" },
                  { "_content": "wang wang" }
                ]
              }
            }
            """);

        using var client = _fixture.CreateClient();
        var result = await client.Panda.GetListAsync();

        Assert.NotNull(result);
        Assert.Equal(3, result.Values.Count);
        Assert.Equal("ling ling", result.Values[0].Content);
    }

    [Fact]
    public async Task GetPhotosAsync_Sends_PandaName_Parameter()
    {
        _fixture.Reset();
        _fixture.StubFlickrMethod("flickr.panda.getPhotos", """
            {
              "stat": "ok",
              "photos": {
                "panda": "ling ling",
                "total": "1",
                "interval": "600",
                "lastupdate": "1704067200",
                "photo": [
                  {
                    "id": "photo1",
                    "owner": "owner1",
                    "secret": "abc",
                    "server": "1",
                    "farm": 1,
                    "title": "Panda Photo"
                  }
                ]
              }
            }
            """);

        using var client = _fixture.CreateClient();
        var result = await client.Panda.GetPhotosAsync("ling ling");

        Assert.NotNull(result);
        Assert.Equal("ling ling", result.Panda);
        Assert.Single(result.Values);

        var logEntry = Assert.Single(_fixture.LogEntries);
        var body = logEntry.RequestMessage.Body;
        Assert.Contains("panda_name=ling", body);
    }
}
