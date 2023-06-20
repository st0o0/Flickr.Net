using Flickr.Net.Core.Enums;
using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals.ContractResolver;
using Flickr.Net.Core.NewEntities;
using Newtonsoft.Json;

namespace Flickr.Net.Core.Test.Entities;

public class InstitutionTests
{
    [Fact]
    public void JsonStringToInstitutions()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "institutions": {
                "institution": [
                  {
                    "nsid": "123456@N01",
                    "date_launch": "1232000000",
                    "name": "Institution",
                    "urls": {
                      "url": [
                        {
                          "type": "site",
                          "_content": "http://example.com/"
                        },
                        {
                          "type": "license",
                          "_content": "http://example.com/commons/license"
                        },
                        {
                          "type": "flickr",
                          "_content": "http://flickr.com/photos/institution"
                        }
                      ]
                    }
                  },
                  {
                    "nsid": "123456@N01",
                    "date_launch": "1232000000",
                    "name": "Institution",
                    "urls": {
                      "url": [
                        {
                          "type": "site",
                          "_content": "http://example.com/"
                        },
                        {
                          "type": "license",
                          "_content": "http://example.com/commons/license"
                        },
                        {
                          "type": "flickr",
                          "_content": "http://flickr.com/photos/institution"
                        }
                      ]
                    }
                  }
                ]
              }
            }
            """;

        var result = JsonConvert.DeserializeObject<FlickrResult<Institutions>>(json, new JsonSerializerSettings
        {
            ContractResolver = new GenericJsonPropertyNameContractResolver()
        });

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Institutions>(items);
        Assert.IsType<Institution>(items.Values[0]);
        Assert.IsType<UrlType>(items.Values[0].Urls.Values[0].Type);
    }
}