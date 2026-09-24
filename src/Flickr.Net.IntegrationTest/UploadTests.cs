using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class UploadTests(WireMockFixture fixture) : IClassFixture<WireMockFixture>
{
    [Fact]
    public async Task UploadPictureAsync_Posts_To_UploadUrl()
    {
        fixture.Reset();
        fixture.StubUpload("""
            <?xml version="1.0" encoding="utf-8"?>
            <rsp stat="ok">
              <photoid>12345</photoid>
            </rsp>
            """);

        using var client = fixture.CreateAuthenticatedClient();
        using var stream = new MemoryStream(new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 });

        var photoId = await client.Upload.UploadPictureAsync(stream, "test.jpg", "Test Photo", cancellationToken: TestContext.Current.CancellationToken);

        Assert.Equal("12345", photoId);

        var logEntry = Assert.Single(fixture.LogEntries);
        Assert.Contains("/services/upload/", logEntry.RequestMessage!.Url!);
    }

    [Fact]
    public async Task ReplacePictureAsync_Posts_To_ReplaceUrl()
    {
        fixture.Reset();
        fixture.StubReplace("""
            <?xml version="1.0" encoding="utf-8"?>
            <rsp stat="ok">
              <photoid secret="newsecret" originalsecret="origsecret">12345</photoid>
            </rsp>
            """);

        using var client = fixture.CreateAuthenticatedClient();
        using var stream = new MemoryStream(new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 });

        var photoId = await client.Upload.ReplacePictureAsync(stream, "test.jpg", "12345", cancellationToken: TestContext.Current.CancellationToken);

        Assert.Equal("12345", photoId);

        var logEntry = Assert.Single(fixture.LogEntries);
        Assert.Contains("/services/replace/", logEntry.RequestMessage!.Url!);
    }
}
