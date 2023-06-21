using Flickr.Net.Core.Flickrs.Results;
using Flickr.Net.Core.Internals;
using Flickr.Net.Core.NewEntities.Flickr_Photos;

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

        var result = FlickrConvert.DeserializeObject<FlickrContextResult<NextPhoto, PrevPhoto>>(json);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        Assert.Equal(3, result.Count);
        Assert.IsType<NextPhoto>(result.NextPhoto);
        Assert.False(string.IsNullOrEmpty(result.NextPhoto.Id));
        Assert.IsType<PrevPhoto>(result.PrevPhoto);
        Assert.False(string.IsNullOrEmpty(result.PrevPhoto.Id));
    }

    [Fact]
    public void JsonStringToFlickrContextResultSetPool()
    {
        var json = /*lang=json,strict*/ """{"set":[{"title":"2023_Landschaft","id":"72177720306303125","primary":"52714401480","secret":"02ba1c3a58","server":"65535","farm":66,"view_count":"0","comment_count":"0","count_photo":11,"count_video":0}],"pool":[{"title":"Photography","url":"\/groups\/photography-group\/pool\/","id":"40732569271@N01","iconserver":"65535","iconfarm":66,"members":"77770","pool_count":"6877486"},{"title":"visit the world - the travel guide","url":"\/groups\/world\/pool\/","id":"11488522@N00","iconserver":"7","iconfarm":1,"members":"94947","pool_count":"4774736"},{"title":"Nikon Digital SLRs","url":"\/groups\/nikondigitalslr\/pool\/","id":"62334926@N00","iconserver":"24","iconfarm":1,"members":"10172","pool_count":"1123935"},{"title":"Rheinland-Pfalz","url":"\/groups\/rlp\/pool\/","id":"43228340@N00","iconserver":"40","iconfarm":1,"members":"838","pool_count":"41556"},{"title":"Deutsche Foto-Gruppe","url":"\/groups\/defogruppe\/pool\/","id":"15406988@N00","iconserver":"48","iconfarm":1,"members":"4664","pool_count":"743910"},{"title":"Paisajes del mundo\/World Landscapes","url":"\/groups\/paisajes\/pool\/","id":"27303736@N00","iconserver":"50","iconfarm":1,"members":"26089","pool_count":"805890"},{"title":"Naturfotos Deutschland - German Nature Photos","url":"\/groups\/naturfotos_deutschland\/pool\/","id":"88528743@N00","iconserver":"73","iconfarm":1,"members":"4728","pool_count":"303937"},{"title":"Die Pfalz","url":"\/groups\/83441006@N00\/pool\/","id":"83441006@N00","iconserver":"5475","iconfarm":6,"members":"383","pool_count":"15863"},{"title":"Landschaft->deutsch<-","url":"\/groups\/landschaft\/pool\/","id":"87965949@N00","iconserver":"142","iconfarm":1,"members":"1453","pool_count":"90008"},{"title":"Flickr-Fotografen-Deutschland","url":"\/groups\/_flickr-fotografen-_deutschland_\/pool\/","id":"300478@N25","iconserver":"4613","iconfarm":5,"members":"16500","pool_count":"1721592"},{"title":"We travel the World","url":"\/groups\/pancry\/pool\/","id":"402895@N25","iconserver":"1081","iconfarm":2,"members":"50124","pool_count":"1954684"},{"title":"\" Damn Cool Photographers in the  WORLD \"  .\u2665.\u2665.\u2665","url":"\/groups\/damn_cool\/pool\/","id":"481481@N23","iconserver":"65535","iconfarm":66,"members":"9420","pool_count":"884809"},{"title":"Natur-Fotografie-Natur-","url":"\/groups\/natur-fotografie-natur\/pool\/","id":"615422@N22","iconserver":"2022","iconfarm":3,"members":"1775","pool_count":"166238"},{"title":"Deutsche Fotowelt","url":"\/groups\/deutsche_fotowelt\/pool\/","id":"588399@N24","iconserver":"7470","iconfarm":8,"members":"4577","pool_count":"681596"},{"title":"Official National Geographic Group","url":"\/groups\/ngmanimallovers\/pool\/","id":"650323@N24","iconserver":"3047","iconfarm":4,"members":"39354","pool_count":"2840216"},{"title":"~* Natur pur *~","url":"\/groups\/694953@N20\/pool\/","id":"694953@N20","iconserver":"3807","iconfarm":4,"members":"3513","pool_count":"319653"},{"title":"as beautiful as you want","url":"\/groups\/1046032@N20\/pool\/","id":"1046032@N20","iconserver":"7896","iconfarm":8,"members":"24778","pool_count":"2694386"},{"title":"Lovely villages, fields, meadows, swamps & countryside","url":"\/groups\/lovelyvillagesandfielfs\/pool\/","id":"1135942@N20","iconserver":"2671","iconfarm":3,"members":"8911","pool_count":"524947"},{"title":"Urlaub und Ausflugsziele in Rheinland-Pfalz","url":"\/groups\/urlaub_ausflugsziele_in_rheinland-pfalz\/pool\/","id":"1692810@N21","iconserver":"2010","iconfarm":3,"members":"154","pool_count":"9213"},{"title":"Nikon Deutschland","url":"\/groups\/nikondeutschland\/pool\/","id":"1772169@N20","iconserver":"6035","iconfarm":7,"members":"892","pool_count":"98315"},{"title":"Beautiful landscape","url":"\/groups\/beautiful-landscapes\/pool\/","id":"2009065@N22","iconserver":"8162","iconfarm":9,"members":"779","pool_count":"52382"},{"title":"NUESTRAS FOTOGRAF\u00cdAS.","url":"\/groups\/bienlujanero\/pool\/","id":"1945088@N25","iconserver":"7914","iconfarm":8,"members":"5324","pool_count":"702670"},{"title":"Great Landscapes\/Cityscapes Taken with NIKON CAMERAS!!!!","url":"\/groups\/2097556@N25\/pool\/","id":"2097556@N25","iconserver":"7346","iconfarm":8,"members":"491","pool_count":"23740"},{"title":"*Landscapes worldwide*","url":"\/groups\/landscapes-worldwide\/pool\/","id":"2432849@N24","iconserver":"7189","iconfarm":8,"members":"4451","pool_count":"214129"},{"title":"Nikon-D750","url":"\/groups\/nikond750\/pool\/","id":"2684685@N20","iconserver":"3931","iconfarm":4,"members":"3991","pool_count":"240367"},{"title":"Nikon D700 Series (D750, D700)","url":"\/groups\/2713291@N21\/pool\/","id":"2713291@N21","iconserver":"5563","iconfarm":6,"members":"518","pool_count":"43459"},{"title":"D750 nikon","url":"\/groups\/2751435@N22\/pool\/","id":"2751435@N22","iconserver":"3926","iconfarm":4,"members":"6329","pool_count":"360606"},{"title":"I Love The Nikon D750","url":"\/groups\/2759109@N23\/pool\/","id":"2759109@N23","iconserver":"3929","iconfarm":4,"members":"510","pool_count":"39985"},{"title":"Nebel, Dunst.","url":"\/groups\/lichtzauber\/pool\/","id":"2814138@N21","iconserver":"410","iconfarm":1,"members":"177","pool_count":"3682"},{"title":"Momentos para no olvidar","url":"\/groups\/2805208@N25\/pool\/","id":"2805208@N25","iconserver":"510","iconfarm":1,"members":"9713","pool_count":"1142231"},{"title":"* just photos * no rules please use comment code appreciated","url":"\/groups\/justdave\/pool\/","id":"2875268@N23","iconserver":"3747","iconfarm":4,"members":"11682","pool_count":"1805646"},{"title":"Der Lebensraum: Naturphotographie","url":"\/groups\/2969779@N22\/pool\/","id":"2969779@N22","iconserver":"4712","iconfarm":5,"members":"477","pool_count":"33327"},{"title":"Nikon Wildlife, Flowers and the Beauty of Nature","url":"\/groups\/3102142@N22\/pool\/","id":"3102142@N22","iconserver":"945","iconfarm":1,"members":"1618","pool_count":"163097"},{"title":"Flickr Forest Landscapes","url":"\/groups\/14648475@N21\/pool\/","id":"14648475@N21","iconserver":"65535","iconfarm":66,"members":"650","pool_count":"20051"},{"title":"The New Focus 1a","url":"\/groups\/thenewfocus1a\/pool\/","id":"14636966@N20","iconserver":"65535","iconfarm":66,"members":"929","pool_count":"84451"},{"title":"BEAUTY PHOTOS  AROUND THE WORLD","url":"\/groups\/14625763@N25\/pool\/","id":"14625763@N25","iconserver":"65535","iconfarm":66,"members":"16495","pool_count":"1957778"},{"title":"Flickr Panoply","url":"\/groups\/panoply\/pool\/","id":"14818575@N22","iconserver":"65535","iconfarm":66,"members":"402","pool_count":"28789"},{"title":"* no limits, just quality photography!","url":"\/groups\/14805334@N23\/pool\/","id":"14805334@N23","iconserver":"65535","iconfarm":66,"members":"4286","pool_count":"491642"},{"title":"Fans of Flickr","url":"\/groups\/14827151@N21\/pool\/","id":"14827151@N21","iconserver":"65535","iconfarm":66,"members":"1106","pool_count":"86908"},{"title":"WONDERS OF PHOTOGRAPHY IN GENERAL.MARAVILLAS DE LA FOTOGRAFIA EN","url":"\/groups\/14876488@N22\/pool\/","id":"14876488@N22","iconserver":"65535","iconfarm":66,"members":"3418","pool_count":"119863"}],"stat":"ok"}""";

        var result = FlickrConvert.DeserializeObject<FlickrAllContextResult<Set, Pool>>(json);

        Assert.NotNull(result);
        Assert.False(result.HasError);
        Assert.IsType<Set>(result.Primary[0]);
        Assert.Single(result.Primary);
        Assert.IsType<Pool>(result.Second[0]);
        Assert.Equal(40, result.Second.Count);
    }
}