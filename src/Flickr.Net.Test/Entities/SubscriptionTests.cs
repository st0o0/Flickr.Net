﻿using System.Text;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals;

namespace Flickr.Net.Test.Entities;

public class SubscriptionTests
{
    [Fact]
    public void JsonStringToSubscriptions()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "subscriptions": {
                "subscription": [
                  {
                    "topic": "contacts_photos",
                    "callback": "http://example.com/contacts_photos_endpoint?user=12345",
                    "pending": "0",
                    "date_create": "1309293755",
                    "lease_seconds": "0",
                    "expiry": "1309380155",
                    "verify_attempts": "0"
                  },
                  {
                    "topic": "contacts_faves",
                    "callback": "http://example.com/contacts_faves_endpoint?user=12345",
                    "pending": "0",
                    "date_create": "1309293785",
                    "lease_seconds": "0",
                    "expiry": "1309380185",
                    "verify_attempts": "0"
                  }
                ]
              }
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<Subscriptions>>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Subscriptions>(items);
        Assert.NotEmpty(items.Values);
        Assert.IsType<DateTime>(items.Values[0].Expiry);
        Assert.IsType<DateTime>(items.Values[0].CreateDate);
    }
}
