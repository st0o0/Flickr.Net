using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class BlogsTests : IClassFixture<WireMockFixture>
{
    private readonly WireMockFixture _fixture;

    public BlogsTests(WireMockFixture fixture)
    {
        _fixture = fixture;
        _fixture.Reset();
    }

    [Fact]
    public async Task GetListAsync_ReturnsBlogs()
    {
        _fixture.StubFlickrMethod("flickr.blogs.getList",
            """{"stat":"ok","blogs":{"blog":[{"id":"73","name":"Test Blog","needspassword":"0","url":"http://example.com/"}]}}""");

        using var client = _fixture.CreateAuthenticatedClient();
        var result = await client.Blogs.GetListAsync();

        Assert.NotNull(result);
        Assert.Single(result.Values);
        Assert.Equal("73", result.Values[0].Id);
    }

    [Fact]
    public async Task GetServicesAsync_ReturnsServices()
    {
        _fixture.StubFlickrMethod("flickr.blogs.getServices",
            """{"stat":"ok","services":{"service":[{"id":"beta.blogger.com","_content":"Blogger"}]}}""");

        using var client = _fixture.CreateClient();
        var result = await client.Blogs.GetServicesAsync();

        Assert.NotNull(result);
        Assert.Single(result.Values);
    }

    [Fact]
    public async Task PostPhotoAsync_Succeeds()
    {
        _fixture.StubFlickrMethod("flickr.blogs.postPhoto", """{"stat":"ok"}""");

        using var client = _fixture.CreateClient();
        await client.Blogs.PostPhotoAsync("blog1", "photo1", "Title", "Description");
    }
}
