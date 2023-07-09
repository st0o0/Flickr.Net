using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flickr.Net.Core.Extensions;

public static class IMedium640UrlExtensions
{
    public static string ToMedium640Url(this IMedium640Url value) => value switch
    {
        PhotoInfo photoInfo => UtilityMethods.UrlFormat(photoInfo, SizeType.Medium640, "jpg"),
        _ => string.Empty
    };
}
