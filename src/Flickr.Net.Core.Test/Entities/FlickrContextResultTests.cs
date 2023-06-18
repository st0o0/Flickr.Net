using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals.ContractResolver;
using Flickr.Net.Core.NewEntities.Collections;
using Flickr.Net.Core.NewEntities.Paging;
using Newtonsoft.Json;

namespace Flickr.Net.Core.Test.Entities;

public class FlickrContextResultTests
{
    [Fact]
    public void JsonStringToFlickrContextResult()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "count": "3",
              "prevphoto": {
                "id": "2980",
                "secret": "973da1e709",
                "title": "boo!",
                "url": "/photos/bees/2980/"
              },
              "nextphoto": {
                "id": "2985",
                "secret": "059b664012",
                "title": "Amsterdam Amstel",
                "url": "/photos/bees/2985/"
              }
            }
            """;

        var result = JsonConvert.DeserializeObject<FlickrContextResult<NextPhoto, PrevPhoto>>(json, new JsonSerializerSettings
        {
            ContractResolver = new GenericJsonPropertyNameContractResolver()
        });

        Assert.NotNull(result);
        Assert.False(result.HasError);
        Assert.Equal(3, result.Count);
        Assert.IsType<NextPhoto>(result.NextPhoto);
        Assert.NotEmpty(result.NextPhoto.Id);
        Assert.IsType<PrevPhoto>(result.PrevPhoto);
        Assert.NotEmpty(result.PrevPhoto.Id);
    }
}
