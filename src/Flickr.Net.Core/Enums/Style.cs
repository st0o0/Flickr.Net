namespace Flickr.Net.Core.Enums;

/// <summary>
/// An enumeration of photo styles.
/// </summary>
[JsonConverter(typeof(StringEnumConverter))]
public enum Style
{
    /// <summary>
    /// Black and white.
    /// </summary>
    [EnumMember(Value = "")]
    BlackAndWhite = 0,

    /// <summary>
    /// Shallow depth of field.
    /// </summary>
    [EnumMember(Value = "")]
    DepthOfField = 1,

    /// <summary>
    /// Minimalist.
    /// </summary>
    [EnumMember(Value = "")]
    Minimalism = 2,

    /// <summary>
    /// Patterns.
    /// </summary>
    [EnumMember(Value = "")]
    Pattern = 3
}