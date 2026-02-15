using System.Text;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals;
using Xunit;

namespace Flickr.Net.Test.Entities;

public class PredicateTests
{
    [Fact]
    public void JsonStringToPredicates()
    {
        const string json = """
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

        var result = FlickrConvert.DeserializeObject<FlickrResult<Predicates>>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Predicates>(items);
        Assert.IsType<Predicate>(items.Values[0]);
        Assert.Equal(items.Total, items.Values.Count);
    }
}