using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flickr.Net.Core.Extensions;

public static class ILarge2048UrlExtensions
{
    public static string ToLarge2048Url(this ILarge2048Url value) => value switch
    {
        PhotoInfo photoInfo => UtilityMethods.UrlFormat(photoInfo, SizeType.Large2048, "jpg"),
        _ => string.Empty
    };
}
