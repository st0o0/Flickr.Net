using System.Text;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals;

namespace Flickr.Net.Test.Entities;

public class TestimonialTests
{
    [Fact]
    public void JsonStringToTestimonials()
    {
        const string json = """
            {
                "testimonials": {
                    "page": 1,
                    "pages": 1,
                    "perpage": 10,
                    "total": 2,
                    "testimonial": [
                        {
                            "testimonial_id": "12345",
                            "user_id": "12345678@N00",
                            "username": "photographer_jane",
                            "target_user_id": "87654321@N00",
                            "_content": "Great photographer with an amazing eye for detail!",
                            "date_create": "1695820800",
                            "approved": true
                        },
                        {
                            "testimonial_id": "12346",
                            "user_id": "11223344@N00",
                            "username": "photo_bob",
                            "target_user_id": "87654321@N00",
                            "_content": "Always inspiring work.",
                            "date_create": "1695907200",
                            "approved": false
                        }
                    ]
                },
                "stat": "ok"
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<Testimonials>>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var testimonials = result.Content;
        Assert.IsType<Testimonials>(testimonials);
        Assert.Equal(2, testimonials.Values.Count);
        Assert.Equal(2, testimonials.Total);

        var first = testimonials.Values[0];
        Assert.Equal("12345", first.TestimonialId);
        Assert.Equal("12345678@N00", first.UserId);
        Assert.Equal("photographer_jane", first.Username);
        Assert.Equal("87654321@N00", first.TargetUserId);
        Assert.Equal("Great photographer with an amazing eye for detail!", first.Content);
        Assert.Equal("1695820800", first.DateCreate);
        Assert.True(first.Approved);

        var second = testimonials.Values[1];
        Assert.False(second.Approved);
    }
}
