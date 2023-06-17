﻿using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals.ContractResolver;
using Flickr.Net.Core.NewEntities;
using Flickr.Net.Core.NewEntities.Collections;
using Newtonsoft.Json;

namespace Flickr.Net.Core.Test;

public class CamerasTests
{
    [Fact]
    public void JsonStringToCameras()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "cameras": {
                "brand": "apple",
                "camera": [
                  {
                    "id": "iphone_9000",
                    "name": "iPhone 9000",
                    "details": {
                      "megapixels": "22.0",
                      "zoom": "3.0",
                      "lcd_size": "40.5",
                      "storage_type": "Flash"
                    },
                    "images": {
                      "small": "http://farm3.staticflickr.com/1234/cameras/123456_model_small_123456.jpg",
                      "large": "http://farm3.staticflickr.com/1234/cameras/123456_model_large_123456.jpg"
                    }
                  },
                  {
                    "id": "iphone_9000",
                    "name": "iPhone 9000",
                    "details": {
                      "megapixels": "22.0",
                      "zoom": "3.0",
                      "lcd_size": "40.5",
                      "storage_type": "Flash"
                    },
                    "images": {
                      "small": "http://farm3.staticflickr.com/1234/cameras/123456_model_small_123456.jpg",
                      "large": "http://farm3.staticflickr.com/1234/cameras/123456_model_large_123456.jpg"
                    }
                  }
                ]
              }
            }
            """;

        var result = JsonConvert.DeserializeObject<FlickrResult<Cameras>>(json, new JsonSerializerSettings
        {
            ContractResolver = new GenericJsonPropertyNameContractResolver()
        });

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Cameras>(items);
        Assert.IsType<Camera>(items.Values[0]);
        Assert.NotEmpty(items.Values[0].Name);
        Assert.IsType<Details>(items.Values[0].Details);
        Assert.NotEmpty(items.Values[0].Details.Zoom);
        Assert.IsType<Image>(items.Values[0].Image);
        Assert.NotEmpty(items.Values[0].Image.Large);
    }

    [Fact]
    public void JsonStringToBrands()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "brands": {
                "brand": [
                  {
                    "id": "canon",
                    "_content": "Canon"
                  },
                  {
                    "id": "nikon",
                    "_content": "Nikon"
                  },
                  {
                    "id": "apple",
                    "_content": "Apple"
                  }
                ]
              }
            }
            """;

        var result = JsonConvert.DeserializeObject<FlickrResult<Brands>>(json, new JsonSerializerSettings
        {
            ContractResolver = new GenericJsonPropertyNameContractResolver()
        });

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Brands>(items);
        Assert.IsType<Brand>(items.Values[0]);
        Assert.Equal("canon", items.Values[0].Id);
        Assert.Equal("nikon", items.Values[1].Id);
        Assert.Equal("apple", items.Values[2].Id);
    }
}
