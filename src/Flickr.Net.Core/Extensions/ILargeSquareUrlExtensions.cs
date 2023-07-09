using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flickr.Net.Core.Extensions;

public static class ILargeSquareUrlExtensions
{
    public static string ToLargeSquareUrl(this ILargeSquareUrl value) => value switch
    {
        PhotoInfo photoInfo => UtilityMethods.UrlFormat(photoInfo, SizeType.LargeSquare, "jpg"),
        _ => string.Empty
    };
}
