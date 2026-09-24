using Flickr.Net.Enums;
using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class PrefsTests(WireMockFixture fixture) : IClassFixture<WireMockFixture>
{
    [Fact]
    public async Task GetContentTypeAsync_ReturnsContentType()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.prefs.getContentType",
            """{"stat":"ok","person":{"nsid":"user1","content_type":"1"}}""");

        using var client = fixture.CreateAuthenticatedClient();
        var result = await client.Prefs.GetContentTypeAsync(cancellationToken: TestContext.Current.CancellationToken);

        Assert.Equal(ContentType.Photo, result);
    }

    [Fact]
    public async Task GetGeoPermsAsync_ReturnsGeoPerms()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.prefs.getGeoPerms",
            """{"stat":"ok","geoperms":{"nsid":"user1","geoperms":"1","importgeoexif":"1"}}""");

        using var client = fixture.CreateAuthenticatedClient();
        var result = await client.Prefs.GetGeoPermsAsync(cancellationToken: TestContext.Current.CancellationToken);

        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetHiddenAsync_ReturnsHidden()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.prefs.getHidden",
            """{"stat":"ok","person":{"nsid":"user1","hidden":"2"}}""");

        using var client = fixture.CreateAuthenticatedClient();
        var result = await client.Prefs.GetHiddenAsync(cancellationToken: TestContext.Current.CancellationToken);

        Assert.Equal(HiddenFromSearch.Hidden, result);
    }

    [Fact]
    public async Task GetPrivacyAsync_ReturnsPrivacy()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.prefs.getPrivacy",
            """{"stat":"ok","person":{"nsid":"user1","privacy":"1"}}""");

        using var client = fixture.CreateAuthenticatedClient();
        var result = await client.Prefs.GetPrivacyAsync(cancellationToken: TestContext.Current.CancellationToken);

        Assert.Equal(PrivacyFilter.PublicPhotos, result);
    }

    [Fact]
    public async Task GetSafetyLevelAsync_ReturnsSafetyLevel()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.prefs.getSafetyLevel",
            """{"stat":"ok","unknownresponse":{"nsid":"user1","safety_level":"1"}}""");

        using var client = fixture.CreateAuthenticatedClient();
        var result = await client.Prefs.GetSafetyLevelAsync(cancellationToken: TestContext.Current.CancellationToken);

        Assert.Equal(SafetyLevel.Safe, result);
    }
}
