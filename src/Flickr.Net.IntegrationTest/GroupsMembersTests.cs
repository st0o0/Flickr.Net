using Flickr.Net.Enums;
using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class GroupsMembersTests : IClassFixture<WireMockFixture>
{
    private readonly WireMockFixture _fixture;

    public GroupsMembersTests(WireMockFixture fixture)
    {
        _fixture = fixture;
        _fixture.Reset();
    }

    [Fact]
    public async Task GetListAsync_ReturnsMembers()
    {
        _fixture.StubFlickrMethod("flickr.groups.members.getList",
            """{"stat":"ok","members":{"page":1,"pages":1,"perpage":10,"total":1,"member":[{"nsid":"user1","username":"testuser","membertype":"2"}]}}""");

        using var client = _fixture.CreateAuthenticatedClient();
        var result = await client.GroupsMembers.GetListAsync("group1");

        Assert.NotNull(result);
        Assert.Single(result.Values);
    }
}
