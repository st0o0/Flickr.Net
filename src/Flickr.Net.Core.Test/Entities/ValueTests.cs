﻿using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals;

namespace Flickr.Net.Core.Test.Entities;

public class ValueTests
{
    [Fact]
    public void JsonStringToValues()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "values": {
                "namespace": "taxonomy",
                "predicate": "common",
                "page": "1",
                "total": "2",
                "perpage": "500",
                "pages": "1",
                "value": [
                  {
                    "usage": "4",
                    "namespace": "taxonomy",
                    "predicate": "common",
                    "first_added": "1244232796",
                    "last_added": "1244232796",
                    "_content": "maui chaff flower"
                  },
                  {
                    "usage": "4",
                    "namespace": "taxonomy",
                    "predicate": "common",
                    "first_added": "1244232796",
                    "last_added": "1244232796",
                    "_content": "maui chaff flower"
                  }
                ]
              }
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<Values>>(json);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Values>(items);
        Assert.IsType<Value>(items.Values[0]);
        Assert.Equal(items.Total, items.Values.Count);
    }
}