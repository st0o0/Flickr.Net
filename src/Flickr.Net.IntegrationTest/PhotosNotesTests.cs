using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class PhotosNotesTests(WireMockFixture fixture) : IClassFixture<WireMockFixture>
{
    [Fact]
    public async Task AddAsync_ReturnsNoteId()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photos.notes.add",
            """{"stat":"ok","note":{"id":"note-123"}}""");

        using var client = fixture.CreateClient();
        var result = await client.PhotosNotes.AddAsync("photo1", 10, 20, 100, 50, "test note");

        Assert.Equal("note-123", result);
    }

    [Fact]
    public async Task DeleteAsync_Succeeds()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photos.notes.delete",
            """{"stat":"ok"}""");

        using var client = fixture.CreateClient();
        await client.PhotosNotes.DeleteAsync("note-123");
    }

    [Fact]
    public async Task EditAsync_Succeeds()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.photos.notes.edit",
            """{"stat":"ok"}""");

        using var client = fixture.CreateClient();
        await client.PhotosNotes.EditAsync("note-123", 10, 20, 100, 50, "updated note");
    }
}
