using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Flickr.Net.Core.Enums;
using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals;

namespace Flickr.Net.Core.Test.Entities;

public class UploadStatusTests
{
    [Fact]
    public void JsonStringToUploadStatus()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "user": {
                "id": "12037949754@N01",
                "ispro": "1",
                "username": "Bees",
                "bandwidth": {
                  "maxbytes": "2147483648",
                  "maxkb": "2097152",
                  "usedbytes": "383724",
                  "usedkb": "374",
                  "remainingbytes": "2147099924",
                  "remainingkb": "2096777"
                },
                "filesize": {
                  "maxbytes": "10485760",
                  "maxkb": "10240"
                },
                "sets": {
                  "created": "27",
                  "remaining": "lots"
                },
                "videos": {
                  "uploaded": "5",
                  "remaining": "lots"
                }
              }
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<UploadStatus>>(json);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<UploadStatus>(items);
        Assert.True(items.IsPro);
        Assert.IsType<Sets>(items.Sets);
        Assert.IsType<Filesize>(items.Filesize);
        Assert.IsType<Bandwidth>(items.Bandwidth);
        Assert.IsType<Videos>(items.Videos);
    }
}
