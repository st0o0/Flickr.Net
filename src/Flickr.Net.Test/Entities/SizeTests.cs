using System.Text;
using Flickr.Net.Enums;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals;

namespace Flickr.Net.Test.Entities;

public class SizeTests
{
    [Fact]
    public void JsonStringToSizes()
    {
        var json = /*lang=json,strict*/ """
            {
                "sizes": {
                    "canblog": 1,
                    "canprint": 1,
                    "candownload": 1,
                    "size": [
                        {
                            "label": "Square",
                            "width": 75,
                            "height": 75,
                            "source": "https:\/\/live.staticflickr.com\/65535\/52931686554_b77aff865b_s.jpg",
                            "url": "https:\/\/www.flickr.com\/photos\/192376927@N06\/52931686554\/sizes\/sq\/",
                            "media": "photo"
                        },
                        {
                            "label": "Large Square",
                            "width": 150,
                            "height": 150,
                            "source": "https:\/\/live.staticflickr.com\/65535\/52931686554_b77aff865b_q.jpg",
                            "url": "https:\/\/www.flickr.com\/photos\/192376927@N06\/52931686554\/sizes\/q\/",
                            "media": "photo"
                        },
                        {
                            "label": "Thumbnail",
                            "width": 100,
                            "height": 67,
                            "source": "https:\/\/live.staticflickr.com\/65535\/52931686554_b77aff865b_t.jpg",
                            "url": "https:\/\/www.flickr.com\/photos\/192376927@N06\/52931686554\/sizes\/t\/",
                            "media": "photo"
                        },
                        {
                            "label": "Small",
                            "width": 240,
                            "height": 160,
                            "source": "https:\/\/live.staticflickr.com\/65535\/52931686554_b77aff865b_m.jpg",
                            "url": "https:\/\/www.flickr.com\/photos\/192376927@N06\/52931686554\/sizes\/s\/",
                            "media": "photo"
                        },
                        {
                            "label": "Small 320",
                            "width": 320,
                            "height": 213,
                            "source": "https:\/\/live.staticflickr.com\/65535\/52931686554_b77aff865b_n.jpg",
                            "url": "https:\/\/www.flickr.com\/photos\/192376927@N06\/52931686554\/sizes\/n\/",
                            "media": "photo"
                        },
                        {
                            "label": "Small 400",
                            "width": 400,
                            "height": 267,
                            "source": "https:\/\/live.staticflickr.com\/65535\/52931686554_b77aff865b_w.jpg",
                            "url": "https:\/\/www.flickr.com\/photos\/192376927@N06\/52931686554\/sizes\/w\/",
                            "media": "photo"
                        },
                        {
                            "label": "Medium",
                            "width": 500,
                            "height": 333,
                            "source": "https:\/\/live.staticflickr.com\/65535\/52931686554_b77aff865b.jpg",
                            "url": "https:\/\/www.flickr.com\/photos\/192376927@N06\/52931686554\/sizes\/m\/",
                            "media": "photo"
                        },
                        {
                            "label": "Medium 640",
                            "width": 640,
                            "height": 427,
                            "source": "https:\/\/live.staticflickr.com\/65535\/52931686554_b77aff865b_z.jpg",
                            "url": "https:\/\/www.flickr.com\/photos\/192376927@N06\/52931686554\/sizes\/z\/",
                            "media": "photo"
                        },
                        {
                            "label": "Medium 800",
                            "width": 800,
                            "height": 533,
                            "source": "https:\/\/live.staticflickr.com\/65535\/52931686554_b77aff865b_c.jpg",
                            "url": "https:\/\/www.flickr.com\/photos\/192376927@N06\/52931686554\/sizes\/c\/",
                            "media": "photo"
                        },
                        {
                            "label": "Large",
                            "width": 1024,
                            "height": 683,
                            "source": "https:\/\/live.staticflickr.com\/65535\/52931686554_b77aff865b_b.jpg",
                            "url": "https:\/\/www.flickr.com\/photos\/192376927@N06\/52931686554\/sizes\/l\/",
                            "media": "photo"
                        },
                        {
                            "label": "Large 1600",
                            "width": 1600,
                            "height": 1067,
                            "source": "https:\/\/live.staticflickr.com\/65535\/52931686554_d03048e63e_h.jpg",
                            "url": "https:\/\/www.flickr.com\/photos\/192376927@N06\/52931686554\/sizes\/h\/",
                            "media": "photo"
                        },
                        {
                            "label": "Large 2048",
                            "width": 2048,
                            "height": 1365,
                            "source": "https:\/\/live.staticflickr.com\/65535\/52931686554_e8edca25f1_k.jpg",
                            "url": "https:\/\/www.flickr.com\/photos\/192376927@N06\/52931686554\/sizes\/k\/",
                            "media": "photo"
                        },
                        {
                            "label": "Original",
                            "width": 6000,
                            "height": 4000,
                            "source": "https:\/\/live.staticflickr.com\/65535\/52931686554_6b81f5e9ce_o.png",
                            "url": "https:\/\/www.flickr.com\/photos\/192376927@N06\/52931686554\/sizes\/o\/",
                            "media": "photo"
                        }
                    ]
                },
                "stat": "ok"
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<Sizes>>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Sizes>(items);
        Assert.True(items.CanBlog);
        Assert.True(items.CanPrint);
        Assert.True(items.CanDownload);
        Assert.NotEmpty(items.Values);
        Assert.Equal(13, items.Values.Count);

        Assert.All(items.Values, item =>
        {
            Assert.Equal(MediaType.Photo, item.Media);
        });
    }
}