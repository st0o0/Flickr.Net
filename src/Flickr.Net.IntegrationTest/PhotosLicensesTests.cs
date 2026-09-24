using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class PhotosLicensesTests(WireMockFixture fixture) : IClassFixture<WireMockFixture>
{
    [Fact]
    public async Task GetInfoAsync_ReturnsLicenses()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photos.licenses.getInfo",
            """{"stat":"ok","licenses":{"license":[{"id":"0","name":"All Rights Reserved","url":""}]}}""");

        using var client = fixture.CreateClient();
        var result = await client.PhotosLicenses.GetInfoAsync();

        Assert.NotNull(result);
        Assert.Single(result.Values);
    }

    [Fact]
    public async Task SetLicenseAsync_Succeeds()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photos.licenses.setLicense",
            """{"stat":"ok"}""");

        using var client = fixture.CreateAuthenticatedClient();
        await client.PhotosLicenses.SetLicenseAsync("photo1", Enums.LicenseType.AllRightsReserved);
    }

    [Fact]
    public async Task GetAvailableAsync_ReturnsLicenses()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photos.licenses.getAvailable",
            """{"stat":"ok","licenses":{"license":[{"id":"0","name":"All Rights Reserved","url":""},{"id":"4","name":"Attribution License","url":"https://creativecommons.org/licenses/by/2.0/"}]}}""");

        using var client = fixture.CreateClient();
        var result = await client.PhotosLicenses.GetAvailableAsync("photo1");

        Assert.NotNull(result);
        Assert.Equal(2, result.Values.Count);
    }

    [Fact]
    public async Task GetLicenseHistoryAsync_ReturnsHistory()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photos.licenses.getLicenseHistory",
            """{"stat":"ok","licenses":{"licensehistoryentry":[{"old_license":0,"new_license":4,"date_change":"2024-01-15"}]}}""");

        using var client = fixture.CreateAuthenticatedClient();
        var result = await client.PhotosLicenses.GetLicenseHistoryAsync("photo1");

        Assert.NotNull(result);
        Assert.Single(result.Values);
    }
}
