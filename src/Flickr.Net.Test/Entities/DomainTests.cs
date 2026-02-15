using System.Text;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals;
using Xunit;

namespace Flickr.Net.Test.Entities;

public class DomainTests
{
    [Fact]
    public void JsonStringToDomains()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "domains": {
                "page": "1",
                "perpage": "25",
                "pages": "1",
                "total": "3",
                "domain": [
                  {
                    "name": "images.search.yahoo.com",
                    "views": "127"
                  },
                  {
                    "name": "flickr.com",
                    "views": "122"
                  },
                  {
                    "name": "images.google.com",
                    "views": "70"
                  }
                ]
              }
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<Domains>>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Domains>(items);
        Assert.NotEmpty(items.Values);
        Assert.Equal(items.Total, items.Values.Count);
        Assert.Equal(127, items.Values[0].Views);
        Assert.Equal(122, items.Values[1].Views);
        Assert.Equal(70, items.Values[2].Views);
    }
}
