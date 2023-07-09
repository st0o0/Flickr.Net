using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flickr.Net.Core.Extensions;

public static class ISmall400Extensions
{
    public static string ToSmall400Url(this ISmall400Url value) => value switch
    {
        PhotoInfo photoInfo => UtilityMethods.UrlFormat(photoInfo, SizeType.Small400, "jpg"),
        _ => string.Empty
    };
}
