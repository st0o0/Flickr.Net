using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class GroupsDiscussTopicsTests : IClassFixture<WireMockFixture>
{
    private readonly WireMockFixture _fixture;

    public GroupsDiscussTopicsTests(WireMockFixture fixture)
    {
        _fixture = fixture;
        _fixture.Reset();
    }

    [Fact]
    public async Task TopicsAddAsync_Succeeds()
    {
        _fixture.StubFlickrMethod("flickr.groups.discuss.topics.add", """{"stat":"ok"}""");

        using var client = _fixture.CreateAuthenticatedClient();
        await client.GroupsDiscussTopics.TopicsAddAsync("group1", "Subject", "Message");
    }

    [Fact]
    public async Task TopicsGetListAsync_ReturnsTopics()
    {
        _fixture.StubFlickrMethod("flickr.groups.discuss.topics.getList",
            """{"stat":"ok","topics":{"page":1,"pages":1,"perpage":10,"total":1,"topic":[{"id":"t1","subject":"Test Topic"}]}}""");

        using var client = _fixture.CreateClient();
        var result = await client.GroupsDiscussTopics.TopicsGetListAsync("group1");

        Assert.NotNull(result);
        Assert.Single(result.Values);
    }

    [Fact]
    public async Task TopicsGetInfoAsync_ReturnsTopic()
    {
        _fixture.StubFlickrMethod("flickr.groups.discuss.topics.getInfo",
            """{"stat":"ok","topic":{"id":"t1","subject":"Test Topic"}}""");

        using var client = _fixture.CreateClient();
        var result = await client.GroupsDiscussTopics.TopicsGetInfoAsync("t1");

        Assert.NotNull(result);
    }
}
