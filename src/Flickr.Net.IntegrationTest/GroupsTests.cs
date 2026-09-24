using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class GroupsTests : IClassFixture<WireMockFixture>
{
    private readonly WireMockFixture _fixture;

    public GroupsTests(WireMockFixture fixture)
    {
        _fixture = fixture;
        _fixture.Reset();
    }

    [Fact]
    public async Task GetInfoAsync_ReturnsGroupInfo()
    {
        _fixture.StubFlickrMethod("flickr.groups.getInfo",
            """{"stat":"ok","group":{"id":"group1","name":"Test Group","members":"100"}}""");

        using var client = _fixture.CreateClient();
        var result = await client.Groups.GetInfoAsync("group1");

        Assert.NotNull(result);
    }

    [Fact]
    public async Task SearchAsync_ReturnsGroups()
    {
        _fixture.StubFlickrMethod("flickr.groups.search",
            """{"stat":"ok","groups":{"page":1,"pages":1,"perpage":10,"total":1,"group":[{"nsid":"group1","name":"Test Group"}]}}""");

        using var client = _fixture.CreateClient();
        var result = await client.Groups.SearchAsync("test");

        Assert.NotNull(result);
        Assert.Single(result.Values);
    }

    [Fact]
    public async Task JoinAsync_Succeeds()
    {
        _fixture.StubFlickrMethod("flickr.groups.join", """{"stat":"ok"}""");

        using var client = _fixture.CreateAuthenticatedClient();
        await client.Groups.JoinAsync("group1");
    }

    [Fact]
    public async Task LeaveAsync_Succeeds()
    {
        _fixture.StubFlickrMethod("flickr.groups.leave", """{"stat":"ok"}""");

        using var client = _fixture.CreateAuthenticatedClient();
        await client.Groups.LeaveAsync("group1");
    }
}
