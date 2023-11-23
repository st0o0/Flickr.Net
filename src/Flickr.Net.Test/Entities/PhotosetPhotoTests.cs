using System.Text;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals;

namespace Flickr.Net.Test.Entities;

public class PhotosetPhotoTests
{
    [Fact]
    public void JsonStringToPhotosetPhotos()
    {
        var json = /*lang=json,strict*/ """
            {
                "photoset": {
                    "id": "72177720308632074",
                    "primary": "52931686554",
                    "owner": "192376927@N06",
                    "ownername": "st0o0",
                    "photo": [
                        {
                            "id": "52931686554",
                            "secret": "b77aff865b",
                            "server": "65535",
                            "farm": 66,
                            "title": "DSC04245",
                            "isprimary": "1",
                            "ispublic": 1,
                            "isfriend": 0,
                            "isfamily": 0
                        },
                        {
                            "id": "52931686549",
                            "secret": "9b203d4894",
                            "server": "65535",
                            "farm": 66,
                            "title": "DSC04707",
                            "isprimary": "0",
                            "ispublic": 1,
                            "isfriend": 0,
                            "isfamily": 0
                        }
                    ],
                    "page": 1,
                    "per_page": 500,
                    "perpage": 500,
                    "pages": 1,
                    "title": "Vreden_13052022",
                    "total": 2
                },
                "stat": "ok"
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<PhotosetPhotos>>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<PhotosetPhotos>(items);
        Assert.Equal(2, items.Total);
        Assert.NotEmpty(items.Values);
        Assert.IsType<PhotosetPhoto>(items.Values[0]);
        Assert.Equal(2, items.Values.Count);
    }
}
