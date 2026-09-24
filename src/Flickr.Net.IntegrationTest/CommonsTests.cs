using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class CommonsTests(WireMockFixture fixture) : IClassFixture<WireMockFixture>
{
    private readonly WireMockFixture _fixture = fixture;

    [Fact]
    public async Task GetInstitutionsAsync_Returns_Institutions()
    {
        _fixture.Reset();
        _fixture.StubFlickrMethod("flickr.commons.getInstitutions", """
            {
              "stat": "ok",
              "institutions": {
                "institution": [
                  {
                    "nsid": "123456@N00",
                    "date_launch": "1204819200",
                    "name": "Library of Congress",
                    "urls": {
                      "url": [
                        { "type": "site", "_content": "http://www.loc.gov/" }
                      ]
                    }
                  }
                ]
              }
            }
            """);

        using var client = _fixture.CreateClient();
        var result = await client.Commons.GetInstitutionsAsync(cancellationToken: TestContext.Current.CancellationToken);

        Assert.NotNull(result);
        Assert.Single(result.Values);
        Assert.Equal("123456@N00", result.Values[0].Id);
        Assert.Equal("Library of Congress", result.Values[0].Name);
    }
}
