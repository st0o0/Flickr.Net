using System.Text;
using Flickr.Net.Enums;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals;

namespace Flickr.Net.Test.Entities;

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

        var result = FlickrConvert.DeserializeObject<FlickrResult<Institutions>>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Institutions>(items);
        Assert.IsType<Institution>(items.Values[0]);
        Assert.IsType<UrlType>(items.Values[0].Urls.Values[0].Type);
    }
}