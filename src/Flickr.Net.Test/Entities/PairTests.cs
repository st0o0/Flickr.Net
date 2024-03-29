﻿using System.Text;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals;

namespace Flickr.Net.Test.Entities;

public class PairTests
{
    [Fact]
    public void JsonStringToPairs()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "pairs": {
                "page": "1",
                "total": "4",
                "perpage": "500",
                "pages": "3",
                "pair": [
                  {
                    "namespace": "aero",
                    "predicate": "airline",
                    "usage": "1093",
                    "_content": "aero:airline"
                  },
                  {
                    "namespace": "aero",
                    "predicate": "icao",
                    "usage": "4",
                    "_content": "aero:icao"
                  },
                  {
                    "namespace": "aero",
                    "predicate": "model",
                    "usage": "1026",
                    "_content": "aero:model"
                  },
                  {
                    "namespace": "aero",
                    "predicate": "tail",
                    "usage": "1048",
                    "_content": "aero:tail"
                  }
                ]
              }
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<Pairs>>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Pairs>(items);
        Assert.IsType<Pair>(items.Values[0]);
        Assert.Equal(items.Total, items.Values.Count);
    }
}