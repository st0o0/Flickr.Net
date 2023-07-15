using System.Text;
using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals;
using Newtonsoft.Json;

namespace Flickr.Net.Core.Test.Entities;

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

        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
        using var sr = new StreamReader(ms);
        using var reader = new JsonTextReader(sr);

        var result = FlickrConvert.DeserializeObject<FlickrResult<Referrers>>(reader);

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
