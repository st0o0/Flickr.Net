using System.Text;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals;
using Xunit;

namespace Flickr.Net.Test.Entities;

public class PhotoCountTests
{
    [Fact]
    public void JsonStringToPhotoCount()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "photocounts": {
                "photocount": [
                  {
                    "count": "4",
                    "fromdate": "1093566950",
                    "todate": "1093653350"
                  },
                  {
                    "count": "0",
                    "fromdate": "1093653350",
                    "todate": "1093739750"
                  },
                  {
                    "count": "0",
                    "fromdate": "1093739750",
                    "todate": "1093826150"
                  },
                  {
                    "count": "2",
                    "fromdate": "1093826150",
                    "todate": "1093912550"
                  },
                  {
                    "count": "0",
                    "fromdate": "1093912550",
                    "todate": "1093998950"
                  },
                  {
                    "count": "0",
                    "fromdate": "1093998950",
                    "todate": "1094085350"
                  },
                  {
                    "count": "0",
                    "fromdate": "1094085350",
                    "todate": "1094171750"
                  }
                ]
              }
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<PhotoCounts>>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<PhotoCounts>(items);
        Assert.IsType<PhotoCount>(items.Values[0]);
        Assert.Equal(7, items.Values.Count);
    }
}
