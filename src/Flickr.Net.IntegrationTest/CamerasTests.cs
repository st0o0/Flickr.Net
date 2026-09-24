using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class CamerasTests(WireMockFixture fixture) : IClassFixture<WireMockFixture>
{
    private readonly WireMockFixture _fixture = fixture;

    [Fact]
    public async Task GetBrandsAsync_Returns_Brands()
    {
        _fixture.Reset();
        _fixture.StubFlickrMethod("flickr.cameras.getBrands", """
            {
              "stat": "ok",
              "brands": {
                "brand": [
                  { "id": "canon", "_content": "Canon" },
                  { "id": "nikon", "_content": "Nikon" }
                ]
              }
            }
            """);

        using var client = _fixture.CreateClient();
        var result = await client.Cameras.GetBrandsAsync(cancellationToken: TestContext.Current.CancellationToken);

        Assert.NotNull(result);
        Assert.Equal(2, result.Values.Count);
        Assert.Equal("canon", result.Values[0].Id);
        Assert.Equal("Nikon", result.Values[1].Content);
    }

    [Fact]
    public async Task GetBrandModelsAsync_Sends_Brand_Parameter()
    {
        _fixture.Reset();
        _fixture.StubFlickrMethod("flickr.cameras.getBrandModels", """
            {
              "stat": "ok",
              "cameras": {
                "brand": "canon",
                "camera": [
                  {
                    "id": "eos_5d",
                    "name": "EOS 5D",
                    "details": { "megapixels": "12.8" },
                    "images": { "small": "http://example.com/small.jpg", "large": "http://example.com/large.jpg" }
                  }
                ]
              }
            }
            """);

        using var client = _fixture.CreateClient();
        var result = await client.Cameras.GetBrandModelsAsync("canon", cancellationToken: TestContext.Current.CancellationToken);

        Assert.NotNull(result);
        Assert.Equal("canon", result.Brand);
        Assert.Single(result.Values);
        Assert.Equal("EOS 5D", result.Values[0].Name);

        var logEntry = Assert.Single(_fixture.LogEntries);
        var body = logEntry.RequestMessage!.Body!;
        Assert.Contains("brand=canon", body);
    }
}
