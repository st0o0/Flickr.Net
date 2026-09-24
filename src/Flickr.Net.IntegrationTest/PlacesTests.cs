using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class PlacesTests(WireMockFixture fixture) : IClassFixture<WireMockFixture>
{
    [Fact]
    public async Task FindAsync_ReturnsPlaces()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.places.find", """
            {"stat":"ok","places":{"page":1,"pages":1,"perpage":10,"total":1,"query":"London","place":[{"place_id":"abc","woeid":"123","place_type_id":"7","_content":"London, England"}]}}
            """);

        using var client = fixture.CreateClient();
        var result = await client.Places.FindAsync("London");

        Assert.NotNull(result);
        Assert.Equal(1, result.Values.Count);
    }

    [Fact]
    public async Task FindByLatLonAsync_ReturnsPlaces()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.places.findByLatLon", """
            {"stat":"ok","places":{"page":1,"pages":1,"perpage":10,"total":1,"place":[{"place_id":"abc","woeid":"123","place_type_id":"7","_content":"London, England"}]}}
            """);

        using var client = fixture.CreateClient();
        var result = await client.Places.FindByLatLonAsync(51.5074, -0.1278);

        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetInfoAsync_ReturnsPlace()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.places.getInfo", """
            {"stat":"ok","place":{"place_id":"abc","woeid":"123","name":"London","place_type":"locality"}}
            """);

        using var client = fixture.CreateClient();
        var result = await client.Places.GetInfoAsync("abc");

        Assert.NotNull(result);
    }
}
