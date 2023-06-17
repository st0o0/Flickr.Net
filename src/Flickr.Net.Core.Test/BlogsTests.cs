using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals.ContractResolver;
using Flickr.Net.Core.NewEntities.Collections;
using Newtonsoft.Json;

namespace Flickr.Net.Core.Test;

public class BlogsTests
{
    [Fact]
    public void JsonStringToBlogsObject()
    {
        var json = "{\r\n\t\'stat\': \'ok\',\r\n\t\'blogs\': {\r\n\t\t\'blog\': [\r\n\t\t\t{\r\n\t\t\t\t\'id\'\t\t: \'73\',\r\n\t\t\t\t\'name\'\t\t: \'Bloxus test\',\r\n\t\t\t\t\'needspassword\'\t: \'0\',\r\n\t\t\t\t\'url\'\t\t: \'http://remote.bloxus.com/\'\r\n\t\t\t},\r\n\t\t\t{\r\n\t\t\t\t\'id\'\t\t: \'74\',\r\n\t\t\t\t\'name\'\t\t: \'Manila Test\',\r\n\t\t\t\t\'needspassword\'\t: \'1\',\r\n\t\t\t\t\'url\'\t\t: \'http://flickrtest1.userland.com/\'\r\n\t\t\t}\r\n\t\t]\r\n\t}\r\n}";

        var result = JsonConvert.DeserializeObject<FlickrResult<Blogs>>(json, new JsonSerializerSettings
        {
            ContractResolver = new GenericJsonPropertyNameContractResolver()
        });

        Assert.NotNull(result);
        Assert.False(result.HasError);
        Assert.Equal(2, result.Result.Blog.Count);
    }
}
