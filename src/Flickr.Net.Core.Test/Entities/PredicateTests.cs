using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals;

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

        var result = FlickrConvert.DeserializeObject<FlickrResult<Predicates>>(json);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Predicates>(items);
        Assert.IsType<Predicate>(items.Values[0]);
        Assert.Equal(items.Total, items.Values.Count);
    }
}