using System.Text;
using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals;
using Newtonsoft.Json;

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

        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));

        var result = FlickrConvert.DeserializeObject<FlickrResult<UploadStatus>>(ms);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<UploadStatus>(items);
        Assert.True(items.IsPro);
        Assert.IsType<SetsStatus>(items.Sets);
        Assert.IsType<FileSizeStatus>(items.Filesize);
        Assert.IsType<BandwidthStatus>(items.Bandwidth);
        Assert.IsType<VideoStatus>(items.Videos);
    }
}
