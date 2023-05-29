namespace FlickrNet.Core.Enums;

/// <summary>
/// Safety level of the photographic image.
/// </summary>
[Serializable]
public enum SafetyLevel
{
    /// <summary>
    /// No safety level specified.
    /// </summary>
    None = 0,

    /// <summary>
    /// Very safe (suitable for a global family audience).
    /// </summary>
    Safe = 1,

    /// <summary>
    /// Moderate (the odd articstic nude is ok, but thats the limit).
    /// </summary>
    Moderate = 2,

    /// <summary>
    /// Restricted (suitable for over 18s only).
    /// </summary>
    Restricted = 3
}