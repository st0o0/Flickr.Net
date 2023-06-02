namespace Flickr.Net.Core.Enums;

/// <summary>
/// A list of service the Flickr.Net API Supports.
/// </summary>
/// <remarks>
/// Not all methods are supported by all service. Behaviour of the library may be unpredictable if not using Flickr
/// as your service.
/// </remarks>
public enum SupportedService
{
    /// <summary>
    /// Flickr - http://www.flickr.com/services/api
    /// </summary>
    Flickr = 0,

    /// <summary>
    /// Zooomr - http://blog.zooomr.com/2006/03/27/attention-developers/
    /// </summary>
    Zooomr = 1,

    /// <summary>
    /// 23HQ = http://www.23hq.com/doc/api/
    /// </summary>
    TwentyThreeHQ = 2
}