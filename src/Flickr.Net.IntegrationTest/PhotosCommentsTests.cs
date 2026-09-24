using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class PhotosCommentsTests(WireMockFixture fixture) : IClassFixture<WireMockFixture>
{
    [Fact]
    public async Task AddCommentAsync_ReturnsCommentId()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photos.comments.addComment",
            """{"stat":"ok","comment":{"id":"comment-123"}}""");

        using var client = fixture.CreateClient();
        var result = await client.PhotosComments.AddCommentAsync("photo1", "great photo");

        Assert.Equal("comment-123", result);
    }

    [Fact]
    public async Task DeleteCommentAsync_Succeeds()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photos.comments.deleteComment",
            """{"stat":"ok"}""");

        using var client = fixture.CreateClient();
        await client.PhotosComments.DeleteCommentAsync("comment-123");
    }

    [Fact]
    public async Task EditCommentAsync_Succeeds()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photos.comments.editComment",
            """{"stat":"ok"}""");

        using var client = fixture.CreateClient();
        await client.PhotosComments.EditCommentAsync("comment-123", "updated text");
    }

    [Fact]
    public async Task GetListAsync_ReturnsComments()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photos.comments.getList",
            """{"stat":"ok","comments":{"photo_id":"photo1","comment":[{"id":"c1","author":"user1","_content":"great photo"}]}}""");

        using var client = fixture.CreateClient();
        var result = await client.PhotosComments.GetListAsync("photo1");

        Assert.NotNull(result);
        Assert.Single(result.Values);
    }

    [Fact]
    public async Task GetRecentForContactsAsync_ReturnsPhotos()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photos.comments.getRecentForContacts",
            """{"stat":"ok","photos":{"page":1,"pages":1,"perpage":10,"total":1,"photo":[{"id":"p1","owner":"user1","secret":"abc","server":"1","farm":1,"title":"test"}]}}""");

        using var client = fixture.CreateAuthenticatedClient();
        var result = await client.PhotosComments.GetRecentForContactsAsync();

        Assert.NotNull(result);
        Assert.Single(result.Values);
    }
}
