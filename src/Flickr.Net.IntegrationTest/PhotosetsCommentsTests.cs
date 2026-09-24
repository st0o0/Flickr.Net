using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class PhotosetsCommentsTests(WireMockFixture fixture) : IClassFixture<WireMockFixture>
{
    [Fact]
    public async Task AddCommentAsync_ReturnsCommentId()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photosets.comments.addComment",
            """{"stat":"ok","comment":{"id":"comment-456"}}""");

        using var client = fixture.CreateClient();
        var result = await client.PhotosetsComments.AddCommentAsync("set1", "nice set");

        Assert.Equal("comment-456", result);
    }

    [Fact]
    public async Task DeleteCommentAsync_Succeeds()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photosets.comments.deleteComment",
            """{"stat":"ok"}""");

        using var client = fixture.CreateClient();
        await client.PhotosetsComments.DeleteCommentAsync("comment-456");
    }

    [Fact]
    public async Task EditCommentAsync_Succeeds()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photosets.comments.editComment",
            """{"stat":"ok"}""");

        using var client = fixture.CreateClient();
        await client.PhotosetsComments.EditCommentAsync("comment-456", "updated text");
    }

    [Fact]
    public async Task GetListAsync_ReturnsComments()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photosets.comments.getList",
            """{"stat":"ok","comments":{"photoset_id":"set1","comment":[{"id":"c1","_content":"nice set"}]}}""");

        using var client = fixture.CreateClient();
        var result = await client.PhotosetsComments.GetListAsync("set1");

        Assert.NotNull(result);
        Assert.Single(result.Values);
    }
}
