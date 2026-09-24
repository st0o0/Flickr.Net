using System.Text;
using Flickr.Net.Flickrs.Results;
using Flickr.Net.Internals;

namespace Flickr.Net.Test.Entities;

public class PlaceTests
{
    [Fact]
    public void JsonStringToPlaces()
    {
        const string json = """
            {
                "places": {
                    "page": 1,
                    "pages": 1,
                    "perpage": 10,
                    "total": 2,
                    "place": [
                        {
                            "place_id": "kH8dLOubBZRvX_YZ",
                            "woeid": "2487956",
                            "latitude": "37.779",
                            "longitude": "-122.420",
                            "place_url": "/United+States/California/San+Francisco",
                            "place_type": "locality",
                            "place_type_id": 7,
                            "timezone": "America/Los_Angeles",
                            "name": "San Francisco, California, United States",
                            "woe_name": "San Francisco",
                            "_content": "San Francisco, California, United States",
                            "photo_count": 1234567
                        },
                        {
                            "place_id": "4sLMngrTUb8LB5gv",
                            "woeid": "2459115",
                            "latitude": "40.714",
                            "longitude": "-74.006",
                            "place_url": "/United+States/New+York/New+York",
                            "place_type": "locality",
                            "place_type_id": 7,
                            "timezone": "America/New_York",
                            "name": "New York, New York, United States",
                            "woe_name": "New York"
                        }
                    ]
                },
                "stat": "ok"
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<Places>>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var places = result.Content;
        Assert.IsType<Places>(places);
        Assert.Equal(2, places.Values.Count);
        Assert.Equal(2, places.Total);

        var sf = places.Values[0];
        Assert.Equal("kH8dLOubBZRvX_YZ", sf.PlaceId);
        Assert.Equal("2487956", sf.WoeId);
        Assert.Equal(37.779, sf.Latitude);
        Assert.Equal(-122.420, sf.Longitude);
        Assert.Equal("/United+States/California/San+Francisco", sf.PlaceUrl);
        Assert.Equal("locality", sf.PlaceType);
        Assert.Equal(7, sf.PlaceTypeId);
        Assert.Equal("America/Los_Angeles", sf.Timezone);
        Assert.Equal("San Francisco, California, United States", sf.Name);
        Assert.Equal("San Francisco", sf.WoeName);
        Assert.Equal("San Francisco, California, United States", sf.Content);
        Assert.Equal(1234567, sf.PhotoCount);
    }

    [Fact]
    public void PlaceWithLocationHierarchy()
    {
        const string json = """
            {
                "place": {
                    "place_id": "kH8dLOubBZRvX_YZ",
                    "woeid": "2487956",
                    "latitude": "37.779",
                    "longitude": "-122.420",
                    "place_url": "/United+States/California/San+Francisco",
                    "place_type": "locality",
                    "place_type_id": 7,
                    "name": "San Francisco",
                    "locality": {
                        "_content": "San Francisco",
                        "place_id": "kH8dLOubBZRvX_YZ",
                        "woeid": "2487956",
                        "latitude": "37.779",
                        "longitude": "-122.420",
                        "place_url": "/United+States/California/San+Francisco",
                        "place_type": "locality",
                        "place_type_id": 7
                    },
                    "region": {
                        "_content": "California",
                        "place_id": "NsbUWfBTUb4mbyVu",
                        "woeid": "2347563",
                        "latitude": "37.271",
                        "longitude": "-119.270",
                        "place_url": "/United+States/California",
                        "place_type": "region",
                        "place_type_id": 8
                    },
                    "country": {
                        "_content": "United States",
                        "place_id": "nz.gsghTUb4c2WAecA",
                        "woeid": "23424977",
                        "latitude": "48.890",
                        "longitude": "-116.982",
                        "place_url": "/United+States",
                        "place_type": "country",
                        "place_type_id": 12
                    }
                },
                "stat": "ok"
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<Place>>(Encoding.UTF8.GetBytes(json));

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var place = result.Content!;

        Assert.NotNull(place.Locality);
        Assert.Equal("San Francisco", place.Locality!.Content);
        Assert.Equal(7, place.Locality.PlaceTypeId);

        Assert.NotNull(place.Region);
        Assert.Equal("California", place.Region!.Content);
        Assert.Equal("region", place.Region.PlaceType);

        Assert.NotNull(place.Country);
        Assert.Equal("United States", place.Country!.Content);
        Assert.Equal(12, place.Country.PlaceTypeId);
    }
}
