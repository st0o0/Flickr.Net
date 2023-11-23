using System.Text;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals;

namespace Flickr.Net.Test.Entities;

public class CollectionTests
{
    [Fact]
    public void JsonStringToCollection()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "collection": {
                "id": "12-72157594586579649",
                "child_count": "6",
                "datecreate": "1173812218",
                "iconlarge": "https://combo.staticflickr.com/pw/images/collection_default_l.gif",
                "iconsmall": "https://combo.staticflickr.com/pw/images/collection_default_s.gif",
                "server": "187",
                "secret": "36",
                "title": "All My Photos",
                "description": "Photos!",
                "iconphotos": {
                  "photo": [
                    {
                      "id": "14",
                      "owner": "12@N01",
                      "secret": "b57ba5c",
                      "server": "51",
                      "farm": "1",
                      "title": "in full cap and gown",
                      "ispublic": "1",
                      "isfriend": "0",
                      "isfamily": "0"
                    },
                    {
                      "id": "15",
                      "owner": "12@N01",
                      "secret": "ba1c2a8",
                      "server": "58",
                      "farm": "1",
                      "title": "Just beyond the door",
                      "ispublic": "0",
                      "isfriend": "1",
                      "isfamily": "0"
                    },
                    {
                      "id": "17",
                      "owner": "12@N01",
                      "secret": "0001969",
                      "server": "73",
                      "farm": "1",
                      "title": "IMG_3787.JPG",
                      "ispublic": "1",
                      "isfriend": "0",
                      "isfamily": "0"
                    }
                  ]
                }
              }
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<Collection>>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Collection>(items);
        Assert.IsType<DateTime>(items.CreateDate);
        Assert.IsType<Photos>(items.IconPhotos);
        Assert.NotEmpty(items.IconPhotos.Values);
        Assert.Equal(3, items.IconPhotos.Values.Count);
        Assert.True(items.IconPhotos.Values[0].IsPublic);
        Assert.False(items.IconPhotos.Values[0].IsFamily);
        Assert.False(items.IconPhotos.Values[0].IsFriend);
    }

    [Fact]
    public void JsonStringToCollections()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "collections": {
                "collection": [
                  {
                    "id": "12-72157594586579649",
                    "title": "All My Photos",
                    "description": "a collection",
                    "iconlarge": "https://combo.staticflickr.com/pw/images/collection_default_l.gif",
                    "iconsmall": "https://combo.staticflickr.com/pw/images/collection_default_s.gif",
                    "set": [
                      {
                        "id": "92157594171298291",
                        "title": "kitesurfing",
                        "description": "a set"
                      },
                      {
                        "id": "72157594247596158",
                        "title": "faves",
                        "description": "some favorites."
                      }
                    ]
                  },
                  {
                    "id": "12-72157594586579649",
                    "title": "All My Photos",
                    "description": "a collection",
                    "iconlarge": "https://combo.staticflickr.com/pw/images/collection_default_l.gif",
                    "iconsmall": "https://combo.staticflickr.com/pw/images/collection_default_s.gif",
                    "set": [
                      {
                        "id": "92157594171298291",
                        "title": "kitesurfing",
                        "description": "a set"
                      },
                      {
                        "id": "72157594247596158",
                        "title": "faves",
                        "description": "some favorites."
                      }
                    ]
                  }
                ]
              }
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<Collections>>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Collections>(items);
        Assert.NotEmpty(items.Values);
        Assert.IsType<Collection>(items.Values[0]);
        Assert.IsType<DateTime>(items.Values[0].CreateDate);
        Assert.Equal(2, items.Values.Count);
        Assert.IsType<CollectionSet>(items.Values[0].Sets[0]);
        Assert.Equal(2, items.Values[0].Sets.Count);
        Assert.IsType<CollectionSet>(items.Values[1].Sets[0]);
        Assert.Equal(2, items.Values[1].Sets.Count);
    }
}