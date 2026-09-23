using System.Text;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals;

namespace Flickr.Net.Test.Entities;

public class PopularPhotoDateRangeTests
{
    [Fact]
    public void JsonStringToPopularPhotoDateRange()
    {
        const string json = """
            {
                "daterange": {
                    "startdate": "2024-01-01",
                    "enddate": "2024-12-31"
                },
                "stat": "ok"
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<PopularPhotoDateRange>>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var range = result.Content;
        Assert.IsType<PopularPhotoDateRange>(range);
        Assert.Equal("2024-01-01", range.StartDate);
        Assert.Equal("2024-12-31", range.EndDate);
    }
}
