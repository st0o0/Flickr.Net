using Flickr.Net.Enums;
using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class PhotosSuggestionsTests(WireMockFixture fixture) : IClassFixture<WireMockFixture>
{
    [Fact]
    public async Task ApproveSuggestionAsync_Succeeds()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photos.suggestions.approveSuggestion",
            """{"stat":"ok"}""");

        using var client = fixture.CreateAuthenticatedClient();
        await client.PhotosSuggestions.ApproveSuggestionAsync("suggestion1", cancellationToken: TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task GetListAsync_ReturnsResponse()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photos.suggestions.getList",
            """{"stat":"ok","unknownresponse":{"total":"0"}}""");

        using var client = fixture.CreateAuthenticatedClient();
        var result = await client.PhotosSuggestions.GetListAsync("photo1", SuggestionStatus.Pending, cancellationToken: TestContext.Current.CancellationToken);

        Assert.NotNull(result);
    }

    [Fact]
    public async Task RejectSuggestionAsync_Succeeds()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photos.suggestions.rejectSuggestion",
            """{"stat":"ok"}""");

        using var client = fixture.CreateAuthenticatedClient();
        await client.PhotosSuggestions.RejectSuggestionAsync("suggestion1", cancellationToken: TestContext.Current.CancellationToken);
    }

    [Fact]
    public async Task RemoveSuggestionAsync_Succeeds()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photos.suggestions.removeSuggestion",
            """{"stat":"ok"}""");

        using var client = fixture.CreateAuthenticatedClient();
        await client.PhotosSuggestions.RemoveSuggestionAsync("suggestion1", cancellationToken: TestContext.Current.CancellationToken);
    }
}
