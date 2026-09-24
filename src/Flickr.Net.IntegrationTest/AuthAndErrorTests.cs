using Flickr.Net.Exceptions;
using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class AuthAndErrorTests(WireMockFixture fixture) : IClassFixture<WireMockFixture>
{
    [Fact]
    public async Task ApiErrorResponse_ThrowsFlickrApiException()
    {
        fixture.Reset();
        fixture.StubFlickrError("flickr.cameras.getBrands", 114, "Bad request");

        using var client = fixture.CreateClient();

        var ex = await Assert.ThrowsAsync<FlickrApiException>(
            () => client.Cameras.GetBrandsAsync());

        Assert.Equal(114, ex.Code);
        Assert.Contains("Bad request", ex.OriginalMessage);
    }

    [Fact]
    public async Task MissingApiKey_ThrowsApiKeyRequiredException()
    {
        fixture.Reset();

        using var client = fixture.CreateClient(apiKey: "");

        await Assert.ThrowsAsync<ApiKeyRequiredException>(
            () => client.Cameras.GetBrandsAsync());
    }

    [Fact]
    public async Task AuthRequired_ThrowsAuthenticationRequiredException()
    {
        fixture.Reset();

        using var client = fixture.CreateClient("test-key", "test-secret");

        await Assert.ThrowsAsync<AuthenticationRequiredException>(
            () => client.Activity.UserCommentsAsync());
    }

    [Fact]
    public async Task HttpError_ThrowsHttpRequestException()
    {
        fixture.Reset();
        fixture.StubHttpError(500);

        using var client = fixture.CreateClient();

        await Assert.ThrowsAsync<HttpRequestException>(
            () => client.Cameras.GetBrandsAsync());
    }
}
