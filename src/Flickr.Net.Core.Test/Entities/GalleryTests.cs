using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals.ContractResolver;
using Flickr.Net.Core.NewEntities;
using Newtonsoft.Json;

namespace Flickr.Net.Core.Test.Entities;

public class GalleryTests
{
    [Fact]
    public void JsonStringToGalleries()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "galleries": {
                "total": "2",
                "page": "1",
                "pages": "1",
                "per_page": "100",
                "user_id": "34427469121@N01",
                "gallery": [
                  {
                    "id": "5704-72157622637971865",
                    "url": "http://www.flickr.com/photos/george/galleries/72157622637971865",
                    "owner": "34427469121@N01",
                    "date_create": "1257711422",
                    "date_update": "1260360756",
                    "primary_photo_id": "107391222",
                    "primary_photo_server": "39",
                    "primary_photo_farm": "1",
                    "primary_photo_secret": "ffa",
                    "count_photos": "16",
                    "count_videos": "2",
                    "title": "I like me some black & white",
                    "description": "black and whites"
                  },
                  {
                    "id": "5704-72157622566655097",
                    "url": "http://www.flickr.com/photos/george/galleries/72157622566655097",
                    "owner": "34427469121@N01",
                    "date_create": "1256852229",
                    "date_update": "1260462343",
                    "primary_photo_id": "497374910",
                    "primary_photo_server": "231",
                    "primary_photo_farm": "1",
                    "primary_photo_secret": "9ae0f",
                    "count_photos": "18",
                    "count_videos": "0",
                    "title": "People Sleeping in Libraries",
                    "description": []
                  }
                ]
              }
            }
            """;

        var result = JsonConvert.DeserializeObject<FlickrResult<Galleries>>(json, new JsonSerializerSettings
        {
            ContractResolver = new GenericJsonPropertyNameContractResolver()
        });

        Assert.NotNull(result);
        Assert.False(result.HasError);
        Assert.IsType<Galleries>(result.Content);
        var items = result.Content;
        Assert.Equal("34427469121@N01", items.UserId);
        Assert.NotEmpty(items.Values);
        Assert.IsType<Gallery>(items.Values[0]);
        Assert.Equal(items.Values.Count, items.Total);
        Assert.IsType<DateTime>(items.Values[0].UpdateDate);
        Assert.IsType<DateTime>(items.Values[0].CreateDate);
    }

    [Fact]
    public void JsonStringToGalleryPhotos()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "photos": {
                "page": "1",
                "pages": "1",
                "perpage": "500",
                "total": "2",
                "photo": [
                  {
                    "id": "2822546461",
                    "owner": "78398753@N00",
                    "secret": "2dbcdb589f",
                    "server": "1",
                    "farm": "1",
                    "title": "FOO",
                    "ispublic": "1",
                    "isfriend": "0",
                    "isfamily": "0",
                    "is_primary": "1",
                    "has_comment": "1",
                    "comment": [
                      "best cat picture ever!",
                      "best cat picture ever!"
                    ]
                  },
                  {
                    "id": "2822544806",
                    "owner": "78398753@N00",
                    "secret": "bd93cbe917",
                    "server": "1",
                    "farm": "1",
                    "title": "OOK",
                    "ispublic": "1",
                    "isfriend": "0",
                    "isfamily": "0",
                    "is_primary": "0",
                    "has_comment": "0"
                  }
                ]
              }
            }
            """;

        var result = JsonConvert.DeserializeObject<FlickrResult<GalleryPhotos>>(json, new JsonSerializerSettings
        {
            ContractResolver = new GenericJsonPropertyNameContractResolver()
        });

        Assert.NotNull(result);
        Assert.False(result.HasError);
        Assert.IsType<GalleryPhotos>(result.Content);
        var items = result.Content;
        Assert.NotEmpty(items.Values);
        Assert.IsType<GalleryPhoto>(items.Values[0]);
        Assert.Equal(items.Values.Count, items.Total);
        Assert.True(items.Values[0].HasComments);
        Assert.True(items.Values[0].IsPrimary);
        Assert.True(items.Values[0].Comments.Any());
        Assert.False(items.Values[1].HasComments);
        Assert.False(items.Values[1].IsPrimary);
        Assert.False(items.Values[1].Comments.Any());
    }
}