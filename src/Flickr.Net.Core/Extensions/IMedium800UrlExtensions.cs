using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flickr.Net.Core.Extensions;

public static class IMedium800UrlExtensions
{
    public static string ToMedium800Url(this IMedium800Url value) => value switch
    {
        PhotoInfo photoInfo => UtilityMethods.UrlFormat(photoInfo, SizeType.Medium800, "jpg"),
        _ => string.Empty
    };
}
