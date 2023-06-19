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

namespace Flickr.Net.Core.Test.Entities;

public class PredicateTests
{
    [Fact]
    public void JsonStringToPredicates()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "predicates": {
                "page": "1",
                "pages": "1",
                "total": "3",
                "perpage": "500",
                "predicate": [
                  {
                    "usage": "20",
                    "namespaces": "1",
                    "_content": "elbow"
                  },
                  {
                    "usage": "52",
                    "namespaces": "2",
                    "_content": "face"
                  },
                  {
                    "usage": "10",
                    "namespaces": "1",
                    "_content": "hand"
                  }
                ]
              }
            }
            """;

        var result = JsonConvert.DeserializeObject<FlickrResult<Predicates>>(json, new JsonSerializerSettings
        {
            ContractResolver = new GenericJsonPropertyNameContractResolver()
        });

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Predicates>(items);
        Assert.IsType<Predicate>(items.Values[0]);
        Assert.Equal(items.Total, items.Values.Count);
    }
}
