using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class GroupsDiscussRepliesTests : IClassFixture<WireMockFixture>
{
    private readonly WireMockFixture _fixture;

    public GroupsDiscussRepliesTests(WireMockFixture fixture)
    {
        _fixture = fixture;
        _fixture.Reset();
    }

    [Fact]
    public async Task AddAsync_Succeeds()
    {
        _fixture.StubFlickrMethod("flickr.groups.discuss.replies.add", """{"stat":"ok"}""");

        using var client = _fixture.CreateAuthenticatedClient();
        await client.GroupsDiscussReplies.AddAsync("topic1", "Hello");
    }

    [Fact]
    public async Task DeleteAsync_Succeeds()
    {
        _fixture.StubFlickrMethod("flickr.groups.discuss.replies.delete", """{"stat":"ok"}""");

        using var client = _fixture.CreateAuthenticatedClient();
        await client.GroupsDiscussReplies.DeleteAsync("topic1", "reply1");
    }

    [Fact]
    public async Task EditAsync_Succeeds()
    {
        _fixture.StubFlickrMethod("flickr.groups.discuss.replies.edit", """{"stat":"ok"}""");

        using var client = _fixture.CreateAuthenticatedClient();
        await client.GroupsDiscussReplies.EditAsync("topic1", "reply1", "Updated");
    }

    [Fact]
    public async Task GetInfoAsync_ReturnsReply()
    {
        _fixture.StubFlickrMethod("flickr.groups.discuss.replies.getInfo",
            """{"stat":"ok","reply":{"id":"reply1","message":["test reply"]}}""");

        using var client = _fixture.CreateClient();
        var result = await client.GroupsDiscussReplies.GetInfoAsync("topic1", "reply1");

        Assert.NotNull(result);
    }

    [Fact]
    public async Task GetListAsync_ReturnsReplies()
    {
        _fixture.StubFlickrMethod("flickr.groups.discuss.replies.getList",
            """{"stat":"ok","replies":{"reply":[{"id":"r1","message":["hello"]}]}}""");

        using var client = _fixture.CreateClient();
        var result = await client.GroupsDiscussReplies.GetListAsync("topic1", 10);

        Assert.NotNull(result);
        Assert.Single(result.Values);
    }
}
