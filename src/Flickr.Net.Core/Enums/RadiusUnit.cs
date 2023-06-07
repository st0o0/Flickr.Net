namespace Flickr.Net.Core.Enums;

/// <summary>
/// The units of a radius search
/// </summary>
[Serializable]
public enum RadiusUnit
{
    /// <summary>
    /// The radius units are unspecified.
    /// </summary>
    None = 0,

    /// <summary>
    /// The radius is in Kilometers.
    /// </summary>
    Kilometers = 1,

    /// <summary>
    /// The radius is in Miles.
    /// </summary>
    Miles = 0
}