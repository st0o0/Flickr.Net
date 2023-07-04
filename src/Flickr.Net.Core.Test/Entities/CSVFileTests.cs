using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals;

namespace Flickr.Net.Core.Test.Entities;

public class CSVFileTests
{
    [Fact]
    public void JsonStringToCSVFiles()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "stats": {
                "csvfiles": [
                  {
                    "href": "http://farm4.static.flickr.com/3496/stats/72157623902771865_faaa.csv",
                    "type": "daily",
                    "date": "2010-04-01"
                  },
                  {
                    "href": "http://farm4.static.flickr.com/3376/stats/72157624027152370_fbbb.csv",
                    "type": "monthly",
                    "date": "2010-04-01"
                  },
                  {
                    "href": "http://farm5.static.flickr.com/4006/stats/72157623627769689_fccc.csv",
                    "type": "daily",
                    "date": "2010-03-01"
                  }
                ]
              }
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<CSVFiles>>(json);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<CSVFiles>(items);
        Assert.NotEmpty(items.Values);
        Assert.Equal(new DateOnly(2010, 04, 01), items.Values[0].Date);
        Assert.Equal(new DateOnly(2010, 04, 01), items.Values[1].Date);
        Assert.Equal(new DateOnly(2010, 03, 01), items.Values[2].Date);
    }
}
