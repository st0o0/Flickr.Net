using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class ContactsTests : IClassFixture<WireMockFixture>
{
    private readonly WireMockFixture _fixture;

    private const string ContactsJson =
        """{"stat":"ok","contacts":{"page":1,"pages":1,"perpage":10,"total":1,"contact":[{"nsid":"user1","username":"testuser","iconserver":"1","iconfarm":1}]}}""";

    public ContactsTests(WireMockFixture fixture)
    {
        _fixture = fixture;
        _fixture.Reset();
    }

    [Fact]
    public async Task GetListAsync_ReturnsContacts()
    {
        _fixture.StubFlickrMethod("flickr.contacts.getList", ContactsJson);

        using var client = _fixture.CreateAuthenticatedClient();
        var result = await client.Contacts.GetListAsync(cancellationToken: TestContext.Current.CancellationToken);

        Assert.NotNull(result);
        Assert.Single(result.Values);
        Assert.Equal(1, result.Page);
    }

    [Fact]
    public async Task GetPublicListAsync_ReturnsContacts()
    {
        _fixture.StubFlickrMethod("flickr.contacts.getPublicList", ContactsJson);

        using var client = _fixture.CreateClient();
        var result = await client.Contacts.GetPublicListAsync("user1", cancellationToken: TestContext.Current.CancellationToken);

        Assert.NotNull(result);
        Assert.Single(result.Values);
    }

    [Fact]
    public async Task GetListRecentlyUploadedAsync_ReturnsContacts()
    {
        _fixture.StubFlickrMethod("flickr.contacts.getListRecentlyUploaded", ContactsJson);

        using var client = _fixture.CreateAuthenticatedClient();
        var result = await client.Contacts.GetListRecentlyUploadedAsync(cancellationToken: TestContext.Current.CancellationToken);

        Assert.NotNull(result);
        Assert.Single(result.Values);
    }

    [Fact]
    public async Task GetTaggingSuggestionsAsync_ReturnsContacts()
    {
        _fixture.StubFlickrMethod("flickr.contacts.getTaggingSuggestions", ContactsJson);

        using var client = _fixture.CreateAuthenticatedClient();
        var result = await client.Contacts.GetTaggingSuggestionsAsync(cancellationToken: TestContext.Current.CancellationToken);

        Assert.NotNull(result);
        Assert.Single(result.Values);
    }
}
