using System.Text;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals;

namespace Flickr.Net.Test.Entities;

public class ReferrerTests
{
    [Fact]
    public void JsonStringToReferrers()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "domain": {
                "page": "1",
                "perpage": "25",
                "pages": "1",
                "total": "3",
                "name": "flickr.com",
                "referrer": [
                  {
                    "url": "http://flickr.com/",
                    "views": "11"
                  },
                  {
                    "url": "http://flickr.com/photos/friends/",
                    "views": "8"
                  },
                  {
                    "url": "http://flickr.com/search/?q=stats+api",
                    "views": "2",
                    "searchterm": "stats api"
                  }
                ]
              }
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<Referrers>>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Referrers>(items);
        Assert.NotEmpty(items.Values);
        Assert.Equal(items.Total, items.Values.Count);
        Assert.Equal(11, items.Values[0].Views);
        Assert.Equal(8, items.Values[1].Views);
        Assert.Equal(2, items.Values[2].Views);
    }
}
