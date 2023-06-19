using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals.ContractResolver;
using Flickr.Net.Core.NewEntities.Collections;
using Flickr.Net.Core.NewEntities;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

namespace Flickr.Net.Core.Test.Entities;

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

        var result = JsonConvert.DeserializeObject<FlickrResult<Pairs>>(json, new JsonSerializerSettings
        {
            ContractResolver = new GenericJsonPropertyNameContractResolver()
        });

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Pairs>(items);
        Assert.IsType<Pair>(items.Values[0]);
        Assert.Equal(items.Total, items.Values.Count);
    }
}
