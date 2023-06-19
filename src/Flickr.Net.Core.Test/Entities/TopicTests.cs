using Flickr.Net.Core.Enums;
using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals.ContractResolver;
using Flickr.Net.Core.NewEntities.Collections;
using Newtonsoft.Json;

namespace Flickr.Net.Core.Test.Entities;

public class TopicTests
{
    [Fact]
    public void JsonStringToTopics()
    {
        var json = /*lang=json,strict*/ """
            {
              "stat": "ok",
              "topics": {
                "group_id": "46744914@N00",
                "iconserver": "1",
                "iconfarm": "1",
                "name": "Tell a story in 5 frames (Visual story telling)",
                "members": "12428",
                "privacy": "3",
                "lang": "en-us",
                "ispoolmoderated": "1",
                "total": "2",
                "page": "1",
                "per_page": "2",
                "pages": "2310",
                "topic": [
                  {
                    "id": "72157625038324579",
                    "subject": "A long time ago in a galaxy far, far away...",
                    "author": "53930889@N04",
                    "authorname": "Smallportfolio_jm08",
                    "role": "member",
                    "iconserver": "5169",
                    "iconfarm": "6",
                    "count_replies": "8",
                    "can_edit": "0",
                    "can_delete": "0",
                    "can_reply": "0",
                    "is_sticky": "0",
                    "is_locked": "",
                    "datecreate": "1287070965",
                    "datelastpost": "1336905518",
                    "message": "<div><span class=\"photo_container pc_m bbml_img\"><a href=\"/photos/53930889@N04/5080874079/\" title=\"Star Wars 1 by Smallportfolio_jm08\"><img class=\"notsowide\" src=\"http://farm5.staticflickr.com/4035/5080874079_684cf874e0_m.jpg\" width=\"240\" height=\"180\" alt=\"Star Wars 1 by Smallportfolio_jm08\"  class=\"pc_img\" border=\"0\" /><\/a><\/span><\/div>\n\n<div><span class=\"photo_container pc_m bbml_img\"><a href=\"/photos/53930889@N04/5081467846/\" title=\"Star Wars 2 by Smallportfolio_jm08\"><img class=\"notsowide\" src=\"http://farm5.staticflickr.com/4071/5081467846_2eec86176d_m.jpg\" width=\"240\" height=\"180\" alt=\"Star Wars 2 by Smallportfolio_jm08\"  class=\"pc_img\" border=\"0\" /><\/a><\/span><\/div>\n\n<div><span class=\"photo_container pc_m bbml_img\"><a href=\"/photos/53930889@N04/5081467886/\" title=\"Star Wars 3 by Smallportfolio_jm08\"><img class=\"notsowide\" src=\"http://farm5.staticflickr.com/4021/5081467886_d8cca6c8e8_m.jpg\" width=\"240\" height=\"180\" alt=\"Star Wars 3 by Smallportfolio_jm08\"  class=\"pc_img\" border=\"0\" /><\/a><\/span><\/div>\n\n<div><span class=\"photo_container pc_m bbml_img\"><a href=\"/photos/53930889@N04/5081467910/\" title=\"Star Wars 4 by Smallportfolio_jm08\"><img class=\"notsowide\" src=\"http://farm5.staticflickr.com/4084/5081467910_274bb11fdc_m.jpg\" width=\"240\" height=\"180\" alt=\"Star Wars 4 by Smallportfolio_jm08\"  class=\"pc_img\" border=\"0\" /><\/a><\/span><\/div>\n\n<div><span class=\"photo_container pc_m bbml_img\"><a href=\"/photos/53930889@N04/5081467948/\" title=\"Star Wars 5 by Smallportfolio_jm08\"><img class=\"notsowide\" src=\"http://farm5.staticflickr.com/4154/5081467948_1a5f200bc0_m.jpg\" width=\"240\" height=\"180\" alt=\"Star Wars 5 by Smallportfolio_jm08\"  class=\"pc_img\" border=\"0\" /><\/a><\/span><\/div>"
                  },
                  {
                    "id": "72157629635119774",
                    "subject": "Where The Fish Are",
                    "author": "75240402@N04",
                    "authorname": "Nokinrocks",
                    "role": "member",
                    "iconserver": "7027",
                    "iconfarm": "8",
                    "count_replies": "0",
                    "can_edit": "0",
                    "can_delete": "0",
                    "can_reply": "0",
                    "is_sticky": "0",
                    "is_locked": "",
                    "datecreate": "1336485653",
                    "datelastpost": "1336485653",
                    "message": "<a href=\"http://www.flickr.com/photos/nokinrocks/7120495637/\"><img class=\"notsowide\" src=\"http://farm9.staticflickr.com/8005/7120495637_fec0382b4b_n.jpg\" width=\"320\" height=\"256\" alt=\"Step It Up\" /><\/a>\n\n<a href=\"http://www.flickr.com/photos/nokinrocks/7122908705/\"><img class=\"notsowide\" src=\"http://farm8.staticflickr.com/7259/7122908705_3bef338378_n.jpg\" width=\"240\" height=\"320\" alt=\"P1050351\" /><\/a>\n\n<a href=\"http://www.flickr.com/photos/nokinrocks/7122922123/\"><img class=\"notsowide\" src=\"http://farm8.staticflickr.com/7052/7122922123_2bfcb6707c_n.jpg\" width=\"214\" height=\"320\" alt=\"Frog On A Log\" /><\/a>\n\n<a href=\"http://www.flickr.com/photos/nokinrocks/7122929521/\"><img class=\"notsowide\" src=\"http://farm8.staticflickr.com/7047/7122929521_8ffebdd424_n.jpg\" width=\"320\" height=\"200\" alt=\"P1050397\" /><\/a>\n\n<a href=\"http://www.flickr.com/photos/nokinrocks/7122916999/\"><img class=\"notsowide\" src=\"http://farm8.staticflickr.com/7200/7122916999_a7328f9dcc_n.jpg\" width=\"320\" height=\"261\" alt=\"P1050361\" /><\/a>"
                  }
                ]
              }
            }
            """;

        var result = JsonConvert.DeserializeObject<FlickrResult<Topics>>(json, new JsonSerializerSettings
        {
            ContractResolver = new GenericJsonPropertyNameContractResolver(),
        });

        Assert.NotNull(result);
        Assert.False(result.HasError);
        var items = result.Content;
        Assert.IsType<Topics>(items);
        Assert.IsType<PoolPrivacy>(items.Privacy);
        Assert.Equal(PoolPrivacy.OpenPublic, items.Privacy);
        Assert.Equal(items.Total, items.Values.Count);
        Assert.False(items.Values[0].IsSticky);
        Assert.False(items.Values[0].IsLocked);
        Assert.False(items.Values[0].CanReply);
        Assert.False(items.Values[0].CanDelete);
        Assert.False(items.Values[0].CanEdit);
        Assert.False(items.Values[1].IsSticky);
        Assert.False(items.Values[1].IsLocked);
        Assert.False(items.Values[1].CanReply);
        Assert.False(items.Values[1].CanDelete);
        Assert.False(items.Values[1].CanEdit);
    }
}
