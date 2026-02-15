using System.Text;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals;
using Xunit;

namespace Flickr.Net.Test.Entities;

public class NamespaceTests
{
    [Fact]
    public void JsonStringToNamespaces()
    {
        const string json = """
                            {
                              "stat": "ok",
                              "namespaces": {
                                "page": "1",
                                "total": "5",
                                "perpage": "500",
                                "pages": "1",
                                "namespace": [
                                  {
                                    "usage": "6538",
                                    "predicates": "13",
                                    "_content": "aero"
                                  },
                                  {
                                    "usage": "9072",
                                    "predicates": "24",
                                    "_content": "flickr"
                                  },
                                  {
                                    "usage": "670270",
                                    "predicates": "35",
                                    "_content": "geo"
                                  },
                                  {
                                    "usage": "23903",
                                    "predicates": "36",
                                    "_content": "taxonomy"
                                  },
                                  {
                                    "usage": "50449",
                                    "predicates": "4",
                                    "_content": "upcoming"
                                  }
                                ]
                              }
                            }
                            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<Namespaces>>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Namespaces>(items);
        Assert.IsType<Namespace>(items.Values[0]);
        Assert.Equal(items.Total, items.Values.Count);
    }
}