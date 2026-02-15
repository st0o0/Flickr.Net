using System.Text;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals;
using Xunit;

namespace Flickr.Net.Test.Entities;

public class ViewsTests
{
    [Fact]
    public void JsonStringToViews()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "stats": {
                "total": {
                  "views": "469"
                },
                "photos": {
                  "views": "386"
                },
                "photostream": {
                  "views": "72"
                },
                "sets": {
                  "views": "11"
                },
                "collections": {
                  "views": "0"
                }
              }
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<Views>>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Views>(items);
        Assert.Equal(469, items.Total.Views);
        Assert.Equal(386, items.Photos.Views);
        Assert.Equal(72, items.Photostream.Views);
        Assert.Equal(11, items.Sets.Views);
        Assert.Equal(0, items.Collections.Views);
    }
}
