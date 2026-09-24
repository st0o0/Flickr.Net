using Flickr.Net.IntegrationTest.Fixtures;

namespace Flickr.Net.IntegrationTest;

public class TestimonialsTests(WireMockFixture fixture) : IClassFixture<WireMockFixture>
{
    [Fact]
    public async Task AddTestimonialAsync_Succeeds()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.testimonials.addTestimonial", """{"stat":"ok"}""");

        using var client = fixture.CreateAuthenticatedClient();
        await client.Testimonials.AddTestimonialAsync("user1", "Great photographer!");
    }

    [Fact]
    public async Task GetAllTestimonialsAboutAsync_ReturnsTestimonials()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.testimonials.getAllTestimonialsAbout", """
            {"stat":"ok","testimonials":{"page":1,"pages":1,"perpage":10,"total":1,"testimonial":[{"testimonial_id":"t1","user_id":"user1","testimonial_text":"Great photographer!"}]}}
            """);

        using var client = fixture.CreateClient();
        var result = await client.Testimonials.GetAllTestimonialsAboutAsync("user1");

        Assert.NotNull(result);
        Assert.Equal(1, result.Values.Count);
    }

    [Fact]
    public async Task ApproveTestimonialAsync_Succeeds()
    {
        fixture.Reset();
        fixture.StubFlickrMethod("flickr.testimonials.approveTestimonial", """{"stat":"ok"}""");

        using var client = fixture.CreateAuthenticatedClient();
        await client.Testimonials.ApproveTestimonialAsync("t1");
    }
}
