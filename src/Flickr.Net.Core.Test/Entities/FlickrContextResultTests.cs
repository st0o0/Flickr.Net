using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals;

namespace Flickr.Net.Core.Test.Entities;

public class FlickrContextResultTests
{
    [Fact]
    public void JsonStringToFlickrContextResult()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "count": "3",
              "prevphoto": {
                "id": "2980",
                "secret": "973da1e709",
                "title": "boo!",
                "url": "/photos/bees/2980/"
              },
              "nextphoto": {
                "id": "2985",
                "secret": "059b664012",
                "title": "Amsterdam Amstel",
                "url": "/photos/bees/2985/"
              }
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrContextResult<NextPhoto, PrevPhoto>>(json);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        Assert.Equal(3, result.Count);
        Assert.IsType<NextPhoto>(result.NextPhoto);
        Assert.False(string.IsNullOrEmpty(result.NextPhoto.Id));
        Assert.IsType<PrevPhoto>(result.PrevPhoto);
        Assert.False(string.IsNullOrEmpty(result.PrevPhoto.Id));
    }
}