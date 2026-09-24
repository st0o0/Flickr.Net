using Flickr.Net.Enums;
using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class PhotosGeoTests(WireMockFixture fixture) : IClassFixture<WireMockFixture>
{
    [Fact]
    public async Task GetLocationAsync_ReturnsPhotoLocation()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photos.geo.getLocation", """
            {"stat":"ok","photo":{"id":"p1","location":{"latitude":"48.858","longitude":"2.294","accuracy":"16"}}}
            """);

        using var client = fixture.CreateClient();
        var result = await client.Photos.Geo.GetLocationAsync("p1");

        Assert.NotNull(result);
    }

    [Fact]
    public async Task SetLocationAsync_Succeeds()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photos.geo.setLocation", """{"stat":"ok"}""");

        using var client = fixture.CreateClient();
        await client.Photos.Geo.SetLocationAsync("p1", 48.858, 2.294);
    }

    [Fact]
    public async Task RemoveLocationAsync_Succeeds()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photos.geo.removeLocation", """{"stat":"ok"}""");

        using var client = fixture.CreateClient();
        await client.Photos.Geo.RemoveLocationAsync("p1");
    }
}
