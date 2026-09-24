using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class PushTests(WireMockFixture fixture) : IClassFixture<WireMockFixture>
{
    [Fact]
    public async Task GetSubscriptionsAsync_ReturnsSubscriptions()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.push.getSubscriptions",
            """{"stat":"ok","subscriptions":{"subscription":[{"topic":"my_photos","callback":"http://example.com","pending":"0"}]}}""");

        using var client = fixture.CreateAuthenticatedClient();
        var result = await client.Push.GetSubscriptionsAsync();

        Assert.NotNull(result);
        Assert.Single(result.Values);
        Assert.Equal("my_photos", result.Values[0].Topic);
    }

    [Fact]
    public async Task GetTopicsAsync_ReturnsTopics()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.push.getTopics",
            """{"stat":"ok","topics":{"topic":[{"name":"my_photos"}]}}""");

        using var client = fixture.CreateClient();
        var result = await client.Push.GetTopicsAsync();

        Assert.NotNull(result);
        Assert.Single(result.Values);
        Assert.Equal("my_photos", result.Values[0].Name);
    }

    [Fact]
    public async Task UnsubscribeAsync_Succeeds()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.push.unsubscribe",
            """{"stat":"ok"}""");

        using var client = fixture.CreateAuthenticatedClient();
        await client.Push.UnsubscribeAsync("my_photos", "http://example.com", "sync");
    }
}
