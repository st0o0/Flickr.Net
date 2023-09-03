﻿using System.Text;
using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals;

namespace Flickr.Net.Core.Test.Entities;

public class BlogTests
{
    [Fact]
    public void JsonStringToBlogs()
    {
        var json = /*lang=json*/ """
            {
            "stat": "ok",
            "blogs":{
            "blog": [
                        {
                            "id"		: "73",
                            "name"		: "Bloxus test",
                            "needspassword"	: "0",
                            "url"		: "http://remote.bloxus.com/"
                        },
                        {
                            "id"		: "74",
                            "name"		: "Manila Test",
                            "needspassword"	: "1",
                            "url"		: "http://flickrtest1.userland.com/"
                        }
                    ]
                }
            }
            """;

        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));

        var result = FlickrConvert.DeserializeObject<FlickrResult<Blogs>>(ms);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Blogs>(items);
        Assert.Equal(2, result.Content.Values.Count);
        
    }

    [Fact]
    public void JsonStringToServices()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "services": {
                "service": [
                  {
                    "id": "beta.blogger.com",
                    "_content": "Blogger"
                  },
                  {
                    "id": "Typepad",
                    "_content": "Typepad"
                  },
                  {
                    "id": "MovableType",
                    "_content": "Movable Type"
                  },
                  {
                    "id": "LiveJournal",
                    "_content": "LiveJournal"
                  },
                  {
                    "id": "MetaWeblogAPI",
                    "_content": "Wordpress"
                  },
                  {
                    "id": "MetaWeblogAPI",
                    "_content": "MetaWeblogAPI"
                  },
                  {
                    "id": "Manila",
                    "_content": "Manila"
                  },
                  {
                    "id": "AtomAPI",
                    "_content": "AtomAPI"
                  },
                  {
                    "id": "BloggerAPI",
                    "_content": "BloggerAPI"
                  },
                  {
                    "id": "Vox",
                    "_content": "Vox"
                  },
                  {
                    "id": "Twitter",
                    "_content": "Twitter"
                  }
                ]
              }
            }
            """;

        using var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));

        var result = FlickrConvert.DeserializeObject<FlickrResult<Services>>(ms);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Services>(items);
        Assert.Equal(11, result.Content.Values.Count);
    }
}