using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flickr.Net.Core.Extensions;

public static class IOriginalUrlExtensions
{
    public static string ToOriginalUrl(this IOriginalUrl value) => value switch
    {
        PhotoInfo photoInfo => UtilityMethods.UrlFormat(photoInfo, SizeType.Original, "jpg"),
        _ => string.Empty
    };
}
