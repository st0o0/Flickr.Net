using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flickr.Net.Core.Extensions;

public static class ISmall320UrlExtensions
{
    public static string ToSmall320Url(this ISmall320Url value) => value switch
    {
        PhotoInfo photoInfo => UtilityMethods.UrlFormat(photoInfo, SizeType.Small320, "jpg"),
        _ => string.Empty
    };
}
