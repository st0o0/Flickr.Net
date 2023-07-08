using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals;

namespace Flickr.Net.Core.Test.Entities;

public class LicenseTests
{
    [Fact]
    public void JsonStringToLicenses()
    {
        var json = /*lang=json,strict*/ """
            {
                "licenses": {
                    "license": [
                        {
                            "id": 0,
                            "name": "All Rights Reserved",
                            "url": ""
                        },
                        {
                            "id": 4,
                            "name": "Attribution License",
                            "url": "https:\/\/creativecommons.org\/licenses\/by\/2.0\/"
                        },
                        {
                            "id": 6,
                            "name": "Attribution-NoDerivs License",
                            "url": "https:\/\/creativecommons.org\/licenses\/by-nd\/2.0\/"
                        },
                        {
                            "id": 3,
                            "name": "Attribution-NonCommercial-NoDerivs License",
                            "url": "https:\/\/creativecommons.org\/licenses\/by-nc-nd\/2.0\/"
                        },
                        {
                            "id": 2,
                            "name": "Attribution-NonCommercial License",
                            "url": "https:\/\/creativecommons.org\/licenses\/by-nc\/2.0\/"
                        },
                        {
                            "id": 1,
                            "name": "Attribution-NonCommercial-ShareAlike License",
                            "url": "https:\/\/creativecommons.org\/licenses\/by-nc-sa\/2.0\/"
                        },
                        {
                            "id": 5,
                            "name": "Attribution-ShareAlike License",
                            "url": "https:\/\/creativecommons.org\/licenses\/by-sa\/2.0\/"
                        },
                        {
                            "id": 7,
                            "name": "No known copyright restrictions",
                            "url": "https:\/\/www.flickr.com\/commons\/usage\/"
                        },
                        {
                            "id": 8,
                            "name": "United States Government Work",
                            "url": "http:\/\/www.usa.gov\/copyright.shtml"
                        },
                        {
                            "id": 9,
                            "name": "Public Domain Dedication (CC0)",
                            "url": "https:\/\/creativecommons.org\/publicdomain\/zero\/1.0\/"
                        },
                        {
                            "id": 10,
                            "name": "Public Domain Mark",
                            "url": "https:\/\/creativecommons.org\/publicdomain\/mark\/1.0\/"
                        }
                    ]
                },
                "stat": "ok"
            }
            """;

        var result = FlickrConvert.DeserializeObject<FlickrResult<Licenses>>(json);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Licenses>(items);
        Assert.NotEmpty(items.Values);
        Assert.IsType<License>(items.Values[0]);
        Assert.Equal(11, items.Values.Count);
    }
}
