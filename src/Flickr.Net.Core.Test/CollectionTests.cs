﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals.ContractResolver;
using Flickr.Net.Core.NewEntities.Collections;
using Flickr.Net.Core.NewEntities;
using Newtonsoft.Json;

namespace Flickr.Net.Core.Test;

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

        var result = JsonConvert.DeserializeObject<FlickrResult<Collection>>(json, new JsonSerializerSettings
        {
            ContractResolver = new GenericJsonPropertyNameContractResolver()
        });

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Collection>(items);
        Assert.IsType<DateTime>(items.DateCreate);
        Assert.IsType<Photos>(items.IconPhotos);
        Assert.Equal(3, items.IconPhotos.Values.Count);
        Assert.True(items.IconPhotos.Values[0].IsPublic);
        Assert.False(items.IconPhotos.Values[0].IsFamily);
        Assert.False(items.IconPhotos.Values[0].IsFriend);
    }
}
