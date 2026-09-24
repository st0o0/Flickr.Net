using Flickr.Net.Enums;
using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class InterestingnessTests : IClassFixture<WireMockFixture>
{
    private readonly WireMockFixture _fixture;

    public InterestingnessTests(WireMockFixture fixture)
    {
        _fixture = fixture;
        _fixture.Reset();
    }

    [Fact]
    public async Task GetListAsync_ReturnsPagedPhotos()
    {
        _fixture.StubFlickrMethod("flickr.interestingness.getList",
            """{"stat":"ok","photos":{"page":1,"pages":1,"perpage":10,"total":1,"photo":[{"id":"photo1","secret":"abc","server":"1","farm":1,"title":"Interesting"}]}}""");

        using var client = _fixture.CreateClient();
        var result = await client.Interestingness.GetListAsync(null, PhotoSearchExtras.None, 0, 0, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Single(result.Values);
        Assert.Equal(1, result.Page);
    }
}
