using Flickr.Net.Core.Enums;
using Flickr.Net.Core.Extensions;
using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals;

namespace Flickr.Net.Core.Test.Entities;

public class ItemTests
{
    [Fact]
    public void JsonStringToItems()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "items": {
                "item": [
                  {
                    "type": "photoset",
                    "id": "395",
                    "owner": "12037949754@N01",
                    "primary": "6521",
                    "secret": "5a3cc65d72",
                    "server": "2",
                    "commentsold": "1",
                    "commentsnew": "1",
                    "views": "33",
                    "photos": "7",
                    "more": "0",
                    "title": "A set of photos",
                    "activity": {
                      "event": [
                        {
                          "type": "comment",
                          "user": "12037949754@N01",
                          "username": "Bees",
                          "dateadded": "1144086424",
                          "_content": "yay"
                        }
                      ]
                    }
                  },
                  {
                    "type": "photo",
                    "id": "10289",
                    "owner": "12037949754@N01",
                    "secret": "34da0d3891",
                    "server": "2",
                    "commentsold": "1",
                    "commentsnew": "1",
                    "notesold": "0",
                    "notesnew": "1",
                    "views": "47",
                    "faves": "0",
                    "more": "0",
                    "title": "A photo",
                    "activity": {
                      "event": [
                        {
                          "type": "comment",
                          "user": "12037949754@N01",
                          "username": "Bees",
                          "dateadded": "1133806604",
                          "_content": "test"
                        },
                        {
                          "type": "note",
                          "user": "12037949754@N01",
                          "username": "Bees",
                          "dateadded": "1118785229",
                          "_content": "nice"
                        }
                      ]
                    }
                  },
                  {
                    "type": "photo",
                    "id": "10289",
                    "owner": "12037949754@N01",
                    "secret": "34da0d3891",
                    "server": "2",
                    "commentsold": "1",
                    "commentsnew": "1",
                    "notesold": "0",
                    "notesnew": "1",
                    "views": "47",
                    "faves": "0",
                    "more": "0",
                    "title": "A photo",
                    "activity": {
                      "event": [
                        {
                          "type": "comment",
                          "user": "12037949754@N01",
                          "username": "Bees",
                          "dateadded": "1133806604",
                          "_content": "test"
                        },
                        {
                          "type": "note",
                          "user": "12037949754@N01",
                          "username": "Bees",
                          "dateadded": "1118785229",
                          "_content": "nice"
                        }
                      ]
                    }
                  }
                ]
              }
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<Items>>(json);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Items>(items);
        Assert.Equal(3, items.Values.Count);
        Assert.IsType<ItemType>(items.Values[0].Type);
        Assert.IsType<DateTime>(items.Values[0].Activity.Events[0].AddedDate);
        Assert.IsType<EventType>(items.Values[0].Activity.Events[0].Type);
        Assert.NotEmpty(items.Values[0].ToBuddyIconUrl());
        Assert.NotEmpty(items.Values[0].ToSquareUrl());
        Assert.NotEmpty(items.Values[0].ToSmallUrl());
    }
}